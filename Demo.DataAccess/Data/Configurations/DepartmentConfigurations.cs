

namespace Demo.DataAccess.Data.Configurations
{
    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Name).HasColumnType("Varchar(20)");
            builder.Property(D => D.Code).HasColumnType("Varchar(20)");
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GETDATE()"); // dy btsta5dm mara wa7da
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GETDATE()"); // dy kol mara by3mlah Calculate
                
        }
    }
}
