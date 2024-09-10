import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

Future showLoading(context) async {
  return showDialog(
    routeSettings: const RouteSettings(name: "showDialog"),
    barrierDismissible: false,
    context: context,
    useRootNavigator: true,
    builder: (context) => WillPopScope(
      onWillPop: () async {
        return false;
      },
      child: AlertDialog(
        backgroundColor: Colors.transparent,
        elevation: 0,
        content: Center(
          child: CircularProgressIndicator(color: Colors.white),
        ),
      ),
    ),
  );
}
