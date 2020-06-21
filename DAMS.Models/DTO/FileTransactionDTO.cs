using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMS.Models.DTO
{
    public class FileTransactionDTO
    {
        public string FromPath { get; set; }
        public string ToPath { get; set; }
        public Resources Resource { get; set; }
    }
}
