using AnyaSpa.Dal;
using Microsoft.Extensions.Configuration;

namespace AnyaSpa.ClientTest
{
    public class ConfigConnection : IConfigConnection
    {
        private readonly IConfigurationRoot _root;

        public ConfigConnection(IConfigurationRoot root)
        {
            _root = root;
        }


        public string ConnectionString => _root["ConnectionStrings:AnyaSpa"];
    }
}
