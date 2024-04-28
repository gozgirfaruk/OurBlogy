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
	public class ContactMenager : IContactService
	{
		private readonly IContactDal _cantactDal;

		public ContactMenager(IContactDal cantactDal)
		{
			_cantactDal = cantactDal;
		}

		public void TDelete(int id)
		{
			throw new NotImplementedException();
		}

		public List<Contact> TGetAll()
		{
			throw new NotImplementedException();
		}

		public Contact TGetyById(int id)
		{
			throw new NotImplementedException();
		}

		public void TInsert(Contact entity)
		{
			_cantactDal.Insert(entity);	
		}

		public void TUpdate(Contact entity)
		{
			throw new NotImplementedException();
		}
	}
}
