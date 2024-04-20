using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework
{
	public class EfArticleDal : GenericRepository<Article>, IArticleDal
	{
		BlogyContext context =new BlogyContext();

        public List<Article> GetArticlesByWriter(int id)
        {
            var values = context.Articles.Where(x => x.AppUserID == id).ToList();
			return values;
        }

        public List<Article> GetArticleWithCategory()
		{
			var values = context.Articles.Include(x=>x.Category).ToList();
			return values;
		}

		public List<Article> GetArticleWithWriter()
		{
			var values =context.Articles.Include(x=>x.Writer).ToList();
			return values;
		}

        public Writer GetWriterInfoByArticleWriter(int id)
        {
			var values = context.Articles.Where(x => x.ArticleID == id).Select(y => y.Writer).FirstOrDefault();
			return values;
        }

    }
}
