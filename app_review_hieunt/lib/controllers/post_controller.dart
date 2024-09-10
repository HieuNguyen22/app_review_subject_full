import 'package:app_review_hieunt/models/post_model.dart';
import 'package:app_review_hieunt/utilities/data.dart';
import 'package:geolocator/geolocator.dart';
import 'package:get/get.dart';

class PostController extends GetxController {
  RxList<PostModel> listPosts = [post1, post2, post3, post4, post5, post6].obs;
  RxList<PostModel> listPostsFavorite = [post1, post2, post3].obs;
  RxList<PostModel> listPostsNew = [post4, post5, post6].obs;
}
