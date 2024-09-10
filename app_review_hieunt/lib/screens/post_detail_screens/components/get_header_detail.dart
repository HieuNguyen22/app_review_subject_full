import 'package:app_review_hieunt/controllers/post_controller.dart';
import 'package:app_review_hieunt/models/post_model.dart';
import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:app_review_hieunt/utilities/data.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:get/get.dart';

class GetHeaderDetail extends StatelessWidget {
  var index;
  GetHeaderDetail({Key? key, required this.index}) : super(key: key);

  var postController = Get.put(PostController());

  List<PostModel> listPosts = [];
  List<PostModel> listPostsFavorite = [];
  List<PostModel> listPostsNew = [];

  @override
  Widget build(BuildContext context) {
    listPosts = postController.listPosts.value;
    listPostsFavorite = postController.listPostsFavorite.value;
    listPostsNew = postController.listPostsNew.value;
    var user = listPosts[index].getUser;
    return Container(
        height: 80,
        padding: EdgeInsets.fromLTRB(20, 15, 15, 15),
        decoration: BoxDecoration(
          color: primaryColor,
        ),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Row(
              children: [
                GestureDetector(
                  onTap: () {
                    Navigator.of(context).pop();
                  },
                  child: Icon(
                    Icons.arrow_back_ios,
                    color: Colors.white,
                  ),
                ),
                SizedBox(width: 7),
                Container(
                  width: 50,
                  height: 50,
                  decoration: BoxDecoration(
                      border: Border.all(width: 1, color: primaryLightColor),
                      shape: BoxShape.circle,
                      image: DecorationImage(
                          image: NetworkImage(user.getAvatarUrl),
                          fit: BoxFit.cover)),
                ),
                SizedBox(width: 7),
                Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      "${user.getName}",
                      style: TextStyle(
                          color: Colors.white, fontWeight: FontWeight.bold),
                    ),
                    Text(
                      "${post1.getTime}",
                      style: TextStyle(fontSize: 12, color: Colors.white60),
                    ),
                  ],
                )
              ],
            ),
            Icon(
              Icons.more_horiz,
              color: Colors.white60,
            )
          ],
        ));
  }
}
