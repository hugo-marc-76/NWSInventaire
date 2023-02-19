using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NWSInventaire.Server.Repository;
using NWSInventaire.Shared.Models;

namespace NWSInventaire.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialCategorieController : ControllerBase
    {

        private readonly ILogger<MaterialCategorieController> _logger;
        private readonly MaterialCategorieRepository MaterialCategories;

        public MaterialCategorieController(ILogger<MaterialCategorieController> logger, MaterialCategorieRepository mRepository)
        {
            _logger = logger;
            MaterialCategories = mRepository;
        }

        [HttpGet("GetAllMaterialCategorie")]
        public List<MaterialCategorie> GetAllMaterialCategorie()
        {
            return MaterialCategories.GetAllMaterialCategorie();
        }

        [HttpGet("GetMaterialCategorie/{id}")]
        public MaterialCategorie GetMaterialCategorie(int id)
        {
            return MaterialCategories.GetMaterialCategorie(id);
        }

        [HttpPost("AddMaterialCategorie")]
        public IActionResult AddMaterialCategorie(MaterialCategorie MaterialCategorie)
        {
            return MaterialCategories.AddMaterialCategorie(MaterialCategorie);
        }


        [HttpDelete("DeleteMaterialCategorie/{id}")]
        public IActionResult DeleteMaterialCategorie(int id)
        {
            return MaterialCategories.DeleteMaterialCategorie(id);
        }

        [HttpPut("PutMaterialCategorie")]
        public IActionResult PutMaterialCategorie(MaterialCategorie MaterialCategorie)
        {
            return MaterialCategories.PutMaterialCategorie(MaterialCategorie);
        }


    }
}
