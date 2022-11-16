using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id); //HasKey cria uma chave primária

            builder.HasIndex(x => x.Email)
                .IsUnique(); //Unique é unico, ou seja, o email nao pode repetir
                               
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(x => x.Email)
                .HasMaxLength(100);

            

        }
    }
}
