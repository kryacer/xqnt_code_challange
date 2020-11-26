using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XQNT.Finance.Contracts;

namespace XQNT.Finance.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepositController : ControllerBase
    {
       
        private readonly ILogger<DepositController> _logger;
        private readonly IDepositCalculator _depositCalculator;

        public DepositController(ILogger<DepositController> logger, IDepositCalculator depositCalculator)
        {
            _logger = logger;
            _depositCalculator = depositCalculator;
        }

    }
}
