using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartWorkout.DataAccess.Entities;
using SmartWorkout.DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess.Configurations
{
    internal class FollowRequestConfiguration : IEntityTypeConfiguration<FollowRequest>
    {
        public void Configure(EntityTypeBuilder<FollowRequest> builder)
        {
            builder.HasOne(fr => fr.Requester)
            .WithMany(u => u.FollowRequestsSent)
            .HasForeignKey(fr => fr.RequesterId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(fr => fr.Receiver)
            .WithMany(u => u.FollowRequestsReceived)
            .HasForeignKey(fr => fr.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("FollowRequest");
        }
    }
}
