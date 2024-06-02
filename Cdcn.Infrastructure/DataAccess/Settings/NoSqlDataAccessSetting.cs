using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Infrastructure.DataAccess.Settings
{
    public class NoSqlDataAccessSetting
    {
        public const string DefaultSectionName = "NoSql";
        public string? ConnectionString { get; set; }
       
    }
}
