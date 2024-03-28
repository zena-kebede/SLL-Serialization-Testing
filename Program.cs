using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_skeleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User john = new User(123, "john", "123@123.com", "12345");
            User mike = new User(123, "mike", "123@123.com", "12345");
            User chris = new User(123, "chris", "123@123.com", "12345");
            singlyLinkedList sll = new singlyLinkedList();

            sll.Append(john);
            sll.Append(mike);
            sll.Append(chris);

            sll.Insert(chris, 0);
            Console.WriteLine(sll.Size());
            sll.Display();
            sll.Replace(mike, 3);

            sll.Display();
            sll.Delete(1);
            Console.WriteLine(sll.Size());
            Console.WriteLine(sll.Retrieve(1));
            Console.WriteLine(sll.IndexOf(chris));
            Console.WriteLine(sll.Contains(john));
            sll.Append(john);
            Console.WriteLine(sll.Contains(john));
            sll.Display();

            Console.ReadKey();
        }
    }
}
