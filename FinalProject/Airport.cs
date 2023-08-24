//Jacob Race 12/4/2022

public class Airport {

    protected string AirportCode {get; set;}
    private AirportStatus Status;

    public Airport(string airportCode, AirportStatus status) {
        AirportCode = airportCode;
        Status = status;
    }

    public string getAirportCode(){
        return AirportCode;
    }






}