using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_SEM3_UWP.model
{
    class checkStatus
    {
        public static bool status = false;
        private static bool getStatus()
        {
            return status;
        }
        private static void setStatus(bool status)
        {
            status = status;
        }

    }
}
