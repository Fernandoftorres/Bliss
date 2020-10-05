using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlissRecruitment.Domain.Models;

namespace BlissRecruitment.Infra.Data.Mappings
{    
    public class QuestionChoiceMap : IEntityTypeConfiguration<QuestionChoice>
    {
        public void Configure(EntityTypeBuilder<QuestionChoice> builder)
        {
            
            builder.Property(c => c.Choice)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(e => e.Question)
                .WithMany(o => o.QuestionChoices)
                .HasForeignKey(e => e.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
