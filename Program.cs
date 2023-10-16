namespace AddressList
{
    internal class Program
    {
        internal class Person
        {
            static private string name, phone, adress;

            public Person(string Name, string Person, string Address)
            {
                name = Name; 
                phone = Person; 
                adress = Address;
            }

            static void Print()
            {
                Console.WriteLine($"{name} {phone} {adress}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to the Addresslist!");
            Console.WriteLine("Write 'help' for help!");
            string command;
            do
            {
                Console.Write("Command: ");
                command = Console.ReadLine();
                if (command.ToLower() == "help") {
                    Console.WriteLine("Not implemented yet");
                }
                else if (command.ToLower() == "stop") {
                    
                }
                else if (command.ToLower() == "load") {

                }
                else {
                    Console.WriteLine($"Unknown Command: {command}");
                }
            } while (command.ToLower() != "stop");
            Console.WriteLine("Bye!");
        }
    }
}
