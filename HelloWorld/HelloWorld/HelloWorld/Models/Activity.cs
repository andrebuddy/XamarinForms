using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HelloWorld.Models
{
    public class Activity
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get { return $"https://randomuser.me/api/portraits/med/women/{UserId}.jpg"; } }

    }
}
