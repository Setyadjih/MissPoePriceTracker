using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MissPoeAnalysis.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;


namespace MissPoeAnalysis.Core.Data;

public class DBContext : DbContext
{
    public DbSet<CostingItem> Items { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Build SQLite connection
        var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "ItemDatabase.db" };
        var connectionString = connectionStringBuilder.ToString();
        var connection = new SqliteConnection(connectionString);

        optionsBuilder.UseSqlite(connection);
    }
}

