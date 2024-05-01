using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstract
{
    public interface IMessageBoxDal : IGenericDal<MessageBox>
    {
        List<MessageBox> GetByFilter(Func<MessageBox, bool> filter);    
    }
}
