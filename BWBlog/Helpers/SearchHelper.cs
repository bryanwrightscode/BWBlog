using BWBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BWBlog.Helpers
{
    public class SearchHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IQueryable<Post> IndexSearch(string searchStr)
        {
            IQueryable<Post> result = null;
            if (searchStr != null)
            {
                result = db.Posts.AsQueryable();
                result = result.Where(p => 
                p.Title.Contains(searchStr) ||
                p.BodyText.Contains(searchStr) ||
                p.PostAuthor.FirstName.Contains(searchStr) ||
                p.PostAuthor.LastName.Contains(searchStr) ||
                p.Comments.Any(c => c.CommentText.Contains(searchStr) ||
                c.CommentAuthor.FirstName.Contains(searchStr) ||
                c.CommentAuthor.LastName.Contains(searchStr) ||
                c.CommentAuthor.Email.Contains(searchStr)));
            }
            else
            {
                result = db.Posts.AsQueryable();
            }
            //queries the posts and sorts descending
            return result;
        }
    }
}