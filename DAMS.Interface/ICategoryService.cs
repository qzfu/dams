using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAMS.Models;

namespace DAMS.Interface
{
    public interface ICategoryService
    {
        List<Catagorys> GetCategorysByType(int type);
    }
}
