using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class WishList : BaseEntity
    {
        public string WishlistDescription { get; set; }
        public decimal RoughPrice { get; set; }
        public int Priority { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
