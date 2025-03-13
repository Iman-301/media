import 'package:social_media_app/features/gallery/domain/entities/post.dart';

abstract class PostRepository {
  Future<Post?> getPostById(int postId);
  Future<List<String>> getImagesByPost(int postId);
  Future<List<String>> getVideosByPost(int postId);
}
