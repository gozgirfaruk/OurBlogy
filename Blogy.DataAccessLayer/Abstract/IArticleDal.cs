using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {
		List<Article> GetArticleWithWriter();
		List<Article> GetArticleWithCategory();
		Writer GetWriterInfoByArticleWriter(int id);

		List<Article> GetArticlesByWithWriter(int id);
	}
}
