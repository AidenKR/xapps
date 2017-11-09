using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xapps
{
    public interface IBackgroundService
    {
        void startBackgroundService();
        void stopBackgroundService();
    }
}
