// ------------------------- USERS -----------------------------
import 'package:app_review_hieunt/models/comment_model.dart';
import 'package:app_review_hieunt/models/notification_model.dart';
import 'package:app_review_hieunt/models/restaurant_model.dart';
import 'package:app_review_hieunt/models/post_model.dart';
import 'package:app_review_hieunt/models/user_model.dart';

final UserModel userHieu = UserModel(
    1,
    "Hieu Nguyen",
    "Hey there! I'm using this app for rating & reviewing anything!",
    "https://static2.yan.vn/YanNews/2167221/202204/chrishemsworth-66af4d98.jpg",
    "https://images.pexels.com/photos/1323550/pexels-photo-1323550.jpeg?cs=srgb&dl=pexels-simon-berger-1323550.jpg&fm=jpg",
    223,
    312);
final UserModel userCuong = UserModel(
    2,
    "Cong Cuong",
    "Hey there! I'm using this app for rating & reviewing anything!",
    "https://images.mubicdn.net/images/cast_member/3071/cache-3195-1568084972/image-w856.jpg?size=800x",
    "https://images.pexels.com/photos/2101187/pexels-photo-2101187.jpeg?cs=srgb&dl=pexels-louis-2101187.jpg&fm=jpg",
    455,
    120);
final UserModel userTrang = UserModel(
    3,
    "Trang Phan",
    "Hey there! I'm using this app for rating & reviewing anything!",
    "https://2sao.vietnamnetjsc.vn/images/2021/11/24/17/15/lisa.jpg",
    "https://mobimg.b-cdn.net/v3/fetch/39/39d0b1af982cfaac50af7cd0fa9fc218.jpeg",
    276,
    128);
final UserModel userTien = UserModel(
    4,
    "The Tien",
    "Hey there! I'm using this app for rating & reviewing anything!",
    "https://upload.wikimedia.org/wikipedia/commons/b/bf/Timoth%C3%A9e_Chalamet_2017_Berlinale.jpg",
    "https://free4kwallpapers.com/uploads/originals/2019/12/16/autumn-lake-wallpaper.jpg",
    450,
    644);
final UserModel userThao = UserModel(
    5,
    "Moc Thao00000",
    "Hey there! I'm using this app for rating & reviewing anything!",
    "https://media-cdn-v2.laodong.vn/Storage/NewsPortal/2022/6/12/1055592/Ef6eiswu0aetb9s.jpeg",
    "https://burst.shopifycdn.com/photos/winding-tree-towers-over-landscape.jpg?width=1200&format=pjpg&exif=1&iptc=1",
    123,
    432);
final List listUsers = [userHieu, userCuong, userTrang, userTien, userThao];

// ------------------------- POSTS -----------------------------

final PostModel post1 = PostModel(
    1,
    userHieu,
    "25 minutes ago",
    "Lotteria Food",
    5,
    "I'm very haapy with the services. I think this is the best cafe in Yogyakarta.",
    [
      "https://media.truyenhinhdulich.vn/upload/news/4_2019/b1063f299ef40f43546a53a66c739b71.jpg",
      "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnWgg2bdIUMse7Az92HEC2ycNQdM8m261AKmj6Bw9U9705GmFnT7f-cauj1vTWMlC42fo&usqp=CAU",
      "https://images.squarespace-cdn.com/content/v1/58fb718cc534a56ca61a26cb/1632128544522-HFE1IOO7F37J203SKM21/ninhtito-nollowa+2.jpg?format=1000w",
      "https://digiticket.vn/blog/wp-content/uploads/2021/07/quan-ga-ran-ngon-o-ha-noi-3.jpg"
    ],
    "Food & Drink",
    "12 Nguyen Van Troi - Mo Lao - Ha Dong District - Hanoi",
    68,
    0,
    8,
    3);
final PostModel post2 = PostModel(
    2,
    userCuong,
    "2 hours ago",
    "Vegetarian Food",
    4.5,
    "The services here are wonderful. Full of equipments and good mentors. I love it",
    [
      "https://www.vietnamyello.com/img/cats/restaurants.jpg",
      "https://images.unsplash.com/photo-1414235077428-338989a2e8c0?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80",
      "https://cdn.vox-cdn.com/thumbor/egCn-ZRs0mPeFNkTzHF85Qb1pVs=/0x0:3500x2333/1200x900/filters:focal(1470x887:2030x1447):no_upscale()/cdn.vox-cdn.com/uploads/chorus_image/image/71099310/blb14552_51127746426_o.0.jpg"
    ],
    "Vegetarian Food",
    "12 Nguyen Van Troi - Mo Lao - Ha Dong District - Hanoi",
    120,
    4,
    15,
    9);
final PostModel post3 = PostModel(
    3,
    userTrang,
    "1 day ago",
    "Italian Restaurant",
    5,
    "I'm very haapy with the services. I think this is the best cafe in Yogyakarta.",
    [
      "https://assets.bonappetit.com/photos/5ca680eff7c9b51309c95d26/master/pass/luigis-2.jpg",
      "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnWgg2bdIUMse7Az92HEC2ycNQdM8m261AKmj6Bw9U9705GmFnT7f-cauj1vTWMlC42fo&usqp=CAU"
    ],
    "Italian Food",
    "12 Nguyen Van Troi - Mo Lao - Ha Dong District - Hanoi",
    68,
    0,
    8,
    3);
final PostModel post4 = PostModel(
    4,
    userTien,
    "30 minutes ago",
    "Bon'jour Café",
    4.5,
    "The view is very charming. And it's very huge. I can't see all of it",
    [
      "https://images.unsplash.com/photo-1559305616-3f99cd43e353?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8Y2FmZXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60",
      "https://images.unsplash.com/photo-1495474472287-4d71bcdd2085?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80",
      "https://images.unsplash.com/photo-1453614512568-c4024d13c247?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1632&q=80",
      "https://images.unsplash.com/photo-1542181961-9590d0c79dab?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80"
    ],
    "Cafeteria",
    "12 Nguyen Van Troi - Mo Lao - Ha Dong District - Hanoi",
    30,
    0,
    10,
    13);
final PostModel post5 = PostModel(
    5,
    userThao,
    "2 minutes ago",
    "Fast food in KFC",
    4.5,
    "I'm very happy with the services. I think this is the best leisure activity in Yogyakarta.",
    [
      "https://images.unsplash.com/photo-1536521642388-441263f88a61?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80",
      "https://images.unsplash.com/photo-1513639776629-7b61b0ac49cb?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1467&q=80",
      "https://images.unsplash.com/photo-1588638429038-82e9c812fb40?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1510&q=80"
    ],
    "Fast Food",
    "12 Nguyen Van Troi - Mo Lao - Ha Dong District - Hanoi",
    68,
    0,
    8,
    3);
final PostModel post6 = PostModel(
    6,
    userTrang,
    "35 minutes ago",
    "Ten Coins Bakery",
    4.5,
    "I'm very happy with the services. I think this is the best leisure activity in Yogyakarta.",
    [
      "https://images.unsplash.com/photo-1511018556340-d16986a1c194?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80",
      "https://images.unsplash.com/photo-1577595927087-dedbe84f0e4d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1472&q=80",
      "https://images.unsplash.com/photo-1602496875770-0b3d129671e6?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80"
    ],
    "Fast Food",
    "12 Nguyen Van Troi - Mo Lao - Ha Dong District - Hanoi",
    68,
    0,
    8,
    3);


// ------------------------- NOTIFICATIONS -----------------------------
final NotificationModel notification1 =
    NotificationModel(userHieu, "like", "Just now");
final NotificationModel notification2 =
    NotificationModel(userTrang, "comment", "1 day ago");
final NotificationModel notification3 =
    NotificationModel(userCuong, "like", "1 day ago");
final NotificationModel notification4 =
    NotificationModel(userHieu, "follow", "This week");
final NotificationModel notification5 =
    NotificationModel(userTien, "unlike", "This month");
final NotificationModel notification6 =
    NotificationModel(userThao, "comment", "This week");
final NotificationModel notification7 =
    NotificationModel(userCuong, "follow", "Just now");
final NotificationModel notification8 =
    NotificationModel(userTrang, "unlike", "1 day ago");
final NotificationModel notification9 =
    NotificationModel(userTien, "comment", "This week");
final NotificationModel notification10 =
    NotificationModel(userThao, "unlike", "This month");

final List listNotifications = [
  notification1,
  notification2,
  notification3,
  notification4,
  notification5,
  notification6,
  notification7,
  notification8,
  notification9,
  notification10
];

// ------------------------- COMMENTS -----------------------------
final CommentModel comment1 =
    CommentModel(1, 0, userHieu, "Day la comment level 1", "1 day ago");
final CommentModel comment2 =
    CommentModel(2, 0, userTrang, "Day la comment level 1", "1 day ago");
final CommentModel comment3 =
    CommentModel(3, 0, userCuong, "Day la comment level 1", "1 day ago");
final CommentModel comment4 =
    CommentModel(4, 1, userThao, "Day la comment level 2", "1 day ago");
final CommentModel comment5 =
    CommentModel(5, 4, userTien, "Day la comment level 3", "1 day ago");
final CommentModel comment6 =
    CommentModel(6, 2, userCuong, "Day la comment level 2", "1 day ago");
final CommentModel comment7 =
    CommentModel(7, 2, userHieu, "Day la comment level 2", "1 day ago");
final CommentModel comment8 =
    CommentModel(8, 7, userTrang, "Day la comment level 3", "1 day ago");
final CommentModel comment9 =
    CommentModel(9, 3, userTien, "Day la comment level 1", "1 day ago");
final CommentModel comment10 =
    CommentModel(10, 3, userThao, "Day la comment level 1", "1 day ago");

final List listComments = [
  comment1,
  comment2,
  comment3,
  comment4,
  comment5,
  comment6,
  comment7,
  comment8,
  comment9,
  comment10
];

final List<String> imgListBanner = [
  'assets/img_banner_1.jpg',
  'assets/img_banner_2.webp',
  'assets/img_banner_3.jpg',
  'assets/img_banner_4.webp',
  'assets/img_banner_5.webp',
  'assets/img_banner_6.jpg!bw700',
];

final List<RestaurantModel> listRestaurants = [
  RestaurantModel(
      id: 1,
      name: 'Noma',
      location: 'E341, Equimos, Copenhagen, Denmark',
      type: 'favorite',
      rate: 4.5,
      imgUrl:
          'https://media-cdn.tripadvisor.com/media/photo-s/15/17/7f/18/main-entrance-at-grandma.jpg'),
  RestaurantModel(
      id: 2,
      name: 'Celler de Can Roca',
      location: '23A, Girona, Spain',
      type: 'favorite',
      rate: 4.5,
      imgUrl:
          'https://ewscripps.brightspotcdn.com/dims4/default/53041b7/2147483647/strip/true/crop/1280x720+0+67/resize/1280x720!/quality/90/?url=http%3A%2F%2Fewscripps-brightspot.s3.amazonaws.com%2Fdc%2Fb0%2F4e8e861f414fb7124097b7e787b5%2Ffirst-and-last-a.jpeg'),
  RestaurantModel(
      id: 3,
      name: 'Osteria Francescana',
      location: 'E341, Equimos, Modena, Italy',
      type: 'favorite',
      rate: 5,
      imgUrl: 'https://cache.marriott.com/content/dam/marriott-renditions/SGNMD/sgnmd-recipe-restaurant-0226-hor-wide.jpg?output-quality=70&interpolation=progressive-bilinear&downsize=1336px:*'),
  RestaurantModel(
      id: 4,
      name: 'Eleven Madison Park',
      location: '23A, New York, USA',
      type: 'favorite',
      rate: 4.5,
      imgUrl:
          'https://cdn.oliverbonacininetwork.com/uploads/sites/42/2022/04/Canoe-Interior-Evening-Vibes-5170.jpg'),
  RestaurantModel(
      id: 5,
      name: ' Mugaritz, Errenteria',
      location: 'E341, Equimos, Errenteria, Spain',
      type: 'favorite',
      rate: 5,
      imgUrl:
          'https://bacsiielts.vn/wp-content/uploads/2022/05/talk-about-your-favorite-restaurant-2.jpg'),
  RestaurantModel(
      id: 6,
      name: 'D.O.M. Saõ Paulo',
      location: '23A, Saõ Paulo, Brazil',
      type: 'favorite',
      rate: 4.5,
      imgUrl:
          'https://cdn.vox-cdn.com/thumbor/OheW0CNYdNihux9eVpJ958_bVCE=/0x0:5996x4003/1200x900/filters:focal(1003x1633:1961x2591)/cdn.vox-cdn.com/uploads/chorus_image/image/51830567/2021_03_23_Merois_008.30.jpg'),
  RestaurantModel(
      id: 7,
      name: 'Arzak',
      location: '23A, San Sebastian, Spain',
      type: 'favorite',
      rate: 5,
      imgUrl:
          'https://media.istockphoto.com/photos/modern-restaurant-interior-design-picture-id1211547141?k=20&m=1211547141&s=612x612&w=0&h=KiZX3NBZVCK4MlSh4BJ8hZNSJcTIMbNSSV2yusw2NmM='),
  RestaurantModel(
      id: 8,
      name: 'Alinea',
      location: '23A, Chicago, Illinois',
      type: 'favorite',
      rate: 4.5,
      imgUrl:
          'https://images.unsplash.com/photo-1517248135467-4c7edcad34c4?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1yZWxhdGVkfDE0fHx8ZW58MHx8fHw%3D&w=1000&q=80'),
  RestaurantModel(
      id: 9,
      name: 'The Ledbury',
      location: '23A,London, England',
      type: 'favorite',
      rate: 4.5,
      imgUrl:
          'https://img.delicious.com.au/5yOrH6We/w759-h506-cfill/del/2022/02/aalia-163747-2.jpg'),
  RestaurantModel(
      id: 10,
      name: 'Katz\'s Deli',
      location: '23A, New York City, USA',
      type: 'favorite',
      rate: 5,
      imgUrl:
          'https://cdn.vox-cdn.com/thumbor/OheW0CNYdNihux9eVpJ958_bVCE=/0x0:5996x4003/1200x900/filters:focal(1003x1633:1961x2591)/cdn.vox-cdn.com/uploads/chorus_image/image/51830567/2021_03_23_Merois_008.30.jpg'),
];
