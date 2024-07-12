using SmartWorkout.DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess.Entities
{
    public class FollowRequest
    {
        public int Id { get; set; }
        public int RequesterId { get; set; }
        public User Requester { get; set; }
        public int ReceiverId { get; set; }
        public User Receiver { get; set; }
        public bool IsAccepted { get; set; }
    }
}
