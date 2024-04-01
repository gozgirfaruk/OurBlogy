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
    public class TagMenager : ITagService
    {
       private readonly ITagDal _tagDal;

        public TagMenager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }

        public void TDelete(int id)
        {
             _tagDal.Delete(id);
        }

        public List<Tag> TGetAll()
        {
            return _tagDal.GetAll();
        }

        public Tag TGetyById(int id)
        {
           return _tagDal.GetyById(id);
        }

        public void TInsert(Tag entity)
        {
            _tagDal.Insert(entity);
        }

        public void TUpdate(Tag entity)
        {
            _tagDal.Update(entity);
        }
    }
}
