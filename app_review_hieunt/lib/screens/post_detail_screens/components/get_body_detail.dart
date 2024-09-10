import 'package:app_review_hieunt/models/comment_model.dart';
import 'package:app_review_hieunt/screens/review_screens/components/get_post_review.dart';
import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:app_review_hieunt/utilities/data.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

import '../../../models/post_model.dart';

class GetBodyDetail extends StatefulWidget {
  int index;
  GetBodyDetail({Key? key, required this.index}) : super(key: key);

  @override
  State<GetBodyDetail> createState() => _GetBodyDetailState();
}

class _GetBodyDetailState extends State<GetBodyDetail> {
  // List<Widget> testComments = [];
  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    // List tmpListComments = [];
    // getComments(listComments, 0, 0, 0, tmpListComments);
    // print(testComments.length);
    return Stack(children: [
      Column(
        children: [
          Container(
            width: size.width,
            padding: EdgeInsets.all(20),
            decoration: BoxDecoration(
                borderRadius: BorderRadius.only(
                    topLeft: Radius.circular(20),
                    topRight: Radius.circular(20)),
                color: Colors.white),
            child: GetPostReview(index: widget.index, checkCustom: true),
          ),
          getComments(size),
          // Container(
          //   padding: EdgeInsets.fromLTRB(20, 5, 20, 10),
          //   decoration: BoxDecoration(color: Colors.white),
          //   child: Column(
          //       children:
          //           (testComments == null) ? [Text("ERROR")] : testComments),
          // )
        ],
      )
    ]);
  }

  Widget getComments(size) {
    return Container(
      // height: size.height,
      decoration: BoxDecoration(color: Colors.white),
      child: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(20.0),
            child: Row(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Container(
                  height: 30,
                  width: 30,
                  decoration: BoxDecoration(
                      shape: BoxShape.circle,
                      image: DecorationImage(
                          image: NetworkImage(comment1.user.getAvatarUrl),
                          fit: BoxFit.cover)),
                ),
                SizedBox(width: 10),
                Expanded(
                  child: Container(
                    decoration: BoxDecoration(
                        color: Colors.white,
                        boxShadow: [
                          BoxShadow(
                              color: Colors.black12,
                              blurRadius: 10,
                              spreadRadius: 1)
                        ],
                        borderRadius: BorderRadius.only(
                            topLeft: Radius.circular(5),
                            bottomLeft: Radius.circular(15),
                            bottomRight: Radius.circular(15),
                            topRight: Radius.circular(15))),
                    child: Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Text(comment1.user.getName,
                              style: TextStyle(fontWeight: FontWeight.bold)),
                          SizedBox(height: 5),
                          Text(
                            comment1.context,
                          ),
                          SizedBox(height: 7),
                          Row(
                            children: [
                              Text(comment1.time,
                                  style: TextStyle(
                                      color: Colors.black54, fontSize: 12)),
                              SizedBox(width: 7),
                              Text("Like",
                                  style: TextStyle(
                                      color: Colors.black54,
                                      fontSize: 12,
                                      fontWeight: FontWeight.bold)),
                              SizedBox(width: 7),
                              Text("Reply",
                                  style: TextStyle(
                                      color: Colors.black54,
                                      fontSize: 12,
                                      fontWeight: FontWeight.bold))
                            ],
                          ),
                          SizedBox(height: 7),
                          Row(
                            children: [
                              Container(
                                height: 30,
                                width: 30,
                                decoration: BoxDecoration(
                                    shape: BoxShape.circle,
                                    image: DecorationImage(
                                        image: NetworkImage(
                                            comment5.user.getAvatarUrl),
                                        fit: BoxFit.cover)),
                              ),
                              SizedBox(width: 7),
                              Text(comment5.user.getName,
                                  style:
                                      TextStyle(fontWeight: FontWeight.bold)),
                              SizedBox(width: 7),
                              Text(comment5.context),
                            ],
                          )
                        ],
                      ),
                    ),
                  ),
                )
              ],
            ),
          ),
          Padding(
            padding: const EdgeInsets.fromLTRB(20.0, 5, 20, 20),
            child: Row(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Container(
                  height: 30,
                  width: 30,
                  decoration: BoxDecoration(
                      shape: BoxShape.circle,
                      image: DecorationImage(
                          image: NetworkImage(comment3.user.getAvatarUrl),
                          fit: BoxFit.cover)),
                ),
                SizedBox(width: 10),
                Expanded(
                  child: Container(
                    decoration: BoxDecoration(
                        color: Colors.white,
                        boxShadow: [
                          BoxShadow(
                              color: Colors.black12,
                              blurRadius: 10,
                              spreadRadius: 1)
                        ],
                        borderRadius: BorderRadius.only(
                            topLeft: Radius.circular(5),
                            bottomLeft: Radius.circular(15),
                            bottomRight: Radius.circular(15),
                            topRight: Radius.circular(15))),
                    child: Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Text(comment3.user.getName,
                              style: TextStyle(fontWeight: FontWeight.bold)),
                          SizedBox(height: 5),
                          Text(
                            comment3.context,
                          ),
                          SizedBox(height: 7),
                          Row(
                            children: [
                              Text(comment3.time,
                                  style: TextStyle(
                                      color: Colors.black54, fontSize: 12)),
                              SizedBox(width: 7),
                              Text("Like",
                                  style: TextStyle(
                                      color: Colors.black54,
                                      fontSize: 12,
                                      fontWeight: FontWeight.bold)),
                              SizedBox(width: 7),
                              Text("Reply",
                                  style: TextStyle(
                                      color: Colors.black54,
                                      fontSize: 12,
                                      fontWeight: FontWeight.bold))
                            ],
                          ),
                          SizedBox(height: 7),
                          Row(
                            children: [
                              Container(
                                height: 30,
                                width: 30,
                                decoration: BoxDecoration(
                                    shape: BoxShape.circle,
                                    image: DecorationImage(
                                        image: NetworkImage(
                                            comment8.user.getAvatarUrl),
                                        fit: BoxFit.cover)),
                              ),
                              SizedBox(width: 7),
                              Text(comment8.user.getName,
                                  style:
                                      TextStyle(fontWeight: FontWeight.bold)),
                              SizedBox(width: 7),
                              Text(comment8.context),
                            ],
                          )
                        ],
                      ),
                    ),
                  ),
                )
              ],
            ),
          )
        ],
      ),
    );
  }

  // void getComments(baseCommentList, int baseParentID, int getBackID, int level,
  //     List childrenWigets) {
  //   if (baseCommentList.length == 0) {
  //     print("Da duyet het");
  //   } else {
  //     int check = 0;
  //     for (int i = 0; i < baseCommentList.length; i++) {
  //       if (baseCommentList[i].parentId == baseParentID) {
  //         check++;
  //         CommentModel checkedComment = baseCommentList[i];

  //         double marginWidget = 0;
  //         if (level > 0) {
  //           for (int j = 0; j < level; j++) {
  //             marginWidget = marginWidget + 30;
  //           }
  //         }
  //         testComments.add(Expanded(
  //           child: Row(
  //             children: [
  //               SizedBox(width: marginWidget),
  //               Container(
  //                 height: 30,
  //                 width: 30,
  //                 decoration: BoxDecoration(
  //                     shape: BoxShape.circle,
  //                     image: DecorationImage(
  //                         image: NetworkImage(checkedComment.user.getAvatarUrl),
  //                         fit: BoxFit.cover)),
  //               ),
  //               SizedBox(width: 5),
  //               Text(checkedComment.user.getName,
  //                   style: TextStyle(fontWeight: FontWeight.bold)),
  //               SizedBox(width: 5),
  //               Text(checkedComment.context),
  //             ],
  //           ),
  //         ));
  //         print("Added ${checkedComment.getInfo()}");
  //         // System.out.println(symbolLevel + menuList.get(i).getTitle());
  //         baseCommentList.remove(baseCommentList[i]);
  //         getComments(baseCommentList, checkedComment.id, baseParentID,
  //             level + 1, childrenWigets);
  //       }
  //     }
  //     if (check == 0) {
  //       int getBackID2 = 0;
  //       for (CommentModel comment in baseCommentList)
  //         if (comment.id == getBackID) getBackID2 = comment.parentId();

  //       getComments(
  //           baseCommentList, getBackID, getBackID2, level - 1, childrenWigets);
  //     }
  //   }
  // }
}
