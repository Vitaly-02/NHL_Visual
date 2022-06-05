using System;
using System.Collections.Generic;

namespace NHL.Models.Database
{
    public partial class Result
    {
        public string MatchName { get; set; } = null!;
        public string? Score { get; set; }
        public string? TypeOfWin { get; set; }
        public byte[]? Duration { get; set; }
        public long? Deletions { get; set; }

        public virtual Match Match { get; set; } = null!;
    }
}
