//Jacob Race 12/4/2022

using System.Data.SQLite; 

public class FlightDb {

    public static void CreateTable(SQLiteConnection conn) 
    { 
        //creating a new table 
        string sql = 
            "CREATE TABLE IF NOT EXISTS AircraftList (\n" 
            + "   PlaneNum integer PRIMARY KEY\n" 
            + "   ,Registration varchar(20)\n" 
            + "   ,AircraftRange varChar(20)\n" 
            + "   ,Load varChar(20)\n)";
 
        SQLiteCommand cmd = conn.CreateCommand(); 
        cmd.CommandText = sql; 
        cmd.ExecuteNonQuery(); 
    } 
    //Add an entry into the database
     public static void AddAircraft(SQLiteConnection conn, Aircraft plane) 
    { 
        string sql = string.Format(
            "INSERT INTO AircraftList (Registration, AircraftRange, Load)"
            + "VALUES('{0}','{1}','{2}')",
             plane.getAircraftReg(), plane.getAircraftRange(), plane.getLoad()); 
        SQLiteCommand cmd = conn.CreateCommand(); 
        cmd.CommandText = sql; 
        cmd.ExecuteNonQuery(); 
    }
//update existing entries
    public static void UpdateAircraft(SQLiteConnection conn, Aircraft plane) 
    { 
        string sql = string.Format( 
            "UPDATE AircraftList SET Registration='{0}', AircraftRange='{1}', Load='{2}' " 
            + " WHERE PlaneNum={3}", plane.getAircraftReg(), plane.getAircraftRange(), plane.getLoad(), plane.PlaneNum); 
        SQLiteCommand cmd = conn.CreateCommand(); 
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery(); 
    } 
//Delete entry
    public static void DeleteAircraft(SQLiteConnection conn, int id) 
    { 
        string sql = string.Format("DELETE from AircraftList WHERE PlaneNum = {0}", id); 
        SQLiteCommand cmd = conn.CreateCommand(); 
        cmd.CommandText = sql; 
        cmd.ExecuteNonQuery(); 
    } 
//List of Entries
    public static List<Aircraft> GetAllAircraft(SQLiteConnection conn) 
    { 
        List<Aircraft> AircraftList = new List<Aircraft>(); 
        string sql = "SELECT * FROM AircraftList"; 
        SQLiteCommand cmd = conn.CreateCommand(); 
        cmd.CommandText = sql; 
 
        SQLiteDataReader rdr = cmd.ExecuteReader(); 
 
        while (rdr.Read()) 
        { 
            AircraftList.Add(new Aircraft( 
                rdr.GetInt32(0), 
                rdr.GetString(1),  
                rdr.GetString(2),
                rdr.GetString(3)
            )); 
        } 
 
        return AircraftList; 
    } 
 //Pull AircraftList
    public static Aircraft GetAircraft(SQLiteConnection conn, int id) 
    { 
        string sql = string.Format("SELECT * FROM AircraftList WHERE PlaneNum = {0}", id); 
 
        SQLiteCommand cmd = conn.CreateCommand(); 
        cmd.CommandText = sql; 
 
        SQLiteDataReader rdr = cmd.ExecuteReader(); 
 
        if (rdr.Read()) 
        { 
           return new Aircraft( 
                rdr.GetInt32(0), 
                rdr.GetString(1), 
                rdr.GetString(2),
                rdr.GetString(3) 
                
           );
        } 
        else 
        { 
            return new Aircraft(-1, string.Empty, string.Empty, string.Empty); 
        }

}
}