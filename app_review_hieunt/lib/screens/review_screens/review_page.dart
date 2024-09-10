import 'package:app_review_hieunt/controllers/post_controller.dart';
import 'package:app_review_hieunt/models/restaurant_model.dart';
import 'package:app_review_hieunt/screens/review_screens/components/banner_slider.dart';
import 'package:app_review_hieunt/screens/review_screens/components/get_header_review.dart';
import 'package:app_review_hieunt/screens/review_screens/components/get_post_review.dart';
import 'package:app_review_hieunt/utilities/constants.dart';
import 'package:app_review_hieunt/utilities/data.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:get/get.dart';

class ReviewPage extends StatefulWidget {
  const ReviewPage({Key? key}) : super(key: key);

  @override
  State<ReviewPage> createState() => _ReviewPageState();
}

class _ReviewPageState extends State<ReviewPage> {
  var postController = Get.put(PostController());

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: primaryColor,
      body: getBodyReview(),
    );
  }

  Widget getBodyReview() {
    List listPosts = postController.listPosts.value;
    List listPostsFavorite = postController.listPostsFavorite.value;
    List listPostsNew = postController.listPostsNew.value;
    return Padding(
        padding: EdgeInsets.only(left: 10, right: 10, top: 20),
        child: ListView(
          scrollDirection: Axis.vertical,
          physics: BouncingScrollPhysics(),
          children: [
            Container(child: GetHeaderReview()),
            SizedBox(height: 30),
            BannerSlider(imgList: imgListBanner),
            SizedBox(height: 35),
            Padding(
              padding: const EdgeInsets.only(left: 10.0, right: 10),
              child: Text('New Restaurants',
                  style: TextStyle(
                      color: Colors.white,
                      fontWeight: FontWeight.bold,
                      fontSize: 22)),
            ),
            SizedBox(height: 15),
            Wrap(
                direction: Axis.horizontal,
                spacing: 10,
                runSpacing: 10,
                children: List.generate(listPostsNew.length, (index) {
                  int position = listPostsFavorite[index].getId - 1;
                  return GetPostReview(index: position, checkCustom: false);
                })),
            SizedBox(height: 10),
            Divider(
              color: Colors.white38,
            ),
            SizedBox(height: 25),
            Padding(
              padding: const EdgeInsets.only(right: 10.0, left: 10),
              child: Text('Favorite Restaurants',
                  style: TextStyle(
                      color: Colors.white,
                      fontWeight: FontWeight.bold,
                      fontSize: 22)),
            ),
            SizedBox(height: 15),
            Wrap(
                direction: Axis.horizontal,
                spacing: 10,
                runSpacing: 10,
                children: List.generate(listPostsFavorite.length, (index) {
                  int position = listPostsNew[index].getId - 1;
                  return GetPostReview(index: position, checkCustom: false);
                })),
            SizedBox(height: 10),
            Divider(
              color: Colors.white38,
            ),
            Padding(
              padding: const EdgeInsets.only(right: 10.0, left: 10),
              child: Text('Recommend For You',
                  style: TextStyle(
                      color: Colors.white,
                      fontWeight: FontWeight.bold,
                      fontSize: 22)),
            ),
            SizedBox(height: 15),
            SingleChildScrollView(
              scrollDirection: Axis.horizontal,
              child: Row(
                children: List.generate(listRestaurants.length, (index) {
                  RestaurantModel restaurant = listRestaurants[index];
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
                              color: Colors.black12,
                              blurRadius: 10,
                              spreadRadius: 1)
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
                            textAlign: TextAlign.center,
                            maxLines: 2,
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
            ),
            SizedBox(height: 40)
          ],
        ));
  }
}
