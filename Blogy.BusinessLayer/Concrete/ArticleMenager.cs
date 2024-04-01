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

        public Article TGetyById(int id)
        {
            return _articleDal.GetyById(id);
        }

        public void TInsert(Article entity)
        {
            if(entity!=null && entity.Description.Length>50) 
            {
            _articleDal.Insert(entity);
            }
            else
            {
                //hata mesajı
            }
        }

        public void TUpdate(Article entity)
        {
            if (entity != null && entity.Description.Length > 50)
            {
                _articleDal.Update(entity);
            }
            else
            {
                //hata mesajı
            }
            
        }
    }
}
