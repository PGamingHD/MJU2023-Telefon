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

        public string getName()
        {
            return name;
        }

        public string getPhone()
        {
            return phone;
        }

        public string getAdress()
        {
            return adress;
        }
    }

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

            string? newAdressPath = Environment.GetEnvironmentVariable("adressListPath");

            if (newAdressPath == null) return;

            File.WriteAllLines(newAdressPath, lines);
            Console.WriteLine("The address file has been saved!");
        }
        static void Main()
        {
            string? adressPath = Environment.GetEnvironmentVariable("adressListPath");

            if (adressPath == null)
            {
                string username = Environment.UserName;
                Environment.SetEnvironmentVariable("adressListPath", $"C:/Users/{username}/Documents/adresser.txt");
            }


            Console.WriteLine("Hello and welcome to the Addresslist!");
            Console.WriteLine("Write 'help' for help!");
            string command;
            do
            {
                Console.Write("Command: ");
                command = Console.ReadLine().ToLower();

                if (command == "help")
                {
                    Console.WriteLine("stop   -| Stop the running command line!\nload   -| Load in all data from the database file\nlist   -| List up all data in the database file\nadd    -| Add new data to the database file\nsave   -| Save all data to the database file\ndelete -| Delete entry from the adress list!");
                }
                else if (command == "stop")
                {

                }
                else if (command == "load")
                {
                    adressList.Clear();

                    string? newAdressPath = Environment.GetEnvironmentVariable("adressListPath");

                    if (newAdressPath == null) continue;

                    if (!File.Exists(newAdressPath))
                    {
                        string[] templateData = { "Arne Svensson,013-113 13 13,Datasvängen 23", "Berith Qvist,014-114 14 14,Telegränd 45", "Caesar Augustus,091-432 87 65,Optikervägen 10", "Dagobert Uggla,047-56 64 72,Cobolgränd 77", "Eleanor Smith,017-116 15 22,Algolgatan 60" };

                        File.WriteAllLines(newAdressPath, templateData);
                    }

                    string[] databaseFile = File.ReadAllLines(newAdressPath);

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
                    Console.WriteLine("Add name: ");
                    string? addName = Console.ReadLine();
                    Console.WriteLine("Add phonenumber: ");
                    string? addPhone = Console.ReadLine();
                    Console.WriteLine("Add adress: ");
                    string? addAdress = Console.ReadLine();

                    adressList.Add(new Person(addName, addPhone, addAdress));
                }
                else if (command == "save")
                {
                    SaveAdressList();
                }
                else if (command == "delete")
                {
                    Console.WriteLine("Type the persons name you want to remove: ");
                    string? deleteName = Console.ReadLine();

                    List<Person> foundName = adressList.Where(p => p.getName().ToLower() == deleteName.ToLower()).ToList();

                    if (foundName.Count() == 0)
                    {
                        Console.WriteLine("Nobody found with that name!");
                        continue;
                    }

                    if (foundName.Count() == 1)
                    {
                        Person foundPerson = foundName[0];

                        Console.WriteLine("The person has been removed!");
                        adressList.Remove(foundPerson);
                        continue;
                    }

                    Console.WriteLine("Multiple people found, add more information about the person you want to remove!");
                    Console.WriteLine("Type the number of that person you want to remove: ");
                    string? deletePhone = Console.ReadLine();

                    List<Person> foundPhone = foundName.Where(p => p.getPhone() == deletePhone).ToList();

                    if (foundPhone.Count() == 0)
                    {
                        Console.WriteLine("Nobody found with that number!");
                        continue;
                    }

                    if (foundPhone.Count() == 1)
                    {
                        Person foundPerson = foundPhone[0];

                        Console.WriteLine("The person has been removed!");
                        adressList.Remove(foundPerson);
                        continue;
                    }

                    Console.WriteLine("Multiple people found, add more information about the person you want to remove!");
                    Console.WriteLine("Type the adress of the person you want to remove: ");
                    string? deleteAdress = Console.ReadLine();

                    List<Person> foundAdress = foundPhone.Where(p => p.getAdress().ToLower() == deleteAdress.ToLower()).ToList();

                    if (foundAdress.Count() == 0)
                    {
                        Console.WriteLine("Nobody found with that adress!");
                        continue;
                    }

                    if (foundAdress.Count() == 1)
                    {
                        Person foundPerson = foundAdress[0];

                        Console.WriteLine("The person has been removed!");
                        adressList.Remove(foundPerson);
                        continue;
                    }

                    if (foundAdress.Count() >= 2)
                    {
                        Person foundPerson = foundAdress[0];

                        Console.WriteLine("The first person in the list has been removed, since there are multiple on the list!");
                        adressList.Remove(foundPerson);
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine($"Unknown Command: {command}");
                }
            } while (command != "stop");
            Console.WriteLine("Process exit, bye!");
        }
    }
}
