import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:app_review_hieunt/utilities/data.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

class GetBodyNotification extends StatefulWidget {
  const GetBodyNotification({Key? key}) : super(key: key);

  @override
  State<GetBodyNotification> createState() => _GetBodyNotificationState();
}

class _GetBodyNotificationState extends State<GetBodyNotification> {
  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    return Container(
        width: size.width,
        // height: size.height,
        padding: EdgeInsets.all(20),
        decoration: BoxDecoration(
            borderRadius: BorderRadius.only(
                topLeft: Radius.circular(20), topRight: Radius.circular(20)),
            color: Colors.white),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            SizedBox(height: 10),
            Text("JUST NOW",
                style: TextStyle(
                    fontWeight: FontWeight.bold,
                    color: Colors.black.withOpacity(0.3),
                    fontSize: 17)),
            Padding(
              padding: const EdgeInsets.only(top: 20, bottom: 20),
              child: Column(
                children: [
                  getListNoti("Just now"),
                  Divider(),
                ],
              ),
            ),
            Text("YESTERDAY",
                style: TextStyle(
                    fontWeight: FontWeight.bold,
                    color: Colors.black.withOpacity(0.3),
                    fontSize: 17)),
            Padding(
              padding: const EdgeInsets.only(top: 20, bottom: 20),
              child: Column(
                children: [
                  getListNoti("1 day ago"),
                  Divider(),
                ],
              ),
            ),
            Text("THIS WEEK",
                style: TextStyle(
                    fontWeight: FontWeight.bold,
                    color: Colors.black.withOpacity(0.3),
                    fontSize: 17)),
            Padding(
              padding: const EdgeInsets.only(top: 20, bottom: 20),
              child: Column(
                children: [
                  getListNoti("This week"),
                  Divider(),
                ],
              ),
            ),
            Text("THIS MONTH",
                style: TextStyle(
                    fontWeight: FontWeight.bold,
                    color: Colors.black.withOpacity(0.3),
                    fontSize: 17)),
            Padding(
              padding: const EdgeInsets.only(top: 20, bottom: 20),
              child: getListNoti("This month"),
            ),
          ],
        ));
  }

  Widget getListNoti(time) {
    List returnedList = [];
    listNotifications.forEach((item) {
      if (item.getTime == time) {
        returnedList.add(item);
        // return getContextNotification(item);
      }
    });

    // return Text("error");

    return Column(
        children: List.generate(returnedList.length, (index) {
      var item = returnedList[index];
      return getContextNotification(item);
    }));
  }

  Widget getContextNotification(notification) {
    var type = notification.getType;
    var icon;
    String text;

    switch (type) {
      case "like":
        {
          icon = Icons.thumb_up;
          text = " liked your review";
        }
        break;
      case "comment":
        {
          icon = Icons.comment;
          text = " mentioned you in a comment";
        }
        break;
      case "unlike":
        {
          icon = Icons.thumb_down;
          text = " disliked your review";
        }
        break;
      case "follow":
        {
          text = " followed you";
        }
        break;
      default:
        {
          text = " followed you";
        }
    }

    return Padding(
      padding: const EdgeInsets.only(bottom: 7),
      child: Row(
        children: [
          Stack(children: [
            Container(
              height: 50,
              width: 50,
              decoration: BoxDecoration(
                border: Border.all(width: 1, color: Colors.white),
                  shape: BoxShape.circle,
                  image: DecorationImage(
                      fit: BoxFit.cover,
                      image:
                          NetworkImage(notification.getUserSend.getAvatarUrl))),
            ),
            (icon != null)
                ? Positioned(
                    bottom: 0,
                    right: 0,
                    child: Container(
                        height: 20,
                        width: 20,
                        decoration: BoxDecoration(
                          color: Colors.white,
                          shape: BoxShape.circle,
                          boxShadow: [
                            BoxShadow(
                              color: Colors.black12,
                              spreadRadius: 1,
                              blurRadius: 10,
                            ),
                          ],
                        ),
                        child: Icon(
                          icon,
                          color: primaryColor,
                          size: 12,
                        )))
                : Container()
          ]),
          SizedBox(width: 10),
          Expanded(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                RichText(
                    text: TextSpan(children: [
                  TextSpan(
                      text: notification.getUserSend.getName,
                      style: TextStyle(
                          color: Colors.black,
                          fontWeight: FontWeight.bold,
                          fontSize: 15)),
                  TextSpan(
                      text: text,
                      style: TextStyle(color: Colors.black, fontSize: 15))
                ])),
                SizedBox(height: 2),
                Text(
                  notification.getTime,
                  style: TextStyle(
                    color: Colors.black54,
                    fontSize: 13
                  ),
                )
              ],
            ),
          )
        ],
      ),
    );
  }
}
