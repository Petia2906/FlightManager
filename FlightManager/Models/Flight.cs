using System.ComponentModel.DataAnnotations;

namespace FlightManager.Models
{
    public class Flight
    {
        
        public int FlightID { get; set; }
        public string FlightFrom { get; set; }
        public string FlightTo { get; set; }
        public DateTime TakeOffTime { get; set; }
        public DateTime LandingTime { get; set; }
        public string PlaneType { get; set; }
        public int PlaneNumber { get; set; }
        public string PilotName { get; set; }
        public int PlaneCapacity { get; set; }
        public int PlaneBusinessClassCapacity { get; set; }
        public Flight()
        {   

        }
}   }
