using System.ComponentModel.DataAnnotations;

namespace SimpleProject.Db.Entities
{
    public class Bet
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public decimal Amount { get; set; }
        public decimal Outcome { get => Amount * Multiplier; }
        public decimal? Result { get; set; }
        public decimal Multiplier { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
    }
}
