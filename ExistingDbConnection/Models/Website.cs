using System;
using System.Collections.Generic;

namespace ExistingDbConnection.Models
{
    public partial class Website
    {
        public int Id { get; set; }
        public string WebsiteName { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        public string Country { get; set; }
    }
}
