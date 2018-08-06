using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExistingDbConnection.Models;
using ExistingDbConnection.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ExistingDbConnection.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly coreDBContext dataContext;
       
        public HomeController(coreDBContext context)
        {
            dataContext = context;
        }
        


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            //var result = dataContext.Website.FromSql("Select * From Website").ToList();

            
            IQueryable<JoinDataVM> data = from Website in dataContext.Website
                                                   group Website by Website.Rank into rankGroup
                                                   select new JoinDataVM()
                                                   {
                                                       Rank = rankGroup.Key,
                                                       RankCount = rankGroup.Count()
                                                   };
             
             /*
            string query = "SELECT Id, Rank, COUNT(*) AS RankCount "
        + "FROM Website "
        + "WHERE ID > 0 "
        + "GROUP BY Rank, Id";
            IEnumerable<Website> data = dataContext.Website.FromSql(query);
            //var data = dataContext.Website.FromSql(query);

        */
            return View(data.ToList());

            //return View();
        }

        protected override void Dispose(bool disposing)
        {
            dataContext.Dispose();
            base.Dispose(disposing);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
