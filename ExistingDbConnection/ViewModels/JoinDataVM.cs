using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExistingDbConnection.Models;
using System.ComponentModel.DataAnnotations;

namespace ExistingDbConnection.ViewModels
{
    public class JoinDataVM
    {
        public int Rank { get; set; }
        public int RankCount { get; set; }
        public Website WebsiteVM { get; set; }
        public Crypto CryptoVM { get; set; }
    }
}
