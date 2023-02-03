using Microsoft.EntityFrameworkCore;

namespace Kolokwium1.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }
        protected MainDbContext()
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>(p =>
            {
                p.HasData(
                        new Project { IdTeam=1, Name="projekt1", Deadline= DateTime.Parse("2023-01-01") }
                    );

            });
            modelBuilder.Entity<Task>(p =>
            {
                p.HasData(
                        new Task {IdTask=1, Name="wymiana pieca", Description="description", Deadline= DateTime.Parse("2023-02-01"), IdTeam=1, IdAssignedTo=2,IdCreator=1,IdTaskType=1 }
                    );
            });
            modelBuilder.Entity<TaskType>(p =>
            {
                p.HasData(
                        new TaskType { IdTaskType=1, Name="it" }
                    );
            });
            modelBuilder.Entity<TeamMember>(p =>
            {
                p.HasData(
                        new TeamMember { IdTeamMember=1, FirstName="Jan", LastName="Niezbedny", Email="mail@wp.pl"},
                        new TeamMember { IdTeamMember = 2, FirstName = "Anna", LastName = "Niezbedna", Email = "mail2@wp.pl" }
                    );

            });
        }
    }

}


