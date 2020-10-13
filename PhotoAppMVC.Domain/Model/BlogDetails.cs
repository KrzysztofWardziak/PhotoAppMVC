using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoAppMVC.Domain.Model
{
    public class BlogDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        
        public string PhotoPath { get; set; }
        public Tag Tag { get; set; }
        public string CreatedDate { get; set; }
        public string? ModifiedDate { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public ICollection<BlogTag> BlogTags { get; set; }
    }
}
