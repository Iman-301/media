import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';
import 'package:social_media_app/features/gallery/presentation/pages/home_screen.dart';
import 'package:social_media_app/features/gallery/presentation/pages/image_posts_screen.dart';
import 'package:social_media_app/features/gallery/presentation/pages/post_screen.dart';
import 'package:social_media_app/features/gallery/presentation/pages/video_posts_screen.dart';


void main() {
  runApp(const ProviderScope(child: MyApp()));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp.router(
      debugShowCheckedModeBanner: false,
      title: 'Social Media App',
      theme: ThemeData.dark(),
      routerConfig: _router,
    );
  }
}

final _router = GoRouter(
  routes: [
    GoRoute(path: '/', builder: (context, state) =>  HomeScreen()),
    GoRoute(
      path: '/post/:id',
      builder: (context, state) => PostScreen(postId: int.parse(state.pathParameters['id']!)),
    ),
    GoRoute(
      path: '/image-posts/:id',
      builder: (context, state) => ImagePostsScreen(postId: int.parse(state.pathParameters['id']!)),
    ),
    GoRoute(
      path: '/video-posts/:id',
      builder: (context, state) => VideoPostsScreen(postId: int.parse(state.pathParameters['id']!)),
    ),
  ],
);
