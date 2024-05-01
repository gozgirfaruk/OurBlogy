using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework
{
    public class EfMessageBoxDal : GenericRepository<MessageBox>, IMessageBoxDal
    {
      
        public List<MessageBox> GetByFilter(Func<MessageBox, bool> filter)
        {
            using var db = new BlogyContext();
            return db.Set<MessageBox>().Where(filter).ToList();
        }
    }
}
