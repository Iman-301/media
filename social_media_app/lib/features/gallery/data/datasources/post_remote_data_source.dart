import 'dart:convert';
import 'package:http/http.dart' as http;
import '../models/post_model.dart';
import '../../../../core/APIConstants.dart';

abstract class RemoteDataSource {
  Future<PostModel> getPostById(int postId);
  Future<List<String>> getPostImages(int postId);
  Future<List<String>> getPostVideos(int postId);
}
class RemoteDataSourceImpl implements RemoteDataSource {
  @override
  Future<PostModel> getPostById(int postId) async {
    final response = await http.get(Uri.parse(APIConstants.getPostById(postId)));
    print("statais ${response.statusCode}");
    print(response.body);
    if (response.statusCode == 200) {
      PostModel res =  PostModel.fromJson(json.decode(response.body));
      print("in if remote ${res}");
      return res;
    } else {
      throw Exception('Failed to load post');
    }
  }

  @override
  Future<List<String>> getPostImages(int postId) async {
    final response = await http.get(Uri.parse(APIConstants.getPostImages(postId)));
    
    if (response.statusCode == 200) {
      final jsonData = json.decode(response.body);
      
      return List<String>.from(jsonData['mediaUrls'] ?? []);
    } else {
      throw Exception('Failed to load images');
    }
  }

  @override
  Future<List<String>> getPostVideos(int postId) async {
    final response = await http.get(Uri.parse(APIConstants.getPostVideos(postId)));

    if (response.statusCode == 200) {
      final jsonData = json.decode(response.body);
      return List<String>.from(jsonData['mediaUrls'] ?? []);
    } else {
      throw Exception('Failed to load videos');
    }
  }
}