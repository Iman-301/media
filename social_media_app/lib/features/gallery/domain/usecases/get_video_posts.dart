import '../repositories/post_repository.dart';

class GetVideosByPost {
  final PostRepository repository;

  GetVideosByPost(this.repository);

  Future<List<String>> call(int postId) {
    return repository.getVideosByPost(postId);
  }
}
