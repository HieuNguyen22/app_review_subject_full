import 'package:app_review_hieunt/controllers/post_controller.dart';
import 'package:app_review_hieunt/models/post_model.dart';
import 'package:app_review_hieunt/models/user_model.dart';
import 'package:app_review_hieunt/screens/post_detail_screens/post_detail_page.dart';
import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:app_review_hieunt/utilities/data.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:get/get.dart';

class GetPostReview extends StatefulWidget {
  int index;
  bool checkCustom;
  GetPostReview({Key? key, required this.index, required this.checkCustom})
      : super(key: key);

  @override
  State<GetPostReview> createState() => _GetPostReviewState(index);
}

class _GetPostReviewState extends State<GetPostReview> {
  int index;
  var postController = Get.put(PostController());

  List listPosts = [];
  List listPostsFavorite = [];
  List listPostsNew = [];

  _GetPostReviewState(this.index);

  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    listPosts = postController.listPosts.value;
    listPostsFavorite =
        listPosts.sublist(listPosts.length ~/ 2 + 1, listPosts.length - 1);
    listPostsNew = listPosts.sublist(0, listPosts.length ~/ 2);

    PostModel post = listPosts[index];
    return (widget.checkCustom == false)
        ? getOriginalPost(size)
        : Column(
            children: [
              getPostDetail(index),
            ],
          );
  }

  Widget getOriginalPost(size) {
    return GestureDetector(
      onTap: () {
        Navigator.of(context).push(
            MaterialPageRoute(builder: (_) => PostDetailPage(index: index)));
      },
      child: Container(
        width: size.width - 20,
        padding: EdgeInsets.fromLTRB(15, 10, 15, 10),
        margin: EdgeInsets.only(bottom: 5),
        decoration: BoxDecoration(
            color: Colors.white,
            borderRadius: BorderRadius.all(
              Radius.circular(20),
            ),
            boxShadow: [
              BoxShadow(
                color: Colors.black12,
                spreadRadius: 1,
                blurRadius: 10,
              ),
            ]),
        child: Column(
          children: [
            getPostUser(index),
            Divider(),
            SizedBox(height: 5),
            getPostDetail(index),
          ],
        ),
      ),
    );
  }

  Widget getPostUser(index) {
    PostModel post = listPosts[index];
    UserModel user = post.getUser;
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Row(
          children: [
            Container(
              width: 50,
              height: 50,
              decoration: BoxDecoration(
                  shape: BoxShape.circle,
                  image: DecorationImage(
                      image: NetworkImage(user.getAvatarUrl),
                      fit: BoxFit.cover)),
            ),
            SizedBox(width: 15),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  "${user.getName}",
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 17),
                ),
                Text(
                  "${post.getTime}",
                  style: TextStyle(color: Colors.black.withOpacity(0.5)),
                )
              ],
            ),
          ],
        ),
        Icon(Icons.more_horiz, color: Colors.black.withOpacity(0.5))
      ],
    );
  }

  Widget getPostDetail(index) {
    PostModel post = listPosts[index];
    return Column(
      children: [
        Text(
          "${post.getTitle}",
          style: TextStyle(fontSize: 22, fontWeight: FontWeight.bold),
        ),
        SizedBox(height: 5),
        RatingBar.builder(
          ignoreGestures: true,
          itemSize: 40,
          initialRating: post.getRating,
          minRating: 1,
          direction: Axis.horizontal,
          allowHalfRating: true,
          itemCount: 5,
          itemPadding: EdgeInsets.symmetric(horizontal: 1.0),
          itemBuilder: (context, _) => Icon(
            Icons.star,
            color: Colors.amber,
          ),
          onRatingUpdate: (rating) {
            print(rating);
          },
        ),
        SizedBox(height: 10),
        Text("${post.getContent}"),
        getListImages(post),
        SizedBox(height: 10),
        getLocation(post),
        SizedBox(height: 10),
        getReaction(post)
      ],
    );
  }

  Widget getListImages(post) {
    return SingleChildScrollView(
        scrollDirection: Axis.horizontal,
        padding: EdgeInsets.only(top: 15, left: 5, right: 5),
        child: Row(
            children: List.generate(post.getImgList.length, (index) {
          return Padding(
              padding: const EdgeInsets.fromLTRB(1.0, 2.0, 10.0, 2.0),
              child: GestureDetector(
                  onTap: () {},
                  child: Container(
                      width: 220,
                      height: 120,
                      decoration: BoxDecoration(
                        borderRadius: BorderRadius.circular(7),
                        image: DecorationImage(
                            fit: BoxFit.cover,
                            image: NetworkImage(post.getImgList[index])),
                      ))));
        })));
  }

  Widget getLocation(post) {
    return Container(
      padding: EdgeInsets.all(12),
      decoration: BoxDecoration(
          color: primaryColor.withOpacity(0.05),
          borderRadius: BorderRadius.circular(10)),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Flexible(
            flex: 2,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  "Category",
                  style: TextStyle(
                      color: Colors.black.withOpacity(0.8),
                      fontWeight: FontWeight.bold),
                ),
                SizedBox(height: 5),
                Text("${post.getCategory}",
                    style: TextStyle(color: Colors.black.withOpacity(0.8)))
              ],
            ),
          ),
          Flexible(
            flex: 3,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  "Address",
                  style: TextStyle(
                      color: Colors.black.withOpacity(0.8),
                      fontWeight: FontWeight.bold),
                ),
                SizedBox(height: 5),
                Text(
                  "${post.getLocation}",
                  style: TextStyle(
                      color: Colors.black.withOpacity(0.8),
                      overflow: TextOverflow.ellipsis),
                )
              ],
            ),
          )
        ],
      ),
    );
  }

  Widget getReaction(post) {
    return Padding(
      padding: const EdgeInsets.fromLTRB(20, 7, 20, 5),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Column(
            children: [
              Icon(Icons.thumb_up, color: primaryLightColor),
              SizedBox(height: 5),
              Text(
                "${post.getNumLikes}",
                style: TextStyle(color: primaryLightColor),
              )
            ],
          ),
          Column(
            children: [
              Icon(Icons.thumb_down, color: primaryLightColor),
              SizedBox(height: 5),
              Text("${post.getNumUnlikes}",
                  style: TextStyle(color: primaryLightColor))
            ],
          ),
          Column(
            children: [
              Icon(Icons.message, color: primaryLightColor),
              SizedBox(height: 5),
              Text("${post.getNumComments}",
                  style: TextStyle(color: primaryLightColor))
            ],
          ),
          Column(
            children: [
              Icon(Icons.share, color: primaryLightColor),
              SizedBox(height: 5),
              Text("${post.getNumShares}",
                  style: TextStyle(color: primaryLightColor))
            ],
          ),
        ],
      ),
    );
  }
}
