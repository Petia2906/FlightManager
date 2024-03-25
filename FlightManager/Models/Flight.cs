namespace FlightManager.Models
{
    public class Flight
    {
        public string FlightID { get; set; }
        public string FlightFrom { get; set; }
        public string FlightTo { get; set; }
        public DateTime TakeOffTime { get; set; }
        public DateTime LandingTime { get; set; }
        public string PlaneType { get; set; }
        public string PlaneNumber { get; set; }
        public string PilotName { get; set; }
        public int PlaneCapacity { get; set; }
        public int PlaneBusinessClassCapacity { get; set; }
    }
}
