using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAppMVC.Domain.Model
{
    public class Offer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }
        public string Date { get; set; }
    }
}
