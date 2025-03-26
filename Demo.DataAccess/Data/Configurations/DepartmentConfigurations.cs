

using Demo.DataAccess.Models.DepartmentModel;

namespace Demo.DataAccess.Data.Configurations
{
    public class DepartmentConfigurations :BaseEntityConfigurations<Department>, IEntityTypeConfiguration<Department>
    {
        public new  void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Name).HasColumnType("Varchar(20)");
            builder.Property(D => D.Code).HasColumnType("Varchar(20)");
            base.Configure(builder);
                
        }
    }
}
