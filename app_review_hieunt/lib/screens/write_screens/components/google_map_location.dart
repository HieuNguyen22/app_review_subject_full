import 'dart:async';

import 'package:app_review_hieunt/controllers/write_controller.dart';
import 'package:app_review_hieunt/screens/write_screens/components/custom_dialog_loading.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:geolocator/geolocator.dart';
import 'package:get/get.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';

class GoogleMapLocation extends StatefulWidget {
  final double latitude;
  final double longitude;
  const GoogleMapLocation(
      {Key? key, required this.latitude, required this.longitude})
      : super(key: key);

  @override
  State<GoogleMapLocation> createState() => _GoogleMapLocationState();
}

class _GoogleMapLocationState extends State<GoogleMapLocation> {
  Completer<GoogleMapController> _controller = Completer();
  var controller = Get.put(WriteController());

  Set<Marker> markers = {};

  @override
  Widget build(BuildContext context) {
    CameraPosition _initialCameraPosition = CameraPosition(
      target: LatLng(widget.latitude, widget.longitude),
      zoom: 14.4746,
    );

    return Container(
      decoration: BoxDecoration(borderRadius: BorderRadius.circular(20)),
      width: double.maxFinite,
      height: Get.width * 0.4,
      child: GoogleMap(
        mapType: MapType.normal,
        zoomControlsEnabled: false,
        markers: <Marker>{
          Marker(
              markerId: const MarkerId('currentLocation'),
              position: LatLng(widget.latitude, widget.longitude)),
        },
        initialCameraPosition: _initialCameraPosition,
        onMapCreated: (GoogleMapController controller) {
          _controller.complete(controller);
        },
      ),
    );
  }
}
