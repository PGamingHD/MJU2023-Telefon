namespace AddressList
{

    internal class Person
    {
        private string name { get; set; }
        private string phone { get; set; }
        private string adress { get; set; }

        public Person(string Name, string Phone, string Address)
        {
            name = Name;
            phone = Phone;
            adress = Address;
        }

        public void Print()
        {
            Console.WriteLine($"{name} {phone} {adress}");
        }

        public string returnPrint()
        {
            return $"{name},{phone},{adress}";
        }
    }
            // C:/Users/hugge/OneDrive/Mjukvaruutveckling/Kod/upg/Uppgifter/Adresslista/adresser.txt
    internal class Program
    {
        readonly static List<Person> adressList = new List<Person>();

        public static void SaveAdressList()
        {
            List<string> lines = new List<string>();
            foreach (Person person in adressList)
            {
                string line = person.returnPrint();
                lines.Add(line);
            }

            string filePath = "C:/Users/pontu/Documents/adresser.txt";
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Adressfilen har sparats!");
        }
        static void Main()
        {
            Console.WriteLine("Hello and welcome to the Addresslist!");
            Console.WriteLine("Write 'help' for help!");
            string command;
            do
            {
                Console.Write("Command: ");
                command = Console.ReadLine().ToLower();

                if (command == "help")
                {
                    Console.WriteLine("Not implemented yet");
                }
                else if (command == "stop")
                {

                }
                else if (command == "load")
                {
                    string[] databaseFile = File.ReadAllLines("C:/Users/pontu/Documents/adresser.txt");

                    foreach (string line in databaseFile)
                    {
                        string[] arguments = line.Split(",");

                        adressList.Add(new Person(arguments[0], arguments[1], arguments[2]));
                    }
                }
                else if (command == "list")
                {
                    foreach (Person person in adressList)
                    {
                        person.Print();
                    }
                }
                else if (command == "add")
                {
                    Console.WriteLine("Lägg till ett namn: ");
                    string? addName = Console.ReadLine();
                    Console.WriteLine("Lägg till ett telefonnummer: ");
                    string? addPhone = Console.ReadLine();
                    Console.WriteLine("Lägg till en adress: ");
                    string? addAdress = Console.ReadLine();

                    adressList.Add(new Person(addName, addPhone, addAdress));
                }
                else if(command == "save")
                {
                    SaveAdressList();
                }
                else
                {
                    Console.WriteLine($"Unknown Command: {command}");
                }
            } while (command != "stop");
            Console.WriteLine("Bye!");
        }
    }
}
