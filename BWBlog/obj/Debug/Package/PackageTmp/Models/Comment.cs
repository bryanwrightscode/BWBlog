using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BWBlog.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public string CommentAuthorID { get; set; }
        public string CommentText { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}")]
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Post Post { get; set; }
        public virtual ApplicationUser CommentAuthor { get; set; }
    }
}