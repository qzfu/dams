using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAMS.Models;
using DAMS.Interface;

namespace DAMS.Core
{
    public class CategoryService : ICategoryService
    {
        public List<Catagorys> GetCategorysByType(int type)
        {
            using (var db=new EFDbContext())
            {
                return db.Catagorys.Where(x => x.Type == type).ToList();
            }
        }
    }
}
