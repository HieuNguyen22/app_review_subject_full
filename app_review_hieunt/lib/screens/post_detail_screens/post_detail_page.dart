import 'package:app_review_hieunt/screens/post_detail_screens/components/get_body_detail.dart';
import 'package:app_review_hieunt/screens/post_detail_screens/components/get_header_detail.dart';
import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

class PostDetailPage extends StatefulWidget {
  int index;
  PostDetailPage({Key? key, required this.index}) : super(key: key);

  @override
  State<PostDetailPage> createState() => _PostDetailPageState();
}

class _PostDetailPageState extends State<PostDetailPage> {
  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    return Scaffold(
      backgroundColor: primaryColor,
      body: getBodyDetail(size),
    );
  }

  Widget getBodyDetail(size) {
    return Column(
      children: [
        Expanded(
          child: ListView(scrollDirection: Axis.vertical, children: [
            GetHeaderDetail(index: widget.index),
            GetBodyDetail(index: widget.index),
          ]),
        ),
        getBoxChat()
      ],
    );
  }

  Widget getBoxChat() {
    return Container(
      padding: EdgeInsets.fromLTRB(10, 10, 10, 10),
      decoration: BoxDecoration(color: Colors.white, boxShadow: [
        BoxShadow(color: Colors.black12, blurRadius: 10, spreadRadius: 1)
      ]),
      child: TextFormField(
        textInputAction: TextInputAction.done,
        cursorColor: primaryColor,
        decoration: InputDecoration(
            filled: true,
            fillColor: Colors.white,
            // iconColor: Colors.black,
            prefixIconColor: Colors.black,
            contentPadding: EdgeInsets.symmetric(horizontal: 5, vertical: 5),
            border: OutlineInputBorder(
              borderRadius: BorderRadius.all(Radius.circular(0)),
              borderSide: BorderSide.none,
            ),
            prefixIcon: Icon(
              Icons.image,
              color: Colors.black54,
            ),
            suffixIcon: Container(
              margin: EdgeInsets.all(5),
              width: 14,
              decoration: BoxDecoration(
                image: DecorationImage(
                    fit: BoxFit.cover,
                    image: AssetImage("assets/ic_send.png")),
              ),
            ),
            hintText: "Write comment here..."),
      ),
    );
  }
}
