using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAppMVC.Domain.Model
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Sorting { get; set; }
    }
}
