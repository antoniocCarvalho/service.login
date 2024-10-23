using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.Register.Domain.Aggregates;


namespace Service.Register.Infra.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");


            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(x => x.Name)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.Senha)
                   .HasMaxLength(255)
                   .IsRequired();
        }



    }
 }

