﻿namespace WriterFrontEnd.Models.Posts
{
    public class PostResponse
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public IEnumerable<CommentResponse> Comments { get; set; }
    }
}