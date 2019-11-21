using ConsoleApp2.RequestApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class FakeAppelsApi2 : IAppelsApi
    {
        public String getRequest(String url)
        {
            return "[{\"id\":\"C38:6020\",\"gtfsId\":\"C38:6020\",\"shortName\":\"6020\",\"longName\":\"CROLLES-MEYLAN-GRENOBLE\",\"color\":\"ff7917\",\"textColor\":\"FFFFFF\",\"mode\":\"BUS\",\"type\":\"C38\"}]";
        }
    }
}
