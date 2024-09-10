import 'package:app_review_hieunt/screens/notification_screens/components/get_body_notification.dart';
import 'package:app_review_hieunt/screens/profile_screens/components/get_body_profile.dart';
import 'package:app_review_hieunt/screens/profile_screens/components/get_header_profile.dart';
import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

class ProfilePage extends StatefulWidget {
  const ProfilePage({Key? key}) : super(key: key);

  @override
  State<ProfilePage> createState() => _ProfilePageState();
}

class _ProfilePageState extends State<ProfilePage> {
  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    return Scaffold(
      backgroundColor: primaryColor,
      body: getBodyProfile(size),
    );
  }

  Widget getBodyProfile(size) {
    return ListView(
        scrollDirection: Axis.vertical,
        physics: BouncingScrollPhysics(),
        children: [
          Stack(children: [
            Positioned(
              child: GetHeaderProfile(),
            ),
            Padding(
              padding: EdgeInsets.only(top: size.height / 5 - 15),
              child: GetBodyProfile(),
            ),
          ])
        ]);
  }
}
