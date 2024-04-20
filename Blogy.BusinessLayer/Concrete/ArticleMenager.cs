using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete
{
    public class ArticleMenager : IArticleService
    {
          private readonly IArticleDal _articleDal;

        public ArticleMenager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

		public List<Article> GetArticleWithCategory()
		{
			return _articleDal.GetArticleWithCategory();
		}

		public List<Article> GetArticleWithWriter()
		{
			return _articleDal.GetArticleWithWriter();
		}

        public void TDelete(int id)
        {
           if(id!=0)
            {
                _articleDal.Delete(id);
            }
           else
            {
                //hata mesajı
            }
        }

        public List<Article> TGetAll()
        {
            return _articleDal.GetAll();
        }

        public List<Article> TGetArticlesByWriter(int id)
        {
            return _articleDal.GetArticlesByWriter(id);
        }

        public Writer TGetWriterInfoByArticleWriter(int id)
        {
           return _articleDal.GetWriterInfoByArticleWriter(id);
        }

        public Article TGetyById(int id)
        {
            return _articleDal.GetyById(id);
        }

        public void TInsert(Article entity)
        {
            _articleDal.Insert(entity);
        }

        public void TUpdate(Article entity)
        {
            _articleDal.Update(entity);

        }
    }
}
