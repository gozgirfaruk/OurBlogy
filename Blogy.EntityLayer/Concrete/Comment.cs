﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer.Concrete
{
	public class Comment
	{
		public int CommentID { get; set; }
        public string Subject { get; set; }
        public DateTime CommentDate { get; set; }
		public int ArticleID { get; set; }
		public Article Article { get; set; }
		public string NameSurname { get; set; }
		public string Email { get; set; }
		public bool Status { get; set; }

	}
}
