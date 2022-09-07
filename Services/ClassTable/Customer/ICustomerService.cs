using Domain.Entities.TableClass;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.ClassTable.Customer
{
    public interface ICustomerService
    {
        IEnumerable<MD_Customer> GetAll();
        MD_Customer GetById(int id);
        Task<int> Addsync(MD_Customer customer);
        int Update(MD_Customer customer);
        int Remove(MD_Customer customer);
    }
}
