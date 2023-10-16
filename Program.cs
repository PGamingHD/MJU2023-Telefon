namespace AddressList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to the Addresslist!");
            Console.WriteLine("Write 'help' for help!");
            string command;
            do
            {
                Console.Write("Command: ");
                command = Console.ReadLine();
                if (command == "help")
                {
                    Console.WriteLine("Not implemented yet");
                }
                else if(command == "stop")
                {
                    Environment.Exit(0);
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