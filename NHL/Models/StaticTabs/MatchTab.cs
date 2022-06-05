using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NHL.Models.Database;
using System.Linq;

namespace NHL.Models.StaticTabs
{
    public class MatchTab : StaticTab
    {
        public MatchTab(string h = "", DbSet<Match>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("Name");
            DataColumns.Add("Team1");
            DataColumns.Add("Team2");
            DataColumns.Add("Place");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<Match>? DBS { get; set; }
    }
}
