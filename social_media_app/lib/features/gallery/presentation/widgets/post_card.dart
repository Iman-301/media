import 'package:flutter/material.dart';
import 'video_player_widgets.dart';

class PostCard extends StatelessWidget {
  final String imagePath;
  final bool isVideo;
  

  const PostCard({super.key, required this.imagePath, required this.isVideo});

  @override
  Widget build(BuildContext context) {
    
    return Card(
      margin: const EdgeInsets.all(10),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          isVideo
              ? VideoPlayerWidget(videoPath: imagePath)

             : 
              Column(
                children: [
                  Text( "postcard http://localhost:5178$imagePath"),
                  Container(
                    height: 200,
                    width: 200,       
                    decoration: BoxDecoration(
                      borderRadius: BorderRadius.circular(5),
                      image: DecorationImage(
                        fit: BoxFit.cover,
                        image: NetworkImage("http://localhost:5178$imagePath"),
                       

                      ),
                    ),
                  ),
                ],
              ),           
        ],
      ),
    );
  }
}