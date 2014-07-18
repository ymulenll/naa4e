using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Registry.CommandStack.Model
{
    public class Person : Party
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        protected Person()
        {

        }

        public static class Factory
        {
            public static Person CreateNewEntry()
            {
                var p = new Person();
                return p;
            }
        }
    }
}
