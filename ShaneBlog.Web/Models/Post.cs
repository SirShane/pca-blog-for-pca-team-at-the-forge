using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShaneBlog.Web.Models
{
    public class Post
    {
        public string Body { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return "Post " + Id + ": " + Body;
        }
    }
}