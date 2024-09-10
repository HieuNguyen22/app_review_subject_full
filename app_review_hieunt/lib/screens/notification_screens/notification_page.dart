import 'package:app_review_hieunt/screens/notification_screens/components/get_body_notification.dart';
import 'package:app_review_hieunt/screens/notification_screens/components/get_header_notification.dart';
import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

class NotificationPage extends StatefulWidget {
  const NotificationPage({Key? key}) : super(key: key);

  @override
  State<NotificationPage> createState() => _NotificationPageState();
}

class _NotificationPageState extends State<NotificationPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: primaryColor,
      body: getBodyNotification(),
    );
  }

  Widget getBodyNotification() {
    return ListView(
        scrollDirection: Axis.vertical,
        physics: BouncingScrollPhysics(),
        children: [GetHeaderNotification(), GetBodyNotification()]);
  }
}
