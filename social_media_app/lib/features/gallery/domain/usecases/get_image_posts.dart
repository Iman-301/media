import '../repositories/post_repository.dart';

class GetImagesByPost {
  final PostRepository repository;

  GetImagesByPost(this.repository);

  Future<List<String>> call(int postId) {
    return repository.getImagesByPost(postId);
  }
}
