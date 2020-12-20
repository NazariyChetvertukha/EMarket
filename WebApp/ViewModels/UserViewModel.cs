using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class UserViewModel
    {
        public List<Buyer> Buyers { get; set; }
        public List<Seller> Sellers { get; set; }
    }
}