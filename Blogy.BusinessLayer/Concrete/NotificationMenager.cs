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
    public class NotificationMenager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationMenager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TDelete(int id)
        {
            _notificationDal.Delete(id);
        }

        public List<Notification> TGetAll()
        {
           return _notificationDal.GetAll();
        }

        public Notification TGetyById(int id)
        {
            return _notificationDal.GetyById(id);
        }

        public void TInsert(Notification entity)
        {
            _notificationDal.Insert(entity);
        }

        public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
