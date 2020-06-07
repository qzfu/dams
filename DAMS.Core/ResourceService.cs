using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAMS.Interface;
using DAMS.Models;

namespace DAMS.Core
{
    public class ResourceService : IResourceService
    {
        public List<Resources> GetResources()
        {
            using (var db = new EFDbContext())
            {
                return db.Resources.ToList();
            }
        }
    }
}
