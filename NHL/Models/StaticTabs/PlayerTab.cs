using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NHL.Models.Database;
using System.Linq;

namespace NHL.Models.StaticTabs
{
    public class PlayerTab : StaticTab
    {
        public PlayerTab(string h = "", DbSet<Player>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("Fio");
            DataColumns.Add("TeamName");
            DataColumns.Add("Age");
            DataColumns.Add("BirthDate");
            DataColumns.Add("Position");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<Player>? DBS { get; set; }
    }
}
