
using Microsoft.EntityFrameworkCore;
using MusicMarket.Core.Models;
using MusicMarket.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicMarket.Data
{
    public class MusicMarketDbContext: DbContext
    {
        public MusicMarketDbContext(DbContextOptions<MusicMarketDbContext> options) : base(options)
        {

        }
        //public MusicMarketDbContext()
        //{

        //}
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .ApplyConfiguration(new MusicConfiguration());

            modelBuilder
                .ApplyConfiguration(new ArtistConfiguration());
        }
    }
}
