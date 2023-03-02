using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishListManagement.Domain.User
{
    public interface IUserRepository
    {
        bool Create(User user);
        User GetUserById(long id);
        bool Delete(long id);
        bool Modify(User user);
    }
}
