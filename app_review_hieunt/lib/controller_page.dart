import 'package:app_review_hieunt/screens/notification_screens/notification_page.dart';
import 'package:app_review_hieunt/screens/profile_screens/profile_page.dart';
import 'package:app_review_hieunt/screens/review_screens/review_page.dart';
import 'package:app_review_hieunt/screens/search_screens/search_page.dart';
import 'package:app_review_hieunt/screens/write_screens/write_page.dart';
import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:convex_bottom_bar/convex_bottom_bar.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

class ControllerPage extends StatefulWidget {
  final int index;

  const ControllerPage({Key? key, required this.index}) : super(key: key);

  @override
  State<ControllerPage> createState() => _ControllerPageState(index);
}

class _ControllerPageState extends State<ControllerPage> {
  int indexPage;

  _ControllerPageState(this.indexPage);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: getBody(),
      bottomNavigationBar: getConvexAppBar(),
    );
  }

  Widget getBody() {
    return IndexedStack(
      index: indexPage,
      children: [
        ReviewPage(),
        SearchPage(),
        WritePage(),
        NotificationPage(),
        ProfilePage()
      ],
    );
  }

  void _onItemTapped(int index) {
    setState(() {
      indexPage = index;
    });
  }

  Widget getConvexAppBar(){
    return Container(
      decoration: BoxDecoration(
        borderRadius: BorderRadius.only(
          topLeft: Radius.circular(30),
          topRight: Radius.circular(30)
        ),
        color: primaryColor,
        boxShadow: [
          BoxShadow(
            color: Colors.black12, spreadRadius: 1, blurRadius: 10
          )
        ]
      ),
      child: ConvexAppBar(
        backgroundColor: Colors.white,
        activeColor: primaryColor,
        color: primaryLightColor,
        // style: TabStyle.fixedCircle,
        
        items: [
          TabItem(icon: Icons.list_alt),
          TabItem(icon: Icons.search),
          TabItem(icon: Icons.edit),
          TabItem(icon: Icons.notifications),
          TabItem(icon: Icons.person)
        ],
        initialActiveIndex: 0,
        onTap: _onItemTapped,
      ),
    );
  }
}
