using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Mvc.GiftShopApp.Core.Models.ContextDB
{
    public class CoreDbContext : DbContext
    {

        public CoreDbContext():base("AppConnection")
        {
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<CartItem> Cart { get; set; }

        public DbSet<Sale> Sale{ get; set; }

        public DbSet<SaleDetail> SaleDetail { get; set; }

        public IDbSet<Role> Role { get; set; }

        public IDbSet<UserRole> UserRole { get; set; }

        public IDbSet<User> User { get; set; }
        public IDbSet<Category> Category { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ModelNamespaceConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Add mappings
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var builder = new StringBuilder(ex.Message);

                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    builder.AppendLine().Append(entityValidationErrors.Entry.Entity.GetType())
                        .AppendLine(" errors:");

                    foreach (var error in entityValidationErrors.ValidationErrors)
                    {
                        builder
                            .Append("\t")
                            .Append(error.PropertyName)
                            .Append(": ")
                            .AppendLine(error.ErrorMessage);
                    }
                }

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(builder.ToString(), ex.EntityValidationErrors);
            }
        }
    }
}
