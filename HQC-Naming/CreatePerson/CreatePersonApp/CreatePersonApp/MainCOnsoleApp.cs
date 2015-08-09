using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatePersonApp
{
    public class MainConsoleApp
    {
        static void Main(string[] args)
        {
            Person male = new Person();
            Person female = new Person();

            male.createPerson(25);
            female.createPerson(28);

            Console.WriteLine(male.ToString());
            Console.WriteLine(female.ToString());

        }
    }
}
