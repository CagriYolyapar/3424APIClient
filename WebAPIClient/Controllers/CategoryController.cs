using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIClient.DesignPatterns.SingletonPattern;
using WebAPIClient.Models;
using WebAPIClient.VMClasses;

namespace WebAPIClient.Controllers
{
    public class CategoryController : ApiController
    {
        NorthwindEntities db;
        public CategoryController()
        {
            db = DBTool.DBInstance;
        }

        public List<CategoryVM> GetAllCategories()
        {
            return db.Categories.Select(x => new CategoryVM
            {
                ID = x.CategoryID,
                Name = x.CategoryName,
                Description = x.Description
            }).ToList();
        }


        public CategoryVM GetCategory(int id)
        {
            return db.Categories.Where(x => x.CategoryID == id).Select(x => new CategoryVM
            {
                ID = x.CategoryID,
                Name = x.CategoryName,
                Description = x.Description
            }).Single();
        }

        [HttpPost]
        public List<CategoryVM> AddCategories(Category item)
        {
            db.Categories.Add(item);
            db.SaveChanges();
            return GetAllCategories();
        }

        [HttpPut]
        public List<CategoryVM> UpdateCategories(Category item)
        {
            Category guncellenecek = db.Categories.Find(item.CategoryID);
            db.Entry(guncellenecek).CurrentValues.SetValues(item);
            db.SaveChanges();
            return GetAllCategories();
        }

        [HttpDelete]
        public List<CategoryVM> DeleteCategory(int id)
        {
            db.Categories.Remove(db.Categories.Find(id));
            db.SaveChanges();
            return GetAllCategories();
        }
    }
}
