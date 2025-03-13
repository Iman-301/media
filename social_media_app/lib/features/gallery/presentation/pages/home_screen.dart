import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  final TextEditingController _postIdController = TextEditingController();

  void _navigateToPost(String route) {
    final postId = int.tryParse(_postIdController.text);
    if (postId == null) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text("Please enter a valid Post ID")),
      );
      return;
    }
    context.push('$route/$postId');
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Home')),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
             Container(
              width: 100,
              height: 100,
                        
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(5),
                          image: DecorationImage(
                            fit: BoxFit.cover,
                            image: NetworkImage("http://localhost:5178/uploads/a4808eea-c9fc-47e1-ac62-46715673df02.jpg"),
                            // image: NetworkImage("https://th.bing.com/th/id/R.55e0446feca8910e864359906b8781a3?rik=b2mM1%2byeloEyBQ&pid=ImgRaw&r=0"),

                          ),
                        ),),
            TextField(
              controller: _postIdController,
              keyboardType: TextInputType.number,
              decoration: const InputDecoration(
                labelText: "Enter Post ID",
                border: OutlineInputBorder(),
              ),
            ),
            const SizedBox(height: 20),
            ElevatedButton(
              onPressed: () => _navigateToPost('/post'),
              child: const Text('View Post'),
            ),
            const SizedBox(height: 10),
            ElevatedButton(
              onPressed: () => _navigateToPost('/image-posts'),
              child: const Text('View Images in Post'),
            ),
            const SizedBox(height: 10),
            ElevatedButton(
              onPressed: () => _navigateToPost('/video-posts'),
              child: const Text('View Videos in Post'),
            ),
          ],
        ),
      ),
    );
  }
}
