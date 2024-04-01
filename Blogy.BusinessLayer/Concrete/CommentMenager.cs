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
    public class CommentMenager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentMenager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TDelete(int id)
        {
            _commentDal.Delete(id); 
        }

        public List<Comment> TGetAll()
        {
           return _commentDal.GetAll(); 
        }

        public Comment TGetyById(int id)
        {
            return _commentDal.GetyById(id);
        }

        public void TInsert(Comment entity)
        {
           _commentDal.Insert(entity);
        }

        public void TUpdate(Comment entity)
        {
           _commentDal.Update(entity);
        }
    }
}
