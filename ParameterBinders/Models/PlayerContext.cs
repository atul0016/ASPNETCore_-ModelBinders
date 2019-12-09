﻿using Microsoft.EntityFrameworkCore;

namespace ParameterBinders.Models
{
    public class PlayerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public PlayerContext(DbContextOptions<PlayerContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
