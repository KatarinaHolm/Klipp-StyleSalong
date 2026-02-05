namespace Klipp_StyleSalong.DTOs
{
    public class BookingDto
    {
        public DateOnly Date { get; set; }

        public TimeOnly Time { get; set; }

        public string Hairdresser { get; set; }

        public string CustomerName { get; set; }

        public string PhoneNr { get; set; }
    }
}
