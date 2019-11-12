namespace OzenIpTVWithDatabase.Migrations
{
    using OzenIpTVWithDatabase.Database;
    using OzenIpTVWithDatabase.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<OzenIpTVWithDatabase.Database.ProjectDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OzenIpTVWithDatabase.Database.ProjectDbContext context)
        {
            List<string> liste = new List<string>();
            List<string> kanal = new List<string>();
            List<string> kategori = new List<string>();

            StreamReader oku = new StreamReader(@"C:\Users\umity\source\repos\umtylmz\Works\OzenIpTv\OzenIpTVWithDatabase\Documents\deneme.txt", Encoding.UTF8);

            while (!oku.EndOfStream)
            {
                liste.Add(oku.ReadLine());
            }

            foreach (string item in liste)
            {
                string tempKanal = "", tempKategori = "";
                int tempIndex = 0;

                for (int i = 8; i < item.Length; i++)
                {
                    if (item[i].ToString() == "<")
                    {
                        tempIndex = i;
                        break;
                    }

                    tempKanal += item[i];
                }

                for (int i = tempIndex + 9; i < item.Length - 10; i++)
                {
                    tempKategori += item[i];
                }

                kanal.Add(tempKanal);
                kategori.Add(tempKategori);
            }

            List<string> kategoriler = kategori.Distinct().ToList();

            ProjectDbContext _db = new ProjectDbContext();

            foreach (string item in kategoriler)
            {
                _db.Categories.Add(new Category() { Name = item });
            }

            for (int i = 0; i < kanal.Count - 1; i++)
            {
                Channel newChannel = new Channel();
                newChannel.Name = kanal[i];
                newChannel.CategoryID = 1 + kategoriler.FindIndex(a => a == kategori[i]);

                _db.Channels.Add(newChannel);
                _db.SaveChanges();
            }
        }
    }
}
