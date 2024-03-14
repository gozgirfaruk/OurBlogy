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
    public class WriterMenager : IWriterService
    {
        private readonly IWriterDal _writerDal;
        public WriterMenager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }


        public void TDelete(int id)
        {
           _writerDal.Delete(id);
        }

        public List<Writer> TGetAll()
        {
            return _writerDal.GetAll();
        }

        public Writer TGetyById(int id)
        {
            return _writerDal.GetyById(id);
        }

        public void TInsert(Writer entity)
        {
            _writerDal.Insert(entity);
        }

        public void TUpdate(Writer entity)
        {
           _writerDal.Update(entity);   
        }
    }
}
