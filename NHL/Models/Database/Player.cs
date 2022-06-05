using System;
using System.Collections.Generic;

namespace NHL.Models.Database
{
    public partial class Player
    {
        public string Fio { get; set; } = null!;
        public string? TeamName { get; set; }
        public long? Age { get; set; }
        public string? BirthDate { get; set; }
        public string? Position { get; set; }

        public virtual Team? TeamNameNavigation { get; set; }
    }
}
