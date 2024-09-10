class RestaurantModel {
  final int id;
  final String name;
  final String location;
  final String imgUrl;
  final double rate;
  final String type;

  RestaurantModel(
      {required this.id,
      required this.name,
      required this.location,
      required this.imgUrl,
      required this.rate,
      required this.type});
}
