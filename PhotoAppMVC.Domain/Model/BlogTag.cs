using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAppMVC.Domain.Model
{
    public class BlogTag
    {
        public int BlogId { get; set; }
        public BlogDetails Blog { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
