import 'package:app_review_hieunt/models/user_model.dart';

class NotificationModel {
  final UserModel userSend;
  final String type;
  final String time;

  NotificationModel(this.userSend, this.type, this.time);

  get getUserSend => this.userSend;

  get getType => this.type;

  get getTime => this.time;
}
