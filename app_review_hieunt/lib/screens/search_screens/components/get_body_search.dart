import 'package:app_review_hieunt/controllers/post_controller.dart';
import 'package:app_review_hieunt/models/post_model.dart';
import 'package:app_review_hieunt/models/restaurant_model.dart';
import 'package:app_review_hieunt/screens/post_detail_screens/post_detail_page.dart';
import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:app_review_hieunt/utilities/data.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:flutter_staggered_grid_view/flutter_staggered_grid_view.dart';
import 'package:get/get.dart';

class GetBodySearch extends StatefulWidget {
  const GetBodySearch({Key? key}) : super(key: key);

  @override
  State<GetBodySearch> createState() => _GetBodySearchState();
}

class _GetBodySearchState extends State<GetBodySearch> {
  List<PostModel> _foundPosts = [];
  final textController = TextEditingController();

  var postController = Get.put(PostController());

  List<PostModel> listPosts = [];
  List<PostModel> listPostsFavorite = [];
  List<PostModel> listPostsNew = [];

  @override
  void initState() {
    listPosts = postController.listPosts.value;
    listPostsFavorite = postController.listPostsFavorite.value;
    listPostsNew = postController.listPostsNew.value;

    _foundPosts = listPosts;
    super.initState();
  }

  @override
  void dispose() {
    textController.dispose();
    super.dispose();
  }

  void _runFilter(String keyword) {
    List<PostModel> results = [];
    if (keyword.isEmpty) {
      results = listPosts;
    } else {
      results = listPosts
          .where((post) => post.getTitle
              .toString()
              .toLowerCase()
              .contains(keyword.toLowerCase()))
          .toList();
    }

    setState(() {
      _foundPosts = results;
    });
  }

  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;

    return Padding(
      padding: const EdgeInsets.only(left: 10.0, right: 10),
      child: ListView(scrollDirection: Axis.vertical, children: [
        Container(
            // height: 80,
            padding: EdgeInsets.only(top: 30, left: 0, right: 0, bottom: 15),
            decoration: BoxDecoration(
              color: primaryColor,
            ),
            child: Column(
              children: [
                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 10),
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Text(
                        "Search",
                        style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.bold,
                            fontSize: 37),
                      ),
                      Icon(
                        Icons.tune,
                        color: Colors.white.withOpacity(0.5),
                        size: 30,
                      )
                    ],
                  ),
                ),
                SizedBox(height: 30),
                TextFormField(
                  controller: textController,
                  textInputAction: TextInputAction.done,
                  cursorColor: primaryColor,
                  decoration: InputDecoration(
                      filled: true,
                      fillColor: Colors.white,
                      // iconColor: Colors.black,
                      prefixIconColor: Colors.black,
                      contentPadding:
                          EdgeInsets.symmetric(horizontal: 5, vertical: 5),
                      border: OutlineInputBorder(
                        borderRadius: BorderRadius.all(Radius.circular(30)),
                        borderSide: BorderSide.none,
                      ),
                      prefixIcon: Icon(
                        Icons.search,
                        color: Colors.black,
                      ),
                      suffixIcon: GestureDetector(
                        onTap: () {
                          return _runFilter(textController.text);
                        },
                        child: Icon(
                          Icons.arrow_forward_ios,
                          color: Colors.black54,
                          size: 18,
                        ),
                      ),
                      hintText: "Type your keyword"),
                ),
                SizedBox(height: 15),
              ],
            )),
        Container(
            margin: EdgeInsets.only(bottom: 20),
            width: size.width,
            // height: size.height,
            padding: EdgeInsets.only(top: 20, bottom: 20, left: 10, right: 10),
            decoration: BoxDecoration(
                borderRadius: BorderRadius.only(
                    topLeft: Radius.circular(20),
                    topRight: Radius.circular(20),
                    bottomLeft: Radius.circular(20),
                    bottomRight: Radius.circular(20)),
                color: Colors.white),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Column(children: getChildrenWidgets(size, false)),
                Column(children: getChildrenWidgets(size, true)),
              ],
            )),
        Padding(
          padding:
              const EdgeInsets.only(right: 10.0, left: 10, bottom: 15, top: 10),
          child: Text('Most Searched',
              style: TextStyle(
                  color: Colors.white,
                  fontWeight: FontWeight.bold,
                  fontSize: 22)),
        ),
        getRecommendRestaurant(),
        SizedBox(height: 35)
      ]),
    );
  }

  Widget getRecommendRestaurant() {
    List reversedList = listRestaurants.reversed.toList();
    return SingleChildScrollView(
      scrollDirection: Axis.horizontal,
      child: Row(
        children: List.generate(reversedList.length, (index) {
          RestaurantModel restaurant = reversedList[index];
          return Container(
            width: 220,
            // height: 200,
            margin: EdgeInsets.only(right: 10),
            padding: EdgeInsets.fromLTRB(10, 10, 10, 10),
            decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(20),
                boxShadow: [
                  BoxShadow(
                      color: Colors.black12, blurRadius: 10, spreadRadius: 1)
                ]),
            child: Column(
              children: [
                Container(
                    height: 120,
                    width: 200,
                    decoration: BoxDecoration(
                      borderRadius: BorderRadius.circular(5),
                      image: DecorationImage(
                          fit: BoxFit.cover,
                          image: NetworkImage(restaurant.imgUrl)),
                    )),
                SizedBox(height: 5),
                Text(restaurant.name,
                    style: TextStyle(
                        color: Colors.black.withOpacity(0.8),
                        fontWeight: FontWeight.bold,
                        fontSize: 18)),
                SizedBox(height: 5),
                Text(restaurant.location,
                    style: TextStyle(
                        overflow: TextOverflow.ellipsis,
                        color: Colors.black.withOpacity(0.8),
                        fontSize: 14)),
                SizedBox(height: 5),
                RatingBar.builder(
                  ignoreGestures: true,
                  itemSize: 20,
                  initialRating: restaurant.rate,
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
              ],
            ),
          );
        }),
      ),
    );
  }

  List<Widget> getChildrenWidgets(size, isOdd) {
    List<Widget> listWidgets = [];
    listWidgets.add(getTextWidget(size));
    listWidgets.addAll(List.generate(_foundPosts.length, (index) {
      int position = _foundPosts[index].getId - 1;
      return Padding(
        padding: const EdgeInsets.only(bottom: 25.0),
        child: GestureDetector(
          onTap: () {
            Navigator.of(context).push(MaterialPageRoute(
                builder: (_) => PostDetailPage(index: position)));
          },
          child: Container(
            // height: size.width / 2 + 20,
            width: size.width / 2 - 28,
            decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(18),
                boxShadow: [
                  BoxShadow(
                      color: Colors.black12, blurRadius: 10, spreadRadius: 1)
                ]),
            child: getContextPost(position, size),
          ),
        ),
      );
    }));

    List<Widget> listWidgetsReturn = [];
    if (isOdd) {
      for (int i = 0; i < listWidgets.length; i++) {
        if (i % 2 == 1) {
          listWidgetsReturn.add(listWidgets[i]);
        }
      }
    } else {
      for (int i = 0; i < listWidgets.length; i++) {
        if (i % 2 == 0) {
          listWidgetsReturn.add(listWidgets[i]);
        }
      }
    }

    return listWidgetsReturn;
  }

  Widget getTextWidget(size) {
    List<PostModel> results = [];
    results = listPosts
        .where((post) => post.getTitle
            .toString()
            .toLowerCase()
            .contains(textController.text))
        .toList();
    return (!results.isEmpty)
        ? Container(
            // height: size.width / 2 + 20,
            width: (size.width - 100) / 2,
            margin: EdgeInsets.only(bottom: 20),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Icon(
                  Icons.sort,
                  size: 40,
                  color: Colors.black54,
                ),
                SizedBox(
                  height: 10,
                ),
                Text(
                  "Found\n${_foundPosts.length} Results",
                  style: TextStyle(
                      color: Colors.black54,
                      fontWeight: FontWeight.bold,
                      fontSize: 33),
                ),
              ],
            ),
          )
        : Container(
            // height: size.width / 2 + 20,
            // width: (size.width - 100) / 2,
            margin: EdgeInsets.only(bottom: 20, left: 20),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Icon(
                  Icons.sort,
                  size: 40,
                  color: Colors.black54,
                ),
                SizedBox(
                  height: 10,
                ),
                Text(
                  "No Results Founded",
                  style: TextStyle(
                      color: Colors.black54,
                      fontWeight: FontWeight.bold,
                      fontSize: 33),
                ),
              ],
            ),
          );
  }

  Widget getContextPost(index, size) {
    var post = listPosts[index];
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 8.0, vertical: 8),
      child: Column(
        children: [
          Container(
            height: size.width / 2 - 50,
            width: size.width / 2 - 30,
            decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10),
                image: DecorationImage(
                    image: NetworkImage(post.getImgList[0]),
                    fit: BoxFit.cover)),
          ),
          SizedBox(height: 5),
          Text(
            post.getTitle,
            maxLines: 2,
            // 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa',
            style: TextStyle(
                color: Colors.black87,
                fontWeight: FontWeight.bold,
                overflow: TextOverflow.ellipsis),
          ),
          SizedBox(height: 5),
          RatingBar.builder(
            ignoreGestures: true,
            itemSize: 20,
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
          SizedBox(height: 5),
          Text(
            post.getLocation,
            maxLines: 2,
            overflow: TextOverflow.ellipsis,
            style: TextStyle(
                color: Colors.black87,
                fontSize: 12,
                overflow: TextOverflow.ellipsis),
          ),
          SizedBox(height: 5),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text(post.getUser.getName,
                  style: TextStyle(
                      color: Colors.black.withOpacity(0.8),
                      fontWeight: FontWeight.bold,
                      fontSize: 12)),
              SizedBox(width: 8),
              Container(
                  width: 27,
                  height: 27,
                  decoration: BoxDecoration(
                    border: Border.all(color: Colors.black45),
                    shape: BoxShape.circle,
                    image: DecorationImage(
                        fit: BoxFit.cover,
                        image: NetworkImage(post.getUser.getAvatarUrl)),
                  ))
            ],
          ),
          SizedBox(height: 2),
        ],
      ),
    );
  }
}
