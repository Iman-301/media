import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import '../provider/post_provider.dart';
import '../widgets/post_card.dart';

class VideoPostsScreen extends ConsumerWidget {
  final int postId;

  const VideoPostsScreen({super.key, required this.postId});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final videosAsync = ref.watch(postVideosByIdProvider(postId));

    return Scaffold(
      appBar: AppBar(title: Text('Videos in Post #$postId')),
      body: videosAsync.when(
        data: (videos) => videos.isEmpty
            ? const Center(child: Text("No videos in this post"))
            : ListView.builder(
                itemCount: videos.length,
                itemBuilder: (context, index) => PostCard(imagePath: videos[index], isVideo: true),
              ),
        loading: () => const Center(child: CircularProgressIndicator()),
        error: (_, __) => const Center(child: Text("Error loading videos")),
      ),
    );
  }
}
