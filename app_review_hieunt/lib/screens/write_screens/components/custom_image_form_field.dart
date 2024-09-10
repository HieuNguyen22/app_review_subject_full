import 'dart:io';
import 'package:app_review_hieunt/controllers/write_controller.dart';
import 'package:app_review_hieunt/screens/write_screens/components/custom_dialog_loading.dart';
import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:dotted_border/dotted_border.dart';
import 'package:flutter/material.dart';
import 'package:geolocator/geolocator.dart';
import 'package:get/get.dart';
import 'package:image_picker/image_picker.dart';

class CustomImageFormField extends StatefulWidget {
  final IconData icon;
  final String text;
  final String fileType;
  final Function(File) onChanged;
  File? _pickedFile;

  CustomImageFormField({
    Key? key,
    required this.icon,
    required this.text,
    required this.fileType,
    required this.onChanged,
  }) : super(key: key);

  @override
  State<CustomImageFormField> createState() => _CustomImageFormFieldState();
}

class _CustomImageFormFieldState extends State<CustomImageFormField> {
  late List<File> imageFiles = [];
  File? videoFile;
  String? location;

  var controller = Get.put(WriteController());

  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    return FormField<File>(
        validator: (widget.fileType == 'image')
            ? (_) {
                if (imageFiles == null || imageFiles.isEmpty)
                  return 'Pick a picture';
              }
            : ((widget.fileType == 'video')
                ? (_) {
                    if (videoFile == null) return 'Pick a video';
                  }
                : (_) {
                    if (location == null) return 'Get the location';
                  }),
        builder: (formFieldState) {
          return Column(
            children: [
              GestureDetector(
                onTap: (widget.fileType == 'image')
                    ? getImage
                    : ((widget.fileType == 'video') ? getVideo : getLocation),
                child: DottedBorder(
                  dashPattern: [8, 4],
                  color: primaryLightColor.withOpacity(0.5),
                  borderType: BorderType.RRect,
                  radius: Radius.circular(10),
                  child: Container(
                    alignment: Alignment.center,
                    width: size.width - 20,
                    height: size.height / 7,
                    decoration: BoxDecoration(
                      color: primaryOpacityColor,
                      borderRadius: BorderRadius.circular(11),
                    ),
                    child: getLoadedMediaField(size),
                  ),
                ),
              ),
              if (formFieldState.hasError)
                Padding(
                  padding: const EdgeInsets.only(left: 8, top: 10),
                  child: Text(
                    formFieldState.errorText!,
                    style: TextStyle(
                        fontStyle: FontStyle.normal,
                        fontSize: 13,
                        color: Colors.red[700],
                        height: 0.5),
                  ),
                )
            ],
          );
        });
  }

  void getLocation() async {
    showLoading(context);
    Position position = await _getGeoLocationPosition();

    controller.checkClickLocate.value = true;
    controller.currentLat.value = position.latitude;
    controller.currentLong.value = position.longitude;

    Navigator.pop(context);
  }

  Future<Position> _getGeoLocationPosition() async {
    bool serviceEnabled;
    LocationPermission permission;
    // Test if location services are enabled.
    serviceEnabled = await Geolocator.isLocationServiceEnabled();
    if (!serviceEnabled) {
      await Geolocator.openLocationSettings();
      return Future.error('Location services are disabled.');
    }
    permission = await Geolocator.checkPermission();
    if (permission == LocationPermission.denied) {
      permission = await Geolocator.requestPermission();
      if (permission == LocationPermission.denied) {
        return Future.error('Location permissions are denied');
      }
    }
    if (permission == LocationPermission.deniedForever) {
      // Permissions are denied forever, handle appropriately.
      return Future.error(
          'Location permissions are permanently denied, we cannot request permissions.');
    }

    return await Geolocator.getCurrentPosition(
        desiredAccuracy: LocationAccuracy.high);
  }

  void getImage() async {
    ImagePicker _picker = ImagePicker();
    final List<XFile>? images = await _picker.pickMultiImage();
    if (images != null) {
      setState(() {
        images.forEach((element) {
          imageFiles.add(File(element.path));
        });
      });
    }
  }

  void getVideo() async {
    ImagePicker _picker = ImagePicker();
    final XFile? video = await _picker.pickVideo(source: ImageSource.gallery);
    if (video != null) {
      setState(() {
        videoFile = File(video.path);
      });
    }
  }

  Widget getLoadedMediaField(size) {
    return (widget.fileType == 'image')
        ? ((!imageFiles.isEmpty)
            ? SingleChildScrollView(
                scrollDirection: Axis.horizontal,
                child: Row(
                    children: List.generate(imageFiles.length, (index) {
                  return Container(
                    margin: EdgeInsets.symmetric(horizontal: 5),
                    width: size.height / 7,
                    height: size.height / 7,
                    child: Image.file(imageFiles[index], fit: BoxFit.cover),
                  );
                })),
              )
            : getNormalMediaField())
        : getNormalMediaField();
  }

  Widget getNormalMediaField() {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Icon(
          widget.icon,
          color: primaryLightColor.withOpacity(0.7),
          size: 50,
        ),
        Container(
            width: 230,
            child: Text(
              widget.text,
              textAlign: TextAlign.center,
              style: TextStyle(fontSize: 16, color: primaryLightColor),
            ))
      ],
    );
  }
}
