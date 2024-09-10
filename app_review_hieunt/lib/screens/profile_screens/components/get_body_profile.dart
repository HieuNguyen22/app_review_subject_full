import 'package:app_review_hieunt/screens/review_screens/components/get_post_review.dart';
import 'package:app_review_hieunt/utilities/data.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

class GetBodyProfile extends StatefulWidget {
  const GetBodyProfile({Key? key}) : super(key: key);

  @override
  State<GetBodyProfile> createState() => _GetBodyProfileState();
}

class _GetBodyProfileState extends State<GetBodyProfile> {
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
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          SizedBox(height: 7),
          Text("${userHieu.getName}",
              style: TextStyle(
                  fontWeight: FontWeight.bold,
                  color: Colors.black.withOpacity(0.8),
                  fontSize: 22)),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 15, vertical: 15),
            child: Text("${userHieu.getDescribe}",
                textAlign: TextAlign.center,
                style: TextStyle(
                    color: Colors.black.withOpacity(0.4), fontSize: 15)),
          ),
          SizedBox(height: 10),
          getFollowerNum(),
          Divider(),
          SizedBox(height: 5),
          Padding(
            padding: const EdgeInsets.symmetric(vertical: 20),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                RichText(
                    text: TextSpan(children: [
                  TextSpan(
                      text: "My Reviews",
                      style: TextStyle(
                          fontWeight: FontWeight.bold,
                          fontSize: 18,
                          color: Colors.black)),
                  TextSpan(
                      text: " (683)",
                      style: TextStyle(fontSize: 12, color: Colors.black))
                ])),
              ],
            ),
          ),
          getMyReviews(),
          SizedBox(height: 40),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              RichText(
                  text: TextSpan(children: [
                TextSpan(
                    text: "My Followers",
                    style: TextStyle(
                        fontWeight: FontWeight.bold,
                        fontSize: 18,
                        color: Colors.black)),
                TextSpan(
                    text: " (${userHieu.getFollowerNum})",
                    style: TextStyle(fontSize: 12, color: Colors.black))
              ])),
            ],
          ),
          SizedBox(height: 20),
          getMyFollowers(listUsers),
          SizedBox(height: 40),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              RichText(
                  text: TextSpan(children: [
                TextSpan(
                    text: "My Following",
                    style: TextStyle(
                        fontWeight: FontWeight.bold,
                        fontSize: 18,
                        color: Colors.black)),
                TextSpan(
                    text: " (${userHieu.getFollowingNum})",
                    style: TextStyle(fontSize: 12, color: Colors.black))
              ])),
            ],
          ),
          SizedBox(height: 20),
          getMyFollowers(listUsers.reversed.toList()),
          SizedBox(height: 40),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              RichText(
                  text: TextSpan(children: [
                TextSpan(
                    text: "Media",
                    style: TextStyle(
                        fontWeight: FontWeight.bold,
                        fontSize: 18,
                        color: Colors.black)),
                TextSpan(
                    text: " (${userHieu.getFollowingNum})",
                    style: TextStyle(fontSize: 12, color: Colors.black))
              ])),
            ],
          ),
          SizedBox(height: 20),
          getMyMedia(),
          SizedBox(height: 40)
        ],
      ),
    );
  }

  Widget getFollowerNum() {
    return Container(
      height: 60,
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          Column(
            children: [
              Text(userHieu.getFollowerNum.toString(),
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 30)),
              Text("Followers",
                  style: TextStyle(
                      fontWeight: FontWeight.bold,
                      fontSize: 17,
                      color: Colors.black26))
            ],
          ),
          VerticalDivider(),
          Column(
            children: [
              Text(userHieu.getFollowingNum.toString(),
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 30)),
              Text("Following",
                  style: TextStyle(
                      fontWeight: FontWeight.bold,
                      fontSize: 17,
                      color: Colors.black26))
            ],
          )
        ],
      ),
    );
  }

  Widget getMyReviews() {
    return GetPostReview(index: 0, checkCustom: false);
  }

  Widget getMyFollowers(list) {
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 10),
      decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.circular(12),
          boxShadow: [
            BoxShadow(color: Colors.black12, blurRadius: 10, spreadRadius: 1)
          ]),
      child: SingleChildScrollView(
        scrollDirection: Axis.horizontal,
        child: Row(
            children: List.generate(list.length, (index) {
          return Column(
            children: [
              Padding(
                padding: const EdgeInsets.fromLTRB(5, 15, 15, 10),
                child: Column(
                  children: [
                    Container(
                      height: 50,
                      width: 50,
                      decoration: BoxDecoration(
                          shape: BoxShape.circle,
                          image: DecorationImage(
                              image: NetworkImage(list[index].getAvatarUrl),
                              fit: BoxFit.cover)),
                    ),
                    SizedBox(height: 5),
                    Text(
                      list[index].getName,
                      style: TextStyle(fontSize: 12, color: Colors.black87),
                    )
                  ],
                ),
              )
            ],
          );
        })),
      ),
    );
  }

  Widget getMyMedia() {
    var post = post1;
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 10, vertical: 10),
      decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.circular(12),
          boxShadow: [
            BoxShadow(color: Colors.black12, blurRadius: 10, spreadRadius: 1)
          ]),
      child: SingleChildScrollView(
          scrollDirection: Axis.horizontal,
          padding: EdgeInsets.only(left: 5, right: 5),
          child: Row(
              children: List.generate(post.getImgList.length, (index) {
            return Padding(
                padding: const EdgeInsets.fromLTRB(1.0, 2.0, 10.0, 2.0),
                child: GestureDetector(
                    onTap: () {},
                    child: Container(
                        width: 100,
                        height: 100,
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(12),
                          image: DecorationImage(
                              fit: BoxFit.cover,
                              image: NetworkImage(post.getImgList[index])),
                        ))));
          }))),
    );
  }
}
