import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:app_review_hieunt/utilities/data.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

class GetHeaderNotification extends StatelessWidget {
  const GetHeaderNotification({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
        // height: 80,
        padding: EdgeInsets.only(top: 30, left: 15, right: 15, bottom: 15),
        decoration: BoxDecoration(
          color: primaryColor,
        ),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Text(
              "Notifications",
              style: TextStyle(
                  color: Colors.white,
                  fontWeight: FontWeight.bold,
                  fontSize: 22),
            ),
            Icon(
              Icons.more_horiz,
              color: Colors.white.withOpacity(0.5),
              size: 30,
            )
          ],
        ));
  }
}
