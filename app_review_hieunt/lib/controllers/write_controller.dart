import 'package:geolocator/geolocator.dart';
import 'package:get/get.dart';

class WriteController extends GetxController {
  var address = 'your address'.obs;
  var checkClickLocate = false.obs;
  var currentLat = (6.0).obs;
  var currentLong = (6.0).obs;
}
