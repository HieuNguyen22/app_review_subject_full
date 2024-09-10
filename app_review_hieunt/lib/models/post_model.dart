import 'package:app_review_hieunt/models/user_model.dart';

class PostModel {
  final int id;
  final UserModel user;
  final String time;
  final String title;
  final double rating;
  final String content;
  final List imgList;
  final String category;
  final String location;
  final int numLikes;
  final int numUnlikes;
  final int numComments;
  final int numShares;

  PostModel(
      this.id,
      this.user,
      this.time,
      this.title,
      this.rating,
      this.content,
      this.imgList,
      this.category,
      this.location,
      this.numLikes,
      this.numUnlikes,
      this.numComments,
      this.numShares);

  get getId => this.id;

  get getUser => this.user;

  get getTime => this.time;

  get getTitle => this.title;

  get getRating => this.rating;

  get getContent => this.content;

  get getImgList => this.imgList;

  get getCategory => this.category;

  get getLocation => this.location;

  get getNumLikes => this.numLikes;

  get getNumUnlikes => this.numUnlikes;

  get getNumComments => this.numComments;

  get getNumShares => this.numShares;
}
