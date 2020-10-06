using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAppMVC.Domain.Model
{
    public class ContactMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Email { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
