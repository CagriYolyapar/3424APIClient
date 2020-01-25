using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIClient.DesignPatterns.SingletonPattern
{
    using Models;
    public class DBTool
    {



        private DBTool() { }

        private static NorthwindEntities _dbInstance;

        public static NorthwindEntities DBInstance
        {
            get
            {

                if (_dbInstance == null)
                {

                    _dbInstance = new NorthwindEntities();
                }

                return _dbInstance;

            }
        }




    }
}