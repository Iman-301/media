import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:social_media_app/features/gallery/domain/entities/post.dart';
import '../provider/post_provider.dart';
import '../widgets/post_card.dart';
class PostScreen extends ConsumerWidget {
  final int postId;

  const PostScreen({super.key, required this.postId});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final postAsync = ref.watch(postByIdProvider(postId));
    return Scaffold(
      appBar: AppBar(title: Text('Post #$postId')),
      body: postAsync.when(
        data: (post) {
          if (post == null) return const Center(child: Text("Post not found"));
          print("in post screen ${post.videoUrls}");

          return ListView(
            padding: const EdgeInsets.all(10),
            children: [
              
              Text(
                post.caption,
                style: const TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
              ),
              const SizedBox(height: 10),

              // Show images
              post.imageUrls.isEmpty
                  ? const Center(child: Text("No images in this post"))
                  : Column(children: post.imageUrls.map((image) => PostCard(imagePath: image, isVideo: false)).toList()),

              // Show videos
              post.videoUrls.isEmpty
                  ? const Center(child: Text("No videos in this post"))
                  : Column(children: post.videoUrls.map((video) => PostCard(imagePath: video, isVideo: true)).toList()),
            ],
          );
        },
        loading: () => const Center(child: CircularProgressIndicator()),
        error: (_, __) => const Center(child: Text("Error loading post")),
      ),
    );
  }
}