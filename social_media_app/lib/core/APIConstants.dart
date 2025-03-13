class APIConstants {
  static const String baseUrl = "http://localhost:5178/api";
  // static const String getPosts = "$baseUrl/Posts"; // Get all posts
  static String getPostById(int postId) => "$baseUrl/Posts/$postId"; 
  static String getPostImages(int postId) => "$baseUrl/Posts/$postId/images"; 
  static String getPostVideos(int postId) => "$baseUrl/Posts/$postId/videos"; 
}
