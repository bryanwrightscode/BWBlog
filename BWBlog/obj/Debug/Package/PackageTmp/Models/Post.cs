using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BWBlog.Models
{
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string PostAuthorId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string BodyText { get; set; }
        public string MediaUrl { get; set; }

        //Allows admin access unfinished blogs
        public bool Published { get; set; }
        //Blog title for url SEO (search engine optimization
        public string Slug { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ApplicationUser PostAuthor { get; set; }
    }
}