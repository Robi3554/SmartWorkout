﻿using SmartWorkout.DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess.Entities
{
    public class UserFollow
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int FollowerId { get; set; }
        public User Follower { get; set; }
    }
}
