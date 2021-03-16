using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAppDb
    {
        public class SQLiteDbContext : DbContext
        {
            public DbSet<WatchList> WatchList { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source=sqlitedemo.db");
        }
    }

