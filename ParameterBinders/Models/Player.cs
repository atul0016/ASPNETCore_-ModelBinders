using System.ComponentModel.DataAnnotations;

namespace ParameterBinders.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Player Id is Must")]
        public string PlayerId { get; set; }
        [Required(ErrorMessage = "Player Name is Must")]
        public string PlayerName { get; set; }
        [Required(ErrorMessage = "Game is Must")]
        public string Game { get; set; }
    }
}
