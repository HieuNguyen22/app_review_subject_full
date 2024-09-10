class UserModel {
  final int id;
  final String name;
  final String describe;
  final String avatarUrl;
  final String bgUrl;
  final int followerNum;
  final int followingNum;

  UserModel(this.id, this.name, this.describe, this.avatarUrl, this.bgUrl,
      this.followerNum, this.followingNum);

  get getId => this.id;

  get getName => this.name;

  get getDescribe => this.describe;

  get getAvatarUrl => this.avatarUrl;

  get getBgUrl => this.bgUrl;

  get getFollowerNum => this.followerNum;

  get getFollowingNum => this.followingNum;
}
