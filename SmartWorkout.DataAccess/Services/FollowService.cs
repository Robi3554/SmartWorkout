using Microsoft.EntityFrameworkCore;
using SmartWorkout.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess.Services
{
    public class FollowService
    {
        private readonly SmartWorkoutContext _context;

        public FollowService(SmartWorkoutContext context)
        {
            _context = context;
        }

        public async Task SendFollowRequestAsync(int requesterId, int receiverId)
        {
            var followRequest = new FollowRequest
            {
                RequesterId = requesterId,
                ReceiverId = receiverId,
                IsAccepted = false
            };

            _context.FollowRequests.Add(followRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsFollowRequestSentAsync(int requesterId, int receiverId)
        {
            return await _context.FollowRequests
                .AnyAsync(fr => fr.RequesterId == requesterId && fr.ReceiverId == receiverId && !fr.IsAccepted);
        }

        public async Task<List<FollowRequest>> GetPendingFollowRequestsAsync(int userId)
        {
            return await _context.FollowRequests
                .Where(fr => fr.ReceiverId == userId && !fr.IsAccepted)
                .Include(fr => fr.Requester)
                .ToListAsync();
        }

        public async Task AcceptFollowRequestAsync(int followRequestId)
        {
            var followRequest = await _context.FollowRequests.FindAsync(followRequestId);
            if (followRequest != null)
            {
                followRequest.IsAccepted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeclineFollowRequestAsync(int followRequestId)
        {
            var followRequest = await _context.FollowRequests.FindAsync(followRequestId);
            if (followRequest != null)
            {
                _context.FollowRequests.Remove(followRequest);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FollowRequest>> GetReceivedFollowRequestsAsync(int userId)
        {
            return await _context.FollowRequests
                .Where(fr => fr.ReceiverId == userId && !fr.IsAccepted)
                .Include(fr => fr.Requester)
                .ToListAsync();
        }

        public async Task<FollowRequest> GetFollowRequestAsync(int requesterId, int receiverId)
        {
            return await _context.FollowRequests
                .FirstOrDefaultAsync(fr => fr.RequesterId == requesterId && fr.ReceiverId == receiverId);
        }

        public async Task<bool> IsFollowing(int currentUserId, int userIdToCheck)
        {
            try
            {
                var followRequest = await _context.FollowRequests
                    .FirstOrDefaultAsync(fr => fr.RequesterId == currentUserId && fr.ReceiverId == userIdToCheck && fr.IsAccepted);

                return followRequest != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking follow status: {ex.Message}");
                return false;
            }
        }
    }
}
