using System;
using System.Collections.Generic;

namespace ExistingDbConnection.Models
{
    public partial class Todo
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
    }
}
