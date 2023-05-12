using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    public class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Ivan", "test", UserRolesEnum.ADMIN);
            UserViewModel uvm = new UserViewModel(user);
            UserView view = new UserView(uvm);
            view.Display();


        }
    }

}
