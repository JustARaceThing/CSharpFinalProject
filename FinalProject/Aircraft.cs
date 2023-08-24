/*Jacob Race 11/27/2022

Gives information based around aircraft*/

public class Aircraft {

    public int PlaneNum {get; set;}
    private string Registration{ get; set;}
    private string AircraftRange {get; set;}
    private string Load {get; set;}

    public Aircraft(int num, string reg, string range, string load) {
        PlaneNum = num;
        Registration = reg;
        AircraftRange = range;
        Load = load;
    }
    public Aircraft(string reg, string range, string load) {
        Registration = reg;
        AircraftRange = range;
        Load = load;
    }

    public string getAircraftReg() {
        return Registration;
    }

    public string getAircraftRange() {
        return AircraftRange;
    }

    public string getLoad() {
        return Load;
    }


}