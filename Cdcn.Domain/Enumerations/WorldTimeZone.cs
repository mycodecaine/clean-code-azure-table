using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Domain.Enumerations
{
    public enum WorldTimeZone
    {
        UTCMinus12 = -12,    // UTC-12:00
        UTCMinus11 = -11,    // UTC-11:00
        HST = -10,           // UTC-10:00 (Hawaii Standard Time)
        AKST = -9,           // UTC-09:00 (Alaska Standard Time)
        PST = -8,            // UTC-08:00 (Pacific Standard Time)
        MST = -7,            // UTC-07:00 (Mountain Standard Time)
        CST = -6,            // UTC-06:00 (Central Standard Time)
        EST = -5,            // UTC-05:00 (Eastern Standard Time)
        AST = -4,            // UTC-04:00 (Atlantic Standard Time)
        BRT = -3,            // UTC-03:00 (Brasilia Time)
        GSTMinus2 = -2,      // UTC-02:00 (South Georgia/Sandwich Islands Time)
        AZOT = -1,           // UTC-01:00 (Azores Standard Time)
        GMT = 0,             // UTC±00:00 (Greenwich Mean Time)
        CET = 1,             // UTC+01:00 (Central European Time)
        EET = 2,             // UTC+02:00 (Eastern European Time)
        MSK = 3,             // UTC+03:00 (Moscow Standard Time)
        GSTPlus4 = 4,        // UTC+04:00 (Gulf Standard Time)
        PKT = 5,             // UTC+05:00 (Pakistan Standard Time)
        BST = 6,             // UTC+06:00 (Bangladesh Standard Time)
        ICT = 7,             // UTC+07:00 (Indochina Time)
        CSTPlus8 = 8,        // UTC+08:00 (China Standard Time)
        JST = 9,             // UTC+09:00 (Japan Standard Time)
        AEST = 10,           // UTC+10:00 (Australian Eastern Standard Time)
        SBT = 11,            // UTC+11:00 (Solomon Islands Time)
        NZST = 12,           // UTC+12:00 (New Zealand Standard Time)
        TOT = 13,            // UTC+13:00 (Tonga Time)
        LINT = 14            // UTC+14:00 (Line Islands Time)
    }
}
