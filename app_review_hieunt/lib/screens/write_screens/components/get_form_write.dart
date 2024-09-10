import 'package:app_review_hieunt/controller_page.dart';
import 'package:app_review_hieunt/controllers/write_controller.dart';
import 'package:app_review_hieunt/screens/review_screens/review_page.dart';
import 'package:app_review_hieunt/screens/test_google_map.dart';
import 'package:app_review_hieunt/screens/write_screens/components/custom_dialog_loading.dart';
import 'package:app_review_hieunt/screens/write_screens/components/custom_image_form_field.dart';
import 'package:app_review_hieunt/screens/write_screens/components/google_map_location.dart';
import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:awesome_dialog/awesome_dialog.dart';
import 'package:dotted_border/dotted_border.dart';
import 'package:dropdown_button2/dropdown_button2.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:geocoding/geocoding.dart';
import 'package:geolocator/geolocator.dart';
import 'package:get/get.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';

class GetFormWrite extends StatefulWidget {
  const GetFormWrite({Key? key}) : super(key: key);

  @override
  State<GetFormWrite> createState() => _GetFormWriteState();
}

class _GetFormWriteState extends State<GetFormWrite> {
  String selectedValue = "";
  final _formKey = GlobalKey<FormState>();

  var controller = Get.put(WriteController());
  TextEditingController controllerTextField = TextEditingController();

  String location = 'Null, Press Button';
  // String address = 'search'.obs;

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

  Future<void> GetAddressFromLatLong(Position position) async {
    List<Placemark> placemarks =
        await placemarkFromCoordinates(position.latitude, position.longitude);
    Placemark place = placemarks[3];
    print(place);
    controller.address.value =
        '${place.street}, ${place.subAdministrativeArea}, ${place.administrativeArea}, ${place.country}';
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    return Container(
      width: size.width,
      padding: EdgeInsets.all(20),
      decoration: BoxDecoration(
          borderRadius: BorderRadius.only(
              topLeft: Radius.circular(20), topRight: Radius.circular(20)),
          color: Colors.white),
      child: Form(
        key: _formKey,
        child: Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
          SizedBox(height: 5),
          Text("Review Title",
              style: TextStyle(
                  fontWeight: FontWeight.bold,
                  color: Colors.black.withOpacity(0.6),
                  fontSize: 17)),
          SizedBox(height: 10),
          TextFormField(
            validator: (value) {
              if (value == null || value.isEmpty) {
                return 'Please fill in the blank';
              }
              return null;
            },
            decoration: const InputDecoration(
                hintText: "Enter the Title",
                hintStyle: TextStyle(
                    fontSize: 22,
                    color: Color.fromARGB(255, 200, 199, 204),
                    fontWeight: FontWeight.bold)),
          ),
          SizedBox(height: 30),
          Text("What's Your Rate?",
              style: TextStyle(
                  fontWeight: FontWeight.bold,
                  color: Colors.black.withOpacity(0.6),
                  fontSize: 17)),
          SizedBox(height: 15),
          RatingBar.builder(
              itemSize: 42,
              initialRating: 0,
              minRating: 1,
              direction: Axis.horizontal,
              allowHalfRating: true,
              itemCount: 5,
              itemPadding: EdgeInsets.symmetric(horizontal: 1.0),
              itemBuilder: (context, _) => Icon(
                    Icons.star_rounded,
                    color: Colors.amber,
                  ),
              onRatingUpdate: (ratin) {}),
          SizedBox(height: 30),
          Text("Category",
              style: TextStyle(
                  fontWeight: FontWeight.bold,
                  color: Colors.black.withOpacity(0.6),
                  fontSize: 17)),
          SizedBox(height: 15),
          getDropDownButton(),
          SizedBox(height: 30),
          Padding(
            padding: const EdgeInsets.only(right: 8.0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text("Address",
                    style: TextStyle(
                        fontWeight: FontWeight.bold,
                        color: Colors.black.withOpacity(0.6),
                        fontSize: 17)),
                GestureDetector(
                  onTap: () async {
                    showLoading(context);
                    Position position = await _getGeoLocationPosition();
                    location =
                        'Lat: ${position.latitude} , Long: ${position.longitude}';
                    await GetAddressFromLatLong(position);

                    controllerTextField.text = controller.address.value;

                    controller.checkClickLocate.value = true;
                    controller.currentLat.value = position.latitude;
                    controller.currentLong.value = position.longitude;

                    print("Address: " + controller.address.value.toString());
                    print("Latitude: " + controller.currentLat.value.toString());
                    print("Longtitude: " + controller.currentLong.value.toString());

                    Navigator.pop(context);
                  },
                  child: Container(
                    height: 27,
                    width: 27,
                    decoration: BoxDecoration(
                        image: DecorationImage(
                            image: AssetImage("assets/ic_location.png"))),
                  ),
                )
              ],
            ),
          ),
          SizedBox(height: 15),
          getTextFieldLocation("Write the address here"),
          SizedBox(height: 30),
          Padding(
            padding: const EdgeInsets.only(right: 8.0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text("Location",
                    style: TextStyle(
                        fontWeight: FontWeight.bold,
                        color: Colors.black.withOpacity(0.6),
                        fontSize: 17)),
              ],
            ),
          ),
          SizedBox(height: 15),
          Obx(() => (!controller.checkClickLocate.value)
              ? CustomImageFormField(
                  icon: Icons.location_on,
                  text: "Click to add location",
                  fileType: 'location',
                  onChanged: (_file) {},
                )
              : GoogleMapLocation(
                  latitude: controller.currentLat.value,
                  longitude: controller.currentLong.value,
                )),
          SizedBox(height: 30),
          Text("Your Comment",
              style: TextStyle(
                  fontWeight: FontWeight.bold,
                  color: Colors.black.withOpacity(0.6),
                  fontSize: 17)),
          SizedBox(height: 15),
          getTextFieldComment("Write your comment here"),
          SizedBox(height: 30),
          Text("Upload Photos",
              style: TextStyle(
                  fontWeight: FontWeight.bold,
                  color: Colors.black.withOpacity(0.6),
                  fontSize: 17)),
          SizedBox(height: 15),
          CustomImageFormField(
            icon: Icons.add_a_photo_rounded,
            text: "Click to add photos",
            fileType: 'image',
            onChanged: (_file) {},
          ),
          SizedBox(height: 30),
          Text("Upload Videos",
              style: TextStyle(
                  fontWeight: FontWeight.bold,
                  color: Colors.black.withOpacity(0.6),
                  fontSize: 17)),
          SizedBox(height: 15),
          CustomImageFormField(
            icon: Icons.video_call_rounded,
            text: "Click to add videos",
            fileType: 'video',
            onChanged: (_file) {},
          ),
          SizedBox(height: 25),
          ElevatedButton(
            onPressed: () {
              if (_formKey.currentState!.validate()) {
                showDialogSubmit();
              } else {}
            },
            child: Text("Submit Your Review", style: TextStyle(fontSize: 17)),
            style: ElevatedButton.styleFrom(
                primary: primaryColor, fixedSize: Size(size.width, 50)),
          ),
          SizedBox(height: 10)
        ]),
      ),
      // child: Text("test"),
    );
  }

  void showDialogSubmit() {
    AwesomeDialog(
      context: context,
      animType: AnimType.SCALE,
      dialogType: DialogType.SUCCES,
      body: Center(
        child: Column(
          children: [
            SizedBox(height: 10),
            Text(
              'Success!',
              style: TextStyle(fontWeight: FontWeight.bold, fontSize: 22),
            ),
            SizedBox(height: 7),
            Text('Your post is pending')
          ],
        ),
      ),
      title: 'This is Ignored',
      desc: 'This is also Ignored',
      btnOkOnPress: () {
        Navigator.of(context)
            .push(MaterialPageRoute(builder: (_) => ControllerPage(index: 0)));
      },
    )..show();
  }

  Widget showDialogLocation() {
    return Dialog(
      // The background color

      child: Padding(
        padding: const EdgeInsets.symmetric(vertical: 20),
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: const [
            // The loading indicator
            CircularProgressIndicator(),
            SizedBox(
              height: 15,
            ),
          ],
        ),
      ),
    );
  }

  Widget getTextFieldLocation(context) {
    return TextFormField(
      controller: controllerTextField,
      validator: (value) {
        if (value == null || value.isEmpty) {
          return 'Please fill in the blank';
        }
        return null;
      },
      decoration: InputDecoration(
          enabledBorder: OutlineInputBorder(
              borderSide: BorderSide(
                  width: 1, color: primaryLightColor.withOpacity(0.7))),
          hintText: context,
          hintStyle: TextStyle(color: primaryLightColor.withOpacity(0.7))),
    );
  }

  Widget getTextFieldComment(context) {
    return TextFormField(
      validator: (value) {
        if (value == null || value.isEmpty) {
          return 'Please fill in the blank';
        }
        return null;
      },
      decoration: InputDecoration(
          enabledBorder: OutlineInputBorder(
              borderSide: BorderSide(
                  width: 1, color: primaryLightColor.withOpacity(0.7))),
          hintText: context,
          hintStyle: TextStyle(color: primaryLightColor.withOpacity(0.7))),
    );
  }

// Tao drop down button
  Widget getDropDownButton() {
    return DottedBorder(
      dashPattern: [8, 4],
      color: primaryLightColor.withOpacity(0.5),
      borderType: BorderType.RRect,
      radius: Radius.circular(10),
      child: DropdownButtonFormField2(
        decoration: InputDecoration(
          isDense: true,
          contentPadding: EdgeInsets.zero,
          border: OutlineInputBorder(
            borderRadius: BorderRadius.circular(5),
            borderSide: BorderSide.none,
          ),
          filled: true,
          fillColor: primaryOpacityColor,
        ),
        isExpanded: true,
        hint: const Text(
          'Select Category',
          style: TextStyle(fontSize: 14, color: Colors.black45),
        ),
        icon: const Icon(
          Icons.keyboard_arrow_down,
          color: Colors.black38,
        ),
        iconSize: 30,
        buttonHeight: 60,
        buttonPadding: const EdgeInsets.only(left: 20, right: 10),
        dropdownDecoration: BoxDecoration(
          borderRadius: BorderRadius.circular(10),
        ),
        items: categoryItems
            .map((item) => DropdownMenuItem<String>(
                  value: item,
                  child: Text(
                    item,
                    style: const TextStyle(
                      fontSize: 14,
                    ),
                  ),
                ))
            .toList(),
        validator: (value) {
          if (value == null) {
            return 'Please select Category.';
          }
        },
        onChanged: (value) {
          selectedValue = value.toString();
        },
        onSaved: (value) {
          selectedValue = value.toString();
        },
      ),
    );
  }
}
