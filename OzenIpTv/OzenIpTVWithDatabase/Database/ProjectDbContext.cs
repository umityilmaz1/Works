using OzenIpTVWithDatabase.Database.Mappings;
using OzenIpTVWithDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OzenIpTVWithDatabase.Database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext() : base("ConnStr")
        {

        }

        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ChannelMapping());
        }
    }
}