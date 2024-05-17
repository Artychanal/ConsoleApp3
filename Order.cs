
namespace ConsoleApp3.solution.client;

public class Order
{
    public long Id { get; set; }
    public long ClientId { get; set; }
    public long HotelId { get; set; }
    public long RoomId { get; set; }
    public long Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }

    public Order(long clientId, long hotelId, long roomId, long price, DateTime startDate, DateTime endDate, string description)
    {
        this.ClientId = clientId;
        this.HotelId = hotelId;
        this.RoomId = roomId;
        this.Price = price;
        this.StartDate = startDate;
        this.EndDate = endDate;
        this.Description = description;
    }

    public override string ToString()
    {
        return $@"
==============================
Reservation: {this.Id}
Client: {this.ClientId}
Hotel: {this.HotelId}
Room: {this.RoomId}
Start date: {this.StartDate:yyyy-MM-dd}
End date: {this.EndDate:yyyy-MM-dd}
Description: {this.Description}
==============================
";
    }

    public static void PrintOrders(List<Order> orders)
    {
        if (orders.Count == 0)
        {
            Console.WriteLine("No reservations found");
            return;
        }

        Console.WriteLine("===========================================");
        Console.WriteLine("| Id | Client | Hotel | Room | Price | Start date | End date | Description |");
        Console.WriteLine("===========================================");
        foreach (Order order in orders)
        {
            Console.WriteLine($"| {order.Id} | {order.ClientId} | {order.HotelId} | {order.RoomId} | {order.Price} | {order.StartDate:yyyy-MM-dd} | {order.EndDate:yyyy-MM-dd} | {order.Description,-11} |");
        }
        Console.WriteLine("===========================================");
    }
}