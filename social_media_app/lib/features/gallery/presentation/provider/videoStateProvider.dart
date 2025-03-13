import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:video_player/video_player.dart';

// State class for video
class VideoState {
  final VideoPlayerController controller;
  final bool isPlaying;

  VideoState({required this.controller, this.isPlaying = false});
}

// StateNotifier to manage video state
class VideoStateNotifier extends StateNotifier<VideoState> {
  VideoStateNotifier(String videoPath)
      : super(VideoState(controller: VideoPlayerController.networkUrl(Uri.parse("http://localhost:5178/$videoPath")))) {
    _initialize();
  }

  Future<void> _initialize() async {
    
    try {
      print("Initializing video...");
      await state.controller.initialize();
      print("Video initialized.");
      
      state.controller.setLooping(false);
      state = VideoState(controller: state.controller, isPlaying: false);
    } catch (e) {
      print("Error initializing video: $e");
      
    }
  }

  // Play/Pause toggle
  void togglePlayPause() {
    if (state.isPlaying) {
      state.controller.pause();
    } else {
      state.controller.play();
    }
    state = VideoState(controller: state.controller, isPlaying: !state.isPlaying);
  }

  @override
  void dispose() {
    print("Disposing video controller...");
    state.controller.dispose();
    super.dispose();
  }
}

// AutoDispose family provider to manage video instances properly
final videoStateProvider = StateNotifierProvider.autoDispose.family<VideoStateNotifier, VideoState, String>(
  (ref, videoPath) {
    final notifier = VideoStateNotifier(videoPath);
    ref.onDispose(() => notifier.dispose()); // Ensuring disposal
    return notifier;
  },
);
