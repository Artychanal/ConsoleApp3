
namespace ConsoleApp3.solution.hotel;

public class Room
{
    public long Id { get; set; }
    public long Price { get; set; }
    public bool IsReserved { get; set; }

    public Room(long id, long price)
    {
        this.Id = id;
        this.Price = price;
    }

    public override string ToString()
    {
        return $@"
==============================
Room: {this.Id}
Price: {this.Price}
Taken: {this.IsReserved}
==============================
";
    }

    public static void PrintRooms(List<Room> rooms)
    {
        if (rooms.Count == 0)
        {
            Console.WriteLine("No rooms found");
            return;
        }

        Console.WriteLine("================================");
        Console.WriteLine("| Id | Price | Taken |");
        Console.WriteLine("================================");
        foreach (Room room in rooms)
        {
            Console.WriteLine($"| {room.Id} | {room.Price} | {room.IsReserved} |");
        }
        Console.WriteLine("================================");
    }
}