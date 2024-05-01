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
    public class MessageBoxMenager : IMessageBoxService
    {
        private readonly IMessageBoxDal _messageBoxDal;
        public MessageBoxMenager(IMessageBoxDal messageBoxDal)
        {
            _messageBoxDal = messageBoxDal;
        }

        public List<MessageBox> GetListReceiver(string p)
        {
            return _messageBoxDal.GetByFilter(x => x.ReceiverMail == p);
        }

        public List<MessageBox> GetListSender(string p)
        {
           return _messageBoxDal.GetByFilter(x=>x.SenderMail == p);
        }

        public void TDelete(int id)
        {
            _messageBoxDal.Delete(id);
        }

        public List<MessageBox> TGetAll()
        {
          return _messageBoxDal.GetAll();
        }

        public MessageBox TGetyById(int id)
        {
           return _messageBoxDal.GetyById(id);
        }

        public void TInsert(MessageBox entity)
        {
            _messageBoxDal.Insert(entity);
        }

        public void TUpdate(MessageBox entity)
        {
            _messageBoxDal.Update(entity);  
        }
    }
}
