using System;

namespace SEDC.Football.Domain.Models
{
    public class Match : Entity
    {
        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime PlayedOn { get; set; }

        public virtual Team HomeTeam { get; set; }

        public virtual Team AwayTeam { get; set; }
    }
}
