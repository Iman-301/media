import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import '../provider/post_provider.dart';
import '../widgets/post_card.dart';

class ImagePostsScreen extends ConsumerStatefulWidget {
  final int postId;

  const ImagePostsScreen({super.key, required this.postId});

  @override
  _ImagePostsScreenState createState() => _ImagePostsScreenState();
}

class _ImagePostsScreenState extends ConsumerState<ImagePostsScreen> {
  @override
  Widget build(BuildContext context) {
    final imagesAsync = ref.watch(postImagesByIdProvider(widget.postId));

    return Scaffold(
      appBar: AppBar(title: Text('Images in Post #${widget.postId}')),
      body: imagesAsync.when(
        data: (images) => images.isEmpty
            ? const Center(child: Text("No images in this post"))
            : ListView.builder(
                itemCount: images.length,
                itemBuilder: (context, index) => PostCard(imagePath: images[index], isVideo: false),
              ),
        loading: () => const Center(child: CircularProgressIndicator()),
        error: (error, stackTrace) => Center(child: Text("Error: $error")),
      ),
    );
  }
}
