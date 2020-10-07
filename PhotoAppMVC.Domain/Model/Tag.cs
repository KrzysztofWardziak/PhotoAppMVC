using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAppMVC.Domain.Model
{
    public  class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BlogTag> BlogTags { get; set; }
    }
}
