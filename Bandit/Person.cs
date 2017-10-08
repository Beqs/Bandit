using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandit
{
    class Person
    {
        private string _name;
        private int _age;

        public void Start(string name, int age)
        {
            name = _name;
            age = _age;
        }

        public bool VerifyAge(int age)
        {
            if (age > 17)
                return true;
            else
                return false;
        }

        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }
    }
}
