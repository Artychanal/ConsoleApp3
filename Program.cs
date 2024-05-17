using ConsoleApp3.solution.client;
using ConsoleApp3.solution.hotel;
using ConsoleApp3.solution.services;
using ConsoleApp3.solution.services.impl;
namespace ConsoleApp3;
class Program
{
    static readonly IService<Hotel> HotelService = new HotelService();
    static readonly IService<Client> ClientService = new ClientService();

    static void Main()
    {
        bool programIsRunning = true;
        while (programIsRunning)
        {
            int chosenOption = Interface.CreateLayout("Hotel System ", "Hotel Management",
                "Client Management", "Reservation Management", "Exit");
            switch (chosenOption)
            {
                case 0:
                    HotelManagementMenu();
                    break;
                case 1:
                    ClientManagementMenu();
                    break;
                case 2:
                    ReservationManagementMenu();
                    break;
                case 3:
                    programIsRunning = false;
                    break;
            }
        }

        Environment.Exit(0);
    }

    static void HotelManagementMenu()
    {
        int chosenOption = Interface.CreateLayout("Hotel Management Menu",
            "Create Hotel",
            "Update Hotel",
            "Delete Hotel",
            "List Hotels",
            "Find Certain Hotel",
            "Search Hotel by Keywords",
            "Examine hotel rooms",
            "Back to Main Menu");
        switch (chosenOption)
        {
            case 0:
                CreateHotel();
                break;
            case 1:
                UpdateHotel();
                break;
            case 2:
                DeleteHotel();
                break;
            case 3:
                ListHotels();
                break;
            case 4:
                FindCertainHotel();
                break;
            case 5:
                FindHotelsByKeywords();
                break;
            case 6:
                ExamineRooms();
                break;
            case 7:
                return;
        }
    }

    private static void FindCertainHotel()
    {
        Hotel hotel;
        try
        {
            hotel = GetValidHotel("Enter Hotel Id to display:");
        }
        catch (Exception)
        {
            return;
        }

        Console.Clear();
        Console.WriteLine(hotel);
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ClientManagementMenu()
    {
        int chosenOption = Interface.CreateLayout("Client Management Menu",
            "Create Client",
            "Update Client",
            "Delete Client",
            "Find Certain Client",
            "List Clients",
            "Search clients by Keywords", 
            "Back to Main Menu");
        switch (chosenOption)
        {
            case 0:
                CreateClient();
                break;
            case 1:
                UpdateClient();
                break;
            case 2:
                DeleteClient();
                break;
            case 3:
                FindCertainClient();
                break;
            case 4:
                ListClients();
                break;
            case 5:
                FindClientsByKeyword();
                break;
            case 6:
                return;
        }
    }

    private static void FindCertainClient()
    {
        Client client;
        try
        {
            client = GetValidClient("Enter Client Id to display:");
        }
        catch (Exception)
        {
            return;
        }

        Console.Clear();
        Console.WriteLine(client);
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ReservationManagementMenu()
    {
        int option = Interface.CreateLayout("Reservation Management Menu",
            "Create Reservation",
            "Update Reservation",
            "Cancel Reservation",
            "List Reservations",
            "Back to Main Menu");
        switch (option)
        {
            case 0:
                CreateReservation();
                break;
            case 1:
                UpdateReservation();
                break;
            case 2:
                CancelReservation();
                break;
            case 3:
                ListReservations();
                break;
            case 4:
                return;
        }
    }

    static void CreateHotel()
    {
        var name = GetValidString("Enter the hotel Name:");
        var description = GetValidString("Enter the hotel Description:");
        var capacity = int.Parse(GetValidString("Enter the hotel Capacity:"));
        List<string> keywords = GetValidKeywords("Enter the hotel Keywords ():");
        var hotel = new Hotel(name, description, capacity, keywords);
        HotelService.Save(hotel);
        Console.WriteLine("Hotel was created successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void UpdateHotel()
    {
        Hotel hotel;
        try
        {
            hotel = GetValidHotel("Enter the hotel Id to update(starting from 1):");
        }
        catch (Exception)
        {
            return;
        }

        var name = GetValidString("Enter the new hotel Name:");
        var description = GetValidString("Enter the new hotel Description:");
        var capacityInput = GetValidString("Enter the new hotel Capacity:");
        List<string> keywords = GetValidKeywords("Enter the new hotel Keywords:");
        hotel.Name = name;
        hotel.Description = description;
        hotel.Capacity = int.Parse(capacityInput);
        hotel.Keywords = keywords;
        HotelService.Save(hotel);
        Console.WriteLine("Hotel was updated successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void DeleteHotel()
    {
        Hotel hotel;
        try
        {
            hotel = GetValidHotel("Enter the hotel Id to delete:");
        }
        catch (Exception)
        {
            return;
        }

        HotelService.Delete(hotel.Id);
        Console.WriteLine("Hotel was deleted successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ListHotels()
    {
        Console.Clear();
        var hotels = HotelService.GetAll();
        Hotel.PrintHotels(hotels);
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void FindHotelsByKeywords()
    {
        var keywords = GetValidKeywords("Enter the hotel Keywords to find Certain:");
        var hotels = HotelService.FindAll(keywords);
        foreach (var hotel in hotels)
        {
            Console.WriteLine(hotel);
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private static void ExamineRooms()
    {
        Hotel hotel;
        try
        {
            hotel = GetValidHotel("Enter the hotel Id to examine rooms:");
        }
        catch (Exception)
        {
            return;
        }

        Console.Clear();
        Console.Clear();
        Console.WriteLine($"Rooms for {hotel.Name}:");
        foreach (var room in hotel.Rooms)
        {
            Console.WriteLine(room.ToString()); 
        }
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();

    }

    static void CreateClient()
    {
        var name = GetValidString("Enter the client Name:");
        var surname = GetValidString("Enter the client Surname:");
        List<string> keywords = GetValidKeywords("Enter the client Keywords ():");
        var client = new Client(name, surname, keywords);
        ClientService.Save(client);
        Console.WriteLine("Client added successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void UpdateClient()
    {
        Client client;
        try
        {
            client = GetValidClient("Enter the client Id to update:");
        }
        catch (Exception)
        {
            return;
        }

        var name = GetValidString("Enter the new client Name:");
        var surname = GetValidString("Enter the new client Surname:");
        client.Name = name;
        client.Surname = surname;
        ClientService.Save(client);
        Console.WriteLine("Client was updated successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void DeleteClient()
    {
        Client client;
        try
        {
            client = GetValidClient("Enter the client Id to delete:");
        }
        catch (Exception)
        {
            return;
        }

        ClientService.Delete(client.Id);
        Console.WriteLine("Client was deleted successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ListClients()
    {
        Console.Clear();
        var clients = ClientService.GetAll();
        foreach (var client in clients)
        {
            Console.WriteLine(client.ToString());
        }

        ClientService.SortField currentSortField = solution.services.impl.ClientService.SortField.Name;
        ClientService.SortOrder currentSortOrder =
            solution.services.impl.ClientService.SortOrder.Asc;
        while (true)
        {
            Console.WriteLine("\nSorting by " + currentSortField + " in " + currentSortOrder + " order:");
            Console.WriteLine(
                "\nPress UP arrow to change sorting order, prees DOWN arrow to change sorting field, or press ENTER to exit...");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (currentSortOrder ==
                    solution.services.impl.ClientService.SortOrder.Asc)
                {
                    currentSortOrder = solution.services.impl.ClientService.SortOrder.Desc;
                }
                else
                {
                    currentSortOrder = solution.services.impl.ClientService.SortOrder.Asc;
                }

                Console.Clear();
                Console.Clear();
                List<Client> sortedClients = ClientService.GetAll(currentSortField, currentSortOrder);
                foreach (var client in sortedClients)
                {
                    Console.WriteLine(client.ToString()); 
                }

            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (currentSortField == solution.services.impl.ClientService.SortField.Name)
                {
                    currentSortField = solution.services.impl.ClientService.SortField.Surname;
                }
                else
                {
                    currentSortField = solution.services.impl.ClientService.SortField.Name;
                }

                Console.Clear();
                Console.Clear();
                List<Client> sortedClients = ClientService.GetAll(currentSortField, currentSortOrder);
                foreach (var client in sortedClients)
                {
                    Console.WriteLine(client.ToString());
                }

            }
            else if (key.Key == ConsoleKey.Enter)
            {
                break;
            }
        }
    }

    static void FindClientsByKeyword()
    {
        var keywords = GetValidKeywords("Enter the keywords to find:");
        var clients = ClientService.FindAll(keywords);
        foreach (var client in clients)
        {
            Console.WriteLine(client);
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void CreateReservation()
    {
        Client client;
        try
        {
            client = GetValidClient("Enter the client Id to associate with Reservation:");
        }
        catch (Exception)
        {
            return;
        }

        Hotel hotel;
        try
        {
            hotel = GetValidHotel("Enter the hotel Id to associate with Reservation:");
        }
        catch (Exception)
        {
            return;
        }

        long roomId;
        try
        {
            roomId = GetValidRoom("Enter the room Id:", hotel).Id;
        }
        catch (Exception)
        {
            return;
        }

        DateOnly startDate = GetValidDate("Enter the Start Date (format: yyyy-MM-dd):");
        DateOnly endDate = GetValidDate("Enter the End Date (format: yyyy-MM-dd):");


        var description = GetValidString("Enter the reservation Description:");
        long price = (endDate.DayOfYear - startDate.DayOfYear) * hotel.Rooms.First(r => r.Id == roomId).Price;
        var reservation = new Order(client.Id, hotel.Id, roomId, price,
            new DateTime(startDate.Year, startDate.Month, startDate.Day),
            new DateTime(endDate.Year, endDate.Month, endDate.Day),
            description);

        hotel.AddReservation(reservation);
        HotelService.Save(hotel);
        Console.WriteLine("Reservation was created successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void UpdateReservation()
    {
        Hotel hotel;
        try
        {
            hotel = GetValidHotel("Enter the hotel Id associated with Reservation:");
        }
        catch (Exception)
        {
            return;
        }

        Order reservation;
        try
        {
            reservation = GetValidReservation("Enter the reservation Id to update:", hotel);
        }
        catch (Exception)
        {
            return;
        }

        var startDateInput = GetValidDate("Enter the new Start Date (format: yyyy-MM-dd):");
        var endDateInput = GetValidDate("Enter the new End Date (format: yyyy-MM-dd):");
        var description = GetValidString("Enter the new reservation Description: ");
        reservation.StartDate = new DateTime(startDateInput.Year, startDateInput.Month, startDateInput.Day);
        if (endDateInput != DateOnly.MinValue)
        {
            reservation.EndDate = new DateTime(endDateInput.Year, endDateInput.Month, endDateInput.Day);
        }



        reservation.Description = description;
        hotel.UpdateReservation(reservation);
        HotelService.Save(hotel);
        Console.WriteLine("Reservation was updated successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void CancelReservation()
    {
        Hotel hotel;
        try
        {
            hotel = GetValidHotel("Enter the hotel Id associated with Reservation");
        }
        catch (Exception)
        {
            return;
        }

        var id = GetValidLong("Enter the reservation Id to cancel:");
        try
        {
            var reservation = hotel.Reservations.FirstOrDefault(r => r.Id == id) ?? throw
                new Exception();
            hotel.Rooms.First(r => r.Id == reservation.RoomId).IsReserved = false;
            hotel.RemoveReservation(reservation);
        }
        catch (Exception)
        {
            Console.WriteLine("There are no reservations associated with this hotel or reservation was not found");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        HotelService.Save(hotel);
        Console.WriteLine("Reservation was canceled successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ListReservations()
    {
        Console.Clear();
        var hotels = HotelService.GetAll();
        foreach (var hotel in hotels)
        {
            if (hotel.Reservations.Count != 0)
            {
                Console.WriteLine($"Current reservations for {hotel.Name}:");
                foreach (var reservation in hotel.Reservations)
                {
                    Console.WriteLine(reservation.ToString());
                }
            }

        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    
    private static string GetValidString(string message)
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                Console.Clear();
                return input;
            }

            Console.WriteLine("Invalid input! Try again.");
        }
    }

    private static Client GetValidClient(string message)
    {
        Console.Clear();
        while (true)
        {
            long id = GetValidLong(message);
            try
            {
                return ClientService.Get(id);
            }
            catch (Exception)
            {
                Console.WriteLine("Client was not found! Try again.");
                List<Client> clients = ClientService.GetAll();
                if (clients.Count > 0)
                {
                    Console.WriteLine("Possible clients:");
                    foreach (var client in clients)
                    {
                        Console.WriteLine(client);
                    }
                }
                else
                {
                    Console.WriteLine("No clients were found! Create one first");
                    Console.WriteLine("Press any key to exit to Main Menu...");
                    Console.ReadKey();
                    throw new Exception("Client was not found");
                }
            }
        }
    }

    private static Hotel GetValidHotel(string message)
    {
        Console.Clear();
        while (true)
        {
            long id = GetValidLong(message);
            try
            {
                return HotelService.Get(id);
            }
            catch (Exception)
            {
                Console.WriteLine("Hotel was not found! Try again.");
                List<Hotel> hotels = HotelService.GetAll();
                if (hotels.Count > 0)
                {
                    Console.WriteLine("Possible hotels:");
                    foreach (var hotel in hotels)
                    {
                        Console.WriteLine(hotel);
                    }
                }
                else
                {
                    Console.WriteLine("No hotels were found! Create one first");
                    Console.WriteLine("Press any key to exit to Main Menu...");
                    Console.ReadKey();
                    throw new Exception("Hotel not found");
                }
            }
        }
    }

    private static Room GetValidRoom(string message, Hotel hotel)
    {
        Console.Clear();
        while (true)
        {
            long id = GetValidLong(message);
            try
            {
                return hotel.Rooms.First(r => r.Id == id);
            }
            catch (Exception)
            {
                Console.WriteLine("Room was not found! Try again.");
                List<Room>? rooms = hotel.Rooms;
                if (rooms == null)
                {
                    Console.WriteLine("No rooms were found! Create one first");
                    Console.WriteLine("Press any key to exit to the Main Menu ...");
                    Console.ReadKey();
                    throw new Exception("Room was not found");
                }
            }
        }
    }

    private static Order GetValidReservation(string message, Hotel hotel)
    {
        Console.Clear();
        while (true)
        {
            long id = GetValidLong(message);
            try
            {
                return hotel.Reservations.First(r => r.Id == id);
            }
            catch (Exception)
            {
                Console.WriteLine("Reservation was not found! Try again.");
                List<Order>? reservations = hotel.Reservations;
                if (reservations == null)
                {
                    Console.WriteLine("\nNo reservations were found! Create one first");
                    Console.WriteLine("\nPress any key to exit to the Main Menu...");
                    Console.ReadKey();
                    throw new Exception("Reservation was not found");
                }
            }
        }
    }

    private static long GetValidLong(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();
            if (long.TryParse(input, out var result))
            {
                Console.Clear();
                return result;
            }

            Console.WriteLine("Invalid number input! Try again.");
        }
    }

    private static DateOnly GetValidDate(string message)
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();
            if (DateOnly.TryParse(input, out var result))
            {
                Console.Clear();
                return result;
            }

            Console.WriteLine("Invalid DateTime input! Try again.");
        }
    }

    private static List<string> GetValidKeywords(string
        enterHotelKeywords)
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine(enterHotelKeywords);
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                Console.Clear();
                return input.Split(",").ToList();
            }

            Console.WriteLine("Invalid input! Try again.");
        }
    }
}