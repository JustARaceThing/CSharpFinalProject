//Jacob Race 11.27.2022 AirportStatus Class

//Derives from Flight 
//  {delete once compl} 11/27/2022 might shift some methods from flight to here in the near future -> Airport mover elsewhere
//  {12/4/2022 Update} Keeping this as is to show polymorphism needs better implimentation

public class AirportStatus {
    public bool IsCrewBase{ get; set;}
    public bool IsHub{ get; set; }

    public AirportStatus(bool isCrewBase, bool isHub) {
        IsCrewBase = isCrewBase;
        IsHub = isHub;
    }
    
    //Getstatus specifically declare which airport is the hub/base
    

    public string getStatus(Airport a) 
    {
        if (IsCrewBase) {
            if(IsHub) {
                return a.getAirportCode() + " (Hub)";
            }
            else
            {
                return a.getAirportCode() + " (Crew Base)";
            }
        }
        else 
        {
            return a.getAirportCode();
        }
    }

}