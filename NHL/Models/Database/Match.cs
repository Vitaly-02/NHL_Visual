using System;
using System.Collections.Generic;

namespace NHL.Models.Database
{
    public partial class Match
    {
        public string Name { get; set; } = null!;
        public string? Team1 { get; set; }
        public string? Team2 { get; set; }
        public string? Place { get; set; }

        public virtual Result NameNavigation { get; set; } = null!;
        public virtual Team? Team1Navigation { get; set; }
        public virtual Team? Team2Navigation { get; set; }
    }
}
