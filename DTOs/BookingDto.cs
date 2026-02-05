using System.ComponentModel.DataAnnotations;

namespace Klipp_StyleSalong.DTOs
{
    public class BookingDto
    {
        public DateOnly Date { get; set; }

        public TimeOnly Time { get; set; }

        public string Hairdresser { get; set; }

        [Required(ErrorMessage = "Du måste ange ett namn.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Namnet måste vara mellan 1 och 100 bokstäver.")]
        public string CustomerName { get; set; }

        [Phone]
        public string PhoneNr { get; set; }
    }
}
