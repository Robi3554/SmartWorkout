using Microsoft.EntityFrameworkCore;
using SmartWorkout.DataAccess.Configurations;
using SmartWorkout.DataAccess.Entities;
using SmartWorkout.DBAccess.Configurations;
using SmartWorkout.DBAccess.Entities;

namespace SmartWorkout.DataAccess
{
    public class SmartWorkoutContext: DbContext
    {
        public SmartWorkoutContext() { }
        public SmartWorkoutContext(DbContextOptions<SmartWorkoutContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<User> Logs { get; set; }

        public DbSet<UserFollow> UserFollows { get; set; }
        public DbSet<FollowRequest> FollowRequests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new WorkoutConfiguration().Configure(modelBuilder.Entity<Workout>());
            new ExerciseConfiguration().Configure(modelBuilder.Entity<Exercise>());
            new ExerciseLogConfig().Configure(modelBuilder.Entity<ExerciseLog>());
            new FollowRequestConfiguration().Configure(modelBuilder.Entity<FollowRequest>());
            new UserFollowConfiguration().Configure(modelBuilder.Entity<UserFollow>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                var ConnectionString =
                    "Data Source=DESKTOP-MER90VE\\SQLEXPRESS;Initial Catalog=SmartWorkoutEF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}
