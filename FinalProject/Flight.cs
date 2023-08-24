/*Jacob Race 11/27/2022

Gives information based around the flight */

public class Flight : IFlightInfo {
    private int FlightNum {get; set;}
    private double FlightTime {get; set;}
    private Airport Airport;
    private Aircraft Plane;


    

    public Flight(int flightNum, double flightTime, Airport airport, Aircraft plane) {
        FlightNum = flightNum;
        FlightTime = flightTime;
        Airport = airport;
        Plane = plane;
    }
    

    public int getFlightNum() {
        return FlightNum;
    }


    public double flightTime() {
        return FlightTime;
    }

    public string cityPair(Airport a, Airport b) {
        string Route = a.getAirportCode() + " - " + b.getAirportCode();
        return Route;
    }

    public string ToString(Airport a, Airport b) {
        return "Flight Info: \n" + 
        "Flight Number: DLR" + getFlightNum() + "\n" +
        "Route: " + cityPair(a, b) + "\n" +
        "Flight Time: " + flightTime() + "\n" +
        "Aircraft Assigned: " + Plane;
    }

}