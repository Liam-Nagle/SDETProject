using EarthDefenderModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EarthDefenderBusiness
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUDManager _crudManager = new CRUDManager();
            using(var db = new EarthDefenderContext())
            {
                _crudManager.UpdateUser(64, "L", "Nagle", "LNagle", "password");
            }

        }
    }
}
