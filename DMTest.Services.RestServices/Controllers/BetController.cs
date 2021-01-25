using AutoMapper;

using DMTest.Domain.Entities;
using DMTest.Domain.Exceptions;
using DMTest.Domain.Interface.Services;
using DMTest.Domain.Security.Authentication;
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
    public class BetController : Controller
    {
        private readonly ILogger _logger;
        private readonly IBetServices _betService;
        private readonly IMapper _mapper;
        private readonly DMTestIdentity _identity;


        public BetController(
            IBetServices betService,
            IMapper mapper,
            DMTestIdentity identity,
            ILogger<UserController> logger)
        {
            _logger = logger;
            _betService = betService;
            _mapper = mapper;
            _identity = identity;
        }


        [HttpPost("number")]
        public async Task<IActionResult> CreateByNumber([FromBody] BetNumberCreateViewModel betViewModel)
        {
            if (!ModelState.IsValid)
                return ResponseHelper.BadRequest(ModelState);

            try
            {
                var bet = _mapper.Map<Bet>(betViewModel);
                bet.UserId = _identity.UserId;

                bet = await _betService.CreateAsync(bet, betViewModel.RouletteId);
                return ResponseHelper.Ok(bet);
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

        [HttpPost("color")]
        public async Task<IActionResult> CreateByColor([FromBody] BetColorCreateViewModel betViewModel)
        {
            if (!ModelState.IsValid)
                return ResponseHelper.BadRequest(ModelState);

            try
            {
                var bet = _mapper.Map<Bet>(betViewModel);
                bet.UserId = _identity.UserId;

                bet = await _betService.CreateAsync(bet, betViewModel.RouletteId);
                return ResponseHelper.Ok(bet);
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
