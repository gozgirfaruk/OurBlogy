﻿using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
		List<Comment> TGetCommentByArticleID(int id);
	}
}
