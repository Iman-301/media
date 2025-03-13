import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:video_player/video_player.dart';
import '../provider/videoStateProvider.dart';

class VideoPlayerWidget extends ConsumerWidget {
  final String videoPath;
  const VideoPlayerWidget({super.key, required this.videoPath});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final videoState = ref.watch(videoStateProvider(videoPath));
    final videoNotifier = ref.read(videoStateProvider(videoPath).notifier);

    print("Video Initialized: ${videoState.controller.value.isInitialized}");
    print("Loading Video URL: $videoPath");

    return Container(
      width: 200,
      height: 200,
      decoration: BoxDecoration(
        color: Colors.black, // Background color for better visibility
        borderRadius: BorderRadius.circular(10), // Optional rounded corners
      ),
      child: videoState.controller.value.isInitialized
          ? Stack(
              alignment: Alignment.center,
              children: [
                AspectRatio(
                  aspectRatio: videoState.controller.value.aspectRatio,
                  child: VideoPlayer(videoState.controller),
                ),
                Positioned(
                  child: IconButton(
                    icon: Icon(
                      videoState.isPlaying ? Icons.pause : Icons.play_arrow,
                      size: 50,
                      color: Colors.white,
                    ),
                    onPressed: () {
                      videoNotifier.togglePlayPause();
                    },
                  ),
                ),
              ],
            )
          : const Center(child: CircularProgressIndicator()),
    );
  }
}
