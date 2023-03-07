using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dadata;
using Dadata.Model;
using TZ1.Service.Interfaces;

namespace TZ1.Service.Implementations
{
	public class DadataService : IDadataService
	{
        public async Task<Dadata.Model.Address?> GetDadataModel(string address)
        {
            var token = "d304ec0912e1cdfd978b0ff7faa9a0cd6df44ee7";
            var secret = "c71c27426a3d3d5514b7fe20c0a84b360d93c99d";
            var api = new CleanClientAsync(token, secret);
            try
            {
                return await api.Clean<Address>(address);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
