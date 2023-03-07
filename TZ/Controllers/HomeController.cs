using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using TZ.Models;
using Dadata;
using Dadata.Model;
using Newtonsoft.Json;
using TZ.Service.Implementations;
using TZ.Service.Interfaces;
using System.Text.Json;
using TZ.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Cors;

namespace TZ.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
        public async Task<IActionResult> IndexAsync([FromServices] IHttpClientFactory httpClientFactory, [FromServices] IMapper mapper)
		{
			var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7029/home/standart?address=мск сухонска 11/-89");
			var httpClient = httpClientFactory.CreateClient();
			var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
			using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true,
			};
			var dadataModel = await System.Text.Json.JsonSerializer.DeserializeAsync<Dadata.Model.Address>(contentStream, options);

			var standartData = mapper.Map<StandartData>(dadataModel);
			return View(standartData);


		}
        [HttpGet]
		[Produces("application/json")]
        public async Task<Dadata.Model.Address?> StandartAsync([FromServices] IDadataService dadataService, string address)
		{
			return await dadataService.GetDadataModel(address);
        }

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}