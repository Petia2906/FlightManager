namespace FlightManager.Models
{
    public class Reservation
    {
        
        public int ReservationID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public int EGN { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string TicketType { get; set; }
        public Reservation()
        {

        }

    }
}
