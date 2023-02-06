using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<WishList> WishLists { get; set; }

    }
}
