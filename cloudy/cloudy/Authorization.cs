using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudy
{
    public class Authorization
    {
        public bool loged_in { get; set; }

        public bool CheckLogIn(string login, string password)
        {
            if (login == "login" && password == "password")
            {
                loged_in = true;
            }
            else
            {
                loged_in = false;
            }
            return loged_in;
        }
    }
}
