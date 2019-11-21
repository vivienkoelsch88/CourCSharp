using ConsoleApp2.RequestApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class FakeAppelsApi : IAppelsApi
    {
        public String getRequest(String url)
        {
            String json = "[{\"id\":\"SEM:1986\",\"name\":\"GRENOBLE, CASERNE DE BONNE\",\"lon\":5.72533,\"lat\":45.18506,\"zone\":\"SEM_GENCASBONNE\",\"lines\":[\"SEM:16\"]}]";
            return json;
        }
    }
}
