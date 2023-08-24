//Jacob Race 11.27.2022 Main Program

using System.Data.SQLite; 

public class SimpleDispatch
{ 
    public static void Main(string[] args) 
    { 

        Console.WriteLine("\nSimpleDispatch by Jacob Race\n");
        Console.WriteLine("--------------------------------\n");

        const string dbName = "FlightDb.db";
        SQLiteConnection conn = SQLiteDatabase.Connect(dbName); 

        
        Aircraft Plane = new Aircraft("N123BG", "Long", "Heavy");

        AirportStatus hub = new AirportStatus(true, true);
        AirportStatus crewBase = new AirportStatus(true, false);
        AirportStatus none = new AirportStatus(false, false);

        Airport Atlanta = new Airport("ATL", hub);
        Airport Beach = new Airport("MYR", none);
        Airport Orlando = new Airport("MCO", crewBase);

        Flight flightOne = new Flight(1, 1.30, Atlanta, Plane);


    if (conn != null) 
        {
        FlightDb.CreateTable(conn);
        //instances created 

        FlightDb.AddAircraft(conn, new Aircraft("N123BG", "Long", "Heavy"));
        FlightDb.AddAircraft(conn, new Aircraft("N320DR", "Medium", "Medium"));
        FlightDb.AddAircraft(conn, new Aircraft("N738BG", "Medium", "Medium"));
        FlightDb.AddAircraft(conn, new Aircraft("N700BG", "Short", "Small"));

        




        

        //Print all entries
        PrintAircraft(FlightDb.GetAllAircraft(conn));
        Aircraft toUpdateAircraft = new Aircraft(4, "N550DR", "Medium", "Small");
        FlightDb.UpdateAircraft(conn, toUpdateAircraft);
        Aircraft updatedAircraft = FlightDb.GetAircraft(conn, toUpdateAircraft.PlaneNum);
        Console.WriteLine("Plane data changed");
        PrintAircraft(updatedAircraft);


        Console.WriteLine("Changed DB");
        FlightDb.DeleteAircraft(conn, toUpdateAircraft.PlaneNum);
        PrintAircraft(FlightDb.GetAllAircraft(conn));

    }
}

private static void PrintAircraft(List<Aircraft> Aircrafts) {
        foreach (Aircraft f in Aircrafts) {
            PrintAircraft(f);
        }
    }


private static void PrintAircraft(Aircraft p)
    {
        Console.WriteLine("Aircraft Number: " + p.PlaneNum + "\n"+
                "Registration: " + p.getAircraftReg() + "\n" +
                "Aircraft Range: " + p.getAircraftRange() + "\n" +
                "Aircraft Load: " + p.getLoad()+ "\n");
                
    }
}

