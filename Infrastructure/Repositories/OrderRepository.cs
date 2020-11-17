using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementSystem.Infrastructure.Interface;
using TaskManagementSystem.Model;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        bool IRepository<Order>.Delete(int Id)
        {
            throw new NotImplementedException();
        }

        List<Order> IRepository<Order>.GetAll()
        {
            throw new NotImplementedException();
        }

        Order IRepository<Order>.GetSingle(int Id)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Order>.Insert(Order objT)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Order>.Update(Order objT)
        {
            throw new NotImplementedException();
        }
    }
}
