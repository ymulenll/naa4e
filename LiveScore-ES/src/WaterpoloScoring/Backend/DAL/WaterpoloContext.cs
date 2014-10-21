using System.Data.Entity;
using WaterpoloScoring.Backend.ReadModel.Dto;

namespace WaterpoloScoring.Backend.DAL
{
    public class WaterpoloContext : DbContext
    {
        public WaterpoloContext() : base("naa4e_Waterpolo")
        {
        }

        public DbSet<LiveMatch> Matches { get; set; }
    }
}