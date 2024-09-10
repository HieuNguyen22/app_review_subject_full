import 'package:app_review_hieunt/models/user_model.dart';

class CommentModel {
  int _id;
  int _parentId;
  UserModel _user;
  String _context;
  String _time;

  CommentModel(this._id, this._parentId, this._user, this._context, this._time);

  get id => this._id;

  set id(value) => this._id = value;

  get parentId => this._parentId;

  set parentId(value) => this._parentId = value;

  get user => this._user;

  set user(value) => this._user = value;

  get context => this._context;

  set context(value) => this._context = value;

  get time => this._time;

  set time(value) => this._time = value;

  String getInfo() {
    return "${this._id} - ${this._parentId} - ${this._user.getName} - ${this._context}";
  }
}
