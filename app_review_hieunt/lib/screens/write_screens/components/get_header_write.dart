import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:app_review_hieunt/utilities/data.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

class GetHeaderWrite extends StatelessWidget {
  const GetHeaderWrite({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
        // height: 60,
        padding: EdgeInsets.only(top: 30, left: 15, right: 15, bottom: 15),
        decoration: BoxDecoration(
          color: primaryColor,
        ),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Text(
              "Rate & Share",
              style: TextStyle(
                  color: Colors.white,
                  fontWeight: FontWeight.bold,
                  fontSize: 22),
            ),
            Text(
              "Cancel",
              style: TextStyle(
                  color: Colors.white.withOpacity(0.5),
                  fontWeight: FontWeight.bold,
                  fontSize: 18),
            ),
          ],
        ));
  }
}
