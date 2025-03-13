import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:social_media_app/features/gallery/data/datasources/post_remote_data_source.dart';
import 'package:social_media_app/features/gallery/data/repositories/post_repository_impl.dart';
import 'package:social_media_app/features/gallery/domain/entities/post.dart';

// Create repository provider
final postRepositoryProvider = Provider<PostRepositoryImpl>((ref) {
  return PostRepositoryImpl(RemoteDataSourceImpl());
});

final postByIdProvider = FutureProvider.family<Post?, int>((ref, postId) async {
  final repository = ref.watch(postRepositoryProvider);
  return repository.getPostById(postId);
});


// Fetch images of a post from API
final postImagesByIdProvider = FutureProvider.family<List<String>, int>((ref, postId) async {
  final repository = ref.watch(postRepositoryProvider);
  return repository.getImagesByPost(postId);
});

// Fetch videos of a post from API
final postVideosByIdProvider = FutureProvider.family<List<String>, int>((ref, postId) async {
  final repository = ref.watch(postRepositoryProvider);
  return repository.getVideosByPost(postId);
});
