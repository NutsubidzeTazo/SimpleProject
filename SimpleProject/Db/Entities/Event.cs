using System.ComponentModel.DataAnnotations;

namespace SimpleProject.Db.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string EventName { get; set; }
        public decimal FirstWinnerMultiplier { get; set; }
        public decimal SecondWinnerMultiplier { get; set; }
    }
}
