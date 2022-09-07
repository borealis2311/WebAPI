using DataAccessEF.Interfaces;
using Domain.Entities.TableClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.ClassTable.Customer
{
    public partial class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<MD_Customer> GetAll()
        {
            return _unitOfWork.RepositoryAsync<MD_Customer>().GetAll();
        }
        public MD_Customer GetById(int id)
        {
            return _unitOfWork.RepositoryAsync<MD_Customer>().GetById(id);
        }
        public async Task<int> Addsync(MD_Customer customer)
        {
            ValidationCreatedCustomer(customer);
            customer.CreatedDate = DateTime.Now;
            customer.IsBlocked = false;
            await _unitOfWork.RepositoryAsync<MD_Customer>().AddAsync(customer);
            return await _unitOfWork.SaveChangesAsync();
        }
        public int Update(MD_Customer customer)
        {
            customer.UpdatedDate = DateTime.Now;
            _unitOfWork.RepositoryAsync<MD_Customer>().Update(customer);
            return _unitOfWork.Save();
        }
        public int Remove(MD_Customer customer)
        {
            _unitOfWork.RepositoryAsync<MD_Customer>().Remove(customer);
            return _unitOfWork.Save();
        }
        private void ValidationCreatedCustomer(MD_Customer customer)
        {
            var exist = _unitOfWork.RepositoryAsync<MD_Customer>().Find(x => x.CustomerCode == customer.CustomerCode).FirstOrDefault();
            if (exist != null)
                throw new Exception("Exist customer in the system");
        }
    }
}
