using DMTest.Domain.Exceptions;
using DMTest.Domain.Interface.Services;
using DMTest.Services.RestServices.Helpers;
using DMTest.Services.RestServices.ViewModels;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;

namespace DMTest.Services.RestServices.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RouletteController : Controller
    {
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly IRouletteService _rouletteService;

        public RouletteController(
            IRouletteService rouletteService,
            IWebHostEnvironment environment,
            ILogger<RouletteController> logger)
        {
            _logger = logger;
            _environment = environment;
            _rouletteService = rouletteService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
                return ResponseHelper.BadRequest(ModelState);

            try
            {
                var rulettes = await _rouletteService.GetAsync();
                return ResponseHelper.Ok(rulettes);
            }
            catch (DMTestNotFoundException ex)
            {
                return ResponseHelper.NotFound(ex);
            }
            catch (DMTestException ex)
            {
                return ResponseHelper.BadRequest(ex);
            }
            catch (DMTestAuthException ex)
            {
                return ResponseHelper.BadRequest(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return ResponseHelper.BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            if (!ModelState.IsValid)
                return ResponseHelper.BadRequest(ModelState);

            try
            {
                var roulette = await _rouletteService.CreateAsync();
                return ResponseHelper.Ok(roulette);
            }
            catch (DMTestNotFoundException ex)
            {
                return ResponseHelper.NotFound(ex);
            }
            catch (DMTestException ex)
            {
                return ResponseHelper.BadRequest(ex);
            }
            catch (DMTestAuthException ex)
            {
                return ResponseHelper.BadRequest(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return ResponseHelper.BadRequest(ex);
            }
        }

        [HttpPatch("open")]
        public async Task<IActionResult> Open([FromBody] RouletteChangeStatusViewModel roulette)
        {
            if (!ModelState.IsValid)
                return ResponseHelper.BadRequest(ModelState);

            try
            {
                await _rouletteService.OpenAsync(roulette.RouletteId);
                return ResponseHelper.Ok(roulette);
            }
            catch (DMTestNotFoundException ex)
            {
                return ResponseHelper.NotFound(ex);
            }
            catch (DMTestException ex)
            {
                return ResponseHelper.BadRequest(ex);
            }
            catch (DMTestAuthException ex)
            {
                return ResponseHelper.BadRequest(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return ResponseHelper.BadRequest(ex);
            }
        }

        [HttpPatch("close")]
        public async Task<IActionResult> Close([FromBody] RouletteChangeStatusViewModel rouletteViewModel)
        {
            if (!ModelState.IsValid)
                return ResponseHelper.BadRequest(ModelState);

            try
            {
                var roulette = await _rouletteService.CloseAsync(rouletteViewModel.RouletteId);
                return ResponseHelper.Ok(roulette);
            }
            catch (DMTestNotFoundException ex)
            {
                return ResponseHelper.NotFound(ex);
            }
            catch (DMTestException ex)
            {
                return ResponseHelper.BadRequest(ex);
            }
            catch (DMTestAuthException ex)
            {
                return ResponseHelper.BadRequest(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return ResponseHelper.BadRequest(ex);
            }
        }
    }
}
