using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dadata;
using Dadata.Model;

namespace TZ.Service.Interfaces
{
	public interface IDadataService
	{
        Task<Dadata.Model.Address?> GetDadataModel(string address);
    }
}
