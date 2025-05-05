using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLib
{
    public  class Role
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<User> Users { get; set; } = new List<User>();

    }
}
