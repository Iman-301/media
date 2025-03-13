
import 'package:social_media_app/features/gallery/data/datasources/post_remote_data_source.dart';
import 'package:social_media_app/features/gallery/domain/entities/post.dart';
import 'package:social_media_app/features/gallery/domain/repositories/post_repository.dart';
class PostRepositoryImpl implements PostRepository {
  final RemoteDataSource remoteDataSource;

  PostRepositoryImpl(this.remoteDataSource);

  @override
  Future<Post?> getPostById(int postId) async {
    try {
      return await remoteDataSource.getPostById(postId);
    } catch (e) {
      return null;
    }
  }

  @override
  Future<List<String>> getImagesByPost(int postId) async {
    try {
      return await remoteDataSource.getPostImages(postId);
    } catch (e) {
      return [];
    }
  }

  @override
  Future<List<String>> getVideosByPost(int postId) async {
    try {
      return await remoteDataSource.getPostVideos(postId);
    } catch (e) {
      return [];
    }
  }
}
