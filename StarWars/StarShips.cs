using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using SharpTrooper.Core;

namespace StarWars
{
    public class Starships
    {
        public List<string> GetStarshipData(int userPassengerRequirement, int userCargoRequirement)
        {
            try
            {
                //get data from API
                SharpTrooperCore core = new SharpTrooperCore();
                var starship = core.GetAllStarships("1");
                List<string> displayData = new List<string>();

                bool lastIteration = false;
                string pageNumber = "1";
                int passengers = 0;
                int cargo = 0;
                string pilotId = "";
                
                //loop until next page data is null
                while (lastIteration == false)
                {
                    starship = core.GetAllStarships(pageNumber);
                    foreach (var returnedStarship in starship.results)
                    {
                        if (returnedStarship.passengers != null && returnedStarship.passengers != "")
                            passengers = Utilities.GetIntValue(returnedStarship.passengers.ToString());
                        else
                            passengers = 0;

                        if (returnedStarship.cargo_capacity != null && returnedStarship.cargo_capacity != "")
                            cargo = Utilities.GetIntValue(returnedStarship.cargo_capacity.ToString());
                        else
                            cargo = 0;
                        //confirm ship is capable of handling passenger request
                        if (passengers >= userPassengerRequirement && cargo >= userCargoRequirement)
                            //loop assigned pilots if any exist
                            if (returnedStarship.pilots.Count() > 0)
                            {
                                foreach (var pilot in returnedStarship.pilots)
                                {
                                    pilotId = Utilities.GetIDNumber(pilot);
                                    var myPilot = core.GetPeople(pilotId);
                                    displayData.Add(returnedStarship.name + " - " + myPilot.name + " Passenger Capacity: " + passengers + " Cargo Capacity: " + cargo);
                                }
                            }
                            else
                            {
                                displayData.Add(returnedStarship.name + " - Pilot:" + "N/A" + " Passenger Capacity: " + passengers + " Cargo Capacity: " + cargo);
                            }
                    }

                    //set value to stop iterations
                    if (starship.next == null)
                    {
                        lastIteration = true;
                    }
                    else
                    {
                        string nextPageNumber = Utilities.GetPageNumber(starship.next);
                        if (nextPageNumber != "")
                            pageNumber = nextPageNumber;
                        else
                            lastIteration = true;
                    }
                }

                //send data back to main for displaying
                return displayData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
