using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer.Concrete
{
    public class Article
    {
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string Explanation { get; set; }
        public string CoverImageUrl { get; set; }
        public string? ImageUrlA { get; set; }
        public string? ImageUrlB { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int WriterID { get; set; }
        public Writer Writer { get; set; }
        public int AppUserID { get; set; }
        public AppUser? AppUser { get; set; }

        public List<Comment> Comments { get; set; }
    
    }
}
