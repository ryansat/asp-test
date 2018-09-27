using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Test1.Models;
using Test1.ViewModels;

namespace Test1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Coba!"};
            var customers = new List<Customer>
            {
               new Customer { Name = "Customer 1"  },
               new Customer { Name = "Customer 2"  }
            };

            var viewModel = new RandomMovieViewModel
            {
               Movie = movie,
               Customers = customers
            };

            return View(viewModel);
            //return Content("Test 123");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index","Home");
            //return RedirectToAction("Index", "Home", new { page = 1, sortby = "Name"});
        }

        public ActionResult Edit(int Id)
        {
            return Content("id="+ Id);
        }


        public ActionResult Index(int? pageIndex, string sortBy)
        {
               if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
               if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("pageIndex={0}&sortBy={1}",pageIndex,sortBy));
        }


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year,int month)
        {
            if (month <= 12)
            {
                return Content(year + "/" + month);
            }
            else
            {
                return Content("Month > 12!!");
            }
            
        }
    }
}