using System;
using System.Collections.Generic;

namespace NHL.Models.Database
{
    public partial class Team
    {
        public Team()
        {
            MatchTeam1Navigations = new HashSet<Match>();
            MatchTeam2Navigations = new HashSet<Match>();
            Players = new HashSet<Player>();
        }

        public string Name { get; set; } = null!;
        public long? Points { get; set; }
        public string? Conference { get; set; }
        public string? Division { get; set; }

        public virtual ICollection<Match> MatchTeam1Navigations { get; set; }
        public virtual ICollection<Match> MatchTeam2Navigations { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
