using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;
namespace Welcome.Model
{
    public class User
    {
        private int _id;
        private string _name;
        private string _password;
        public DateTime _expires;
        private UserRolesEnum _role;

        public User() { }
        public User(string name, string password, UserRolesEnum role)
        {
            _name = name;
            _password = password;
            _role = role;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public UserRolesEnum Role
        {
            get { return _role; }
            set { _role = value; }
        }
        virtual public int Id { get; set; }
        public DateTime Expires { get; set; }
    }
}
