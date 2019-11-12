using OzenIpTVWithDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;

namespace OzenIpTVWithDatabase.Database.Mappings
{
    public class ChannelMapping:EntityTypeConfiguration<Channel>
    {
        public ChannelMapping()
        {
            HasRequired(a => a.Category).WithMany(a => a.Channels).HasForeignKey(a=>a.CategoryID);
        }
    }
}