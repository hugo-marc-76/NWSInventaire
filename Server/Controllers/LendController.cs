using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NWSInventaire.Server.Repository;
using NWSInventaire.Shared.Models;
using System.Drawing.Drawing2D;

namespace NWSInventaire.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LendController : ControllerBase
    {

        private readonly ILogger<LendController> _logger;
        private readonly LendRepository Lend;

        public LendController(ILogger<LendController> logger, LendRepository mRepository)
        {
            _logger = logger;
            Lend = mRepository;
        }

        [HttpPost("AddLend")]
        public IActionResult AddLend(Material material)
        {
            return Lend.CreateNewLend(material);
        }

        [HttpDelete("DeleteLend")]
        public IActionResult DeleteLend(int id)
        {
            return Lend.DeleteLend(id);
        }

    }
}
