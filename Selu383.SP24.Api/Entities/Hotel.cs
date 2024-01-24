using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Selu383.SP24.Api.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }

    //public class HotelInformation : IEntityTypeConfiguration<Hotel> {
    //    public void Configure(EntityTypeBuilder<Hotel> builder)
      //  {
        //    builder
          //      .Property(x => x.Name)
            //    .HasMaxLength(120)
              //  .IsRequired();

            //builder
              //  .Property(x => x.Address)
                //.IsRequired();

            //builder
              //  .HasKey(x => x.Id);

        //}
    //}

    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }


}
