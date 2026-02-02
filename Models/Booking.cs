namespace Klipp_StyleSalong.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public DateOnly Date{ get; set; }

        public TimeOnly Time { get; set; }

        public string Hairdresser { get; set; }

        public string CustomerName { get; set; }

        public string PhoneNr { get; set; }
    }
}
