using System.Collections.Generic;

namespace SEDC.Football.Domain.Models
{
    public class Team : Entity
    {
        public string Name { get; set; }

        public string Couch { get; set; }

        public virtual IEnumerable<Player> Players { get; set; }
    }
}
