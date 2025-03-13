import '../../domain/entities/post.dart';
class PostModel extends Post {
  PostModel({
    required int id,
    required String caption,
    required List<String> mediaUrls,
  }) : super(
          id: id,
          caption: caption,
          imageUrls: mediaUrls.where((url) => url.endsWith('.jpg') || url.endsWith('.png')).toList(),
          videoUrls: mediaUrls.where((url) => url.endsWith('.mp4')).toList(),
        );

  factory PostModel.fromJson(Map<String, dynamic> json) {
    return PostModel(
      id: json['id'] as int,
      caption: json['caption'] as String,
      mediaUrls: List<String>.from(json['mediaUrls'] ?? []),
    );
  }
}
