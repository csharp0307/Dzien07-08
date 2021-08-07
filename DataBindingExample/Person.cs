using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingExample
{
    class Person
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }
        public bool Active { get; set; }

        public string FullName { get { return $"{FName} {LName}"; } }
    }
}
