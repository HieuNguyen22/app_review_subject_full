import 'package:app_review_hieunt/screens/write_screens/components/get_form_write.dart';
import 'package:app_review_hieunt/screens/write_screens/components/get_header_write.dart';
import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';

class WritePage extends StatefulWidget {
  const WritePage({Key? key}) : super(key: key);

  @override
  State<WritePage> createState() => _WritePageState();
}

class _WritePageState extends State<WritePage> {
  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    return Scaffold(
      backgroundColor: primaryColor,
      body: getBodyWrite(size),
    );
  }

  Widget getBodyWrite(size) {
    return ListView(
        scrollDirection: Axis.vertical,
        physics: BouncingScrollPhysics(),
        children: [GetHeaderWrite(), GetFormWrite()]);
  }
}
