using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string PostContent { get; set; }
        public DateTime Date { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
