using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NHL.Models.Database;
using System.Linq;

namespace NHL.Models.StaticTabs
{
    public class ResultTab : StaticTab
    {
        public ResultTab(string h = "", DbSet<Result>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("MatchName");
            DataColumns.Add("Score");
            DataColumns.Add("TypeOfWin");
            DataColumns.Add("Duration");
            DataColumns.Add("Deletions");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<Result>? DBS { get; set; }
    }
}
