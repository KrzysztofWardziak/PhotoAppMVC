using System.Collections;
using System.Collections.Generic;

namespace PhotoAppMVC.Domain.Model
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}