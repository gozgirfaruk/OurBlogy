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
	public class AboutMenager : IAboutService
	{
		IAboutDal _aboutDal;

		public AboutMenager(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}

		public void Delete(int id)
		{
			_aboutDal.Delete(id);
		}

		public List<About> GetAll()
		{
			return _aboutDal.GetAll();
		}

		public About GetyById(int id)
		{
			return _aboutDal.GetyById(id);
		}

		public void Insert(About entity)
		{
			_aboutDal.Insert(entity);
		}

		public void Update(About entity)
		{
			_aboutDal.Update(entity);	
		}
	}
}
