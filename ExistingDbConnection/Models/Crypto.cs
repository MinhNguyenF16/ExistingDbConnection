using System;
using System.Collections.Generic;

namespace ExistingDbConnection.Models
{
    public partial class Crypto
    {
        public int Id { get; set; }
        public string CryptoName { get; set; }
        public string Type { get; set; }
        public int? Price { get; set; }
        public string Country { get; set; }
    }
}
