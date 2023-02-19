using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NWSInventaire.Server.Data;
using NWSInventaire.Server.Repository;
using NWSInventaire.Shared.Models;

namespace NWSInventaire.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {

        private readonly ILogger<MaterialController> _logger;
        private readonly MaterialRepository Materials;

        public MaterialController(ILogger<MaterialController> logger, MaterialRepository mRepository)
        {
            _logger = logger;
            Materials = mRepository;
        }

        [HttpGet("GetAllMaterial")]
        public List<Material> GetAllMaterial()
        {
            return Materials.GetAllMaterial();
        }

        [HttpGet("GetMaterial/{id}")]
        public Material GetMaterial(int id)
        {
            return Materials.GetMaterial(id);
        }

        [HttpGet("GetMaterialStock/{id}")]
        public int GetMaterialStock(int id)
        {
            return Materials.GetMaterialStock(id);
        }

        [HttpPost("AddMaterial")]
        public IActionResult AddMaterial(Material material)
        {
            return Materials.AddMaterial(material);
        }


        [HttpPost("AddMultipleMaterial")]
        public IActionResult AddMultipleMaterial(MultipleMaterial multipleMaterial)
        {
            return Materials.AddMultipleMaterial(multipleMaterial);
        }

        [HttpDelete("DeleteMaterial/{id}")]
        public IActionResult DeleteMaterial(int id)
        {
            return Materials.DeleteMaterial(id);
        }

        [HttpPut("PutMaterial")]
        public IActionResult PutMaterial(MultipleMaterial multipleMaterial)
        {
            return Materials.PutMaterial(multipleMaterial);
        }


    }
}
