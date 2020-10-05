using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlissRecruitment.Domain.Models;

namespace BlissRecruitment.Infra.Data.Mappings
{    
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            
            builder.Property(c => c.QuestionDescription)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.ImageUrl)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.ThumbUrl)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
