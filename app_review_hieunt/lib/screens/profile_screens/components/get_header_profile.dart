import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:app_review_hieunt/utilities/data.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

class GetHeaderProfile extends StatelessWidget {
  const GetHeaderProfile({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    return Stack(children: [
      Container(
          alignment: Alignment.center,
          height: size.height / 5,
          padding: EdgeInsets.only(top: 30, left: 15, right: 15, bottom: 15),
          decoration: BoxDecoration(
              color: primaryColor,
              image: DecorationImage(
                  fit: BoxFit.cover, image: NetworkImage(userHieu.getBgUrl))),
          child: Container(
            width: 95,
            height: 95,
            decoration: BoxDecoration(
                shape: BoxShape.circle,
                border: Border.all(color: Colors.white, width: 2),
                image: DecorationImage(
                    image: NetworkImage(userHieu.getAvatarUrl),
                    fit: BoxFit.cover)),
          )),
      Visibility(
        visible: false,
        child: Positioned(
          top: 20,
          right: 20,
            child: Icon(
          Icons.edit,
          color: Colors.white,
          size: 30,
        )),
      )
    ]);
  }
}
