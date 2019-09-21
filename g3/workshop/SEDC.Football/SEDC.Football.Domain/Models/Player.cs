using SEDC.Football.Domain.Enums;

namespace SEDC.Football.Domain.Models
{
    public class Player : Entity
    {
        public string FullName { get; set; }

        public byte SquadNumber { get; set; }

        public Position Position { get; set; }

        public int Age { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
