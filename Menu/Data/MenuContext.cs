using Microsoft.EntityFrameworkCore;
using Menu.Models;
namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishID,
                di.IngredientID
            });

            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishID);
            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientID);

            modelBuilder.Entity<Dish>().HasData(
                new Dish {
                    Id = 1, Name = "Magarita", Price = 7.65, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSOu966OtyyOj-T02fw8WFGOUkO_z3-VT9Fjg&s"
                });

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient {
                    Id = 1, 
                    Name = "Tomato source",
                },
                new Ingredient {
                    Id = 2,
                    Name = "Mozaralla source",
                });

            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient {DishID = 1, IngredientID = 1},
                new DishIngredient {DishID = 1, IngredientID = 2}
                );


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishesIngredients { get; set; }

    }
}
