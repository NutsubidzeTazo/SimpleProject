namespace SimpleProject.Models.RequestModels
{
    public class BetRequestModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public decimal Amount { get; set; }
        public decimal Outcome { get => Amount * Multiplier; }
        public decimal Result { get; set; }
        public decimal Multiplier { get; set; }
    }
}
