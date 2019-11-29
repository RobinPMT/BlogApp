using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Category
    {
        public Category()
        {
            Posts = new HashSet<Post>();
        }
        [Key]
        public int ID { get; set; }
        [StringLength(200)]
        public string CategoryName { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
