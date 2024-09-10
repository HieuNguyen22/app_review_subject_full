import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'dart:math' as math;

class GetHeaderReview extends StatelessWidget {
  const GetHeaderReview({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.only(left: 0, right: 10),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Row(
            mainAxisAlignment: MainAxisAlignment.start,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              Container(
                width: MediaQuery.of(context).size.width * .15,
                height: MediaQuery.of(context).size.width * .15,
                margin: EdgeInsets.only(top: 2),
                decoration: BoxDecoration(
                  // border: Border.all(),
                    image: DecorationImage(
                        image: AssetImage('assets/ic_logo.png'),
                        fit: BoxFit.cover)),
              ),
              Padding(
                padding: EdgeInsets.only(
                    left: 5),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      "FoodReviu",
                      style: TextStyle(
                          fontFamily: 'Anton-Regular',
                          color: Colors.white,
                          fontSize: 34,
                          fontWeight: FontWeight.bold),
                    ),
                    Text("Browse any reviews for your reference",
                        style: TextStyle(
                            color: Colors.white.withOpacity(0.8), fontSize: 13))
                  ],
                ),
              ),
            ],
          ),
          Icon(
            Icons.segment,
            color: Colors.white.withOpacity(0.8),
            size: 30,
          )
        ],
      ),
    );
  }
}
