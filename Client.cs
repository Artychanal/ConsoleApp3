namespace ConsoleApp3.solution.client;
public class Client
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<string> Keywords { get; set; }

    public Client(string name, string surname, List<string> keywords)
    {
        this.Name = name;
        this.Surname = surname;
        this.Keywords = keywords;
    }

    public override string ToString()
    {
        return $@"
==============================
Client: {this.Name} {this.Surname} ({this.Id})
Keywords: {string.Join(", ", this.Keywords)}
==============================
";
    }

    public static void DisplayClients(List<Client> clients)
    {
        if (clients.Count == 0)
        {
            Console.WriteLine("No clients found");
            return;
        }

        Console.WriteLine("============================================================================");
        Console.WriteLine("|   Id   |   Name   |   Surname   |   Keywords                                    |");
        Console.WriteLine("============================================================================");
        foreach (Client client in clients)
        {
            Console.WriteLine($"|   {client.Id}   |   {client.Name}   |   {client.Surname}   |   {string.Join(", ", client.Keywords)}   |");
        }
        Console.WriteLine("============================================================================");
    }
}