using Microsoft.AspNetCore.Mvc;
using NWSInventaire.Server.Data;
using NWSInventaire.Shared.Models;

namespace NWSInventaire.Server.Repository
{
    public class MaterialCategorieRepository : RepositoryBase
    {

        public MaterialCategorieRepository(DataContext context) : base(context) { }

        public MaterialCategorie GetMaterialCategorie(int id)
        {

            try
            {
                if (id < 0)
                    return null; 

                MaterialCategorie getMaterialCategorie = Context.materialCategories.FirstOrDefault(x => x.MaterialCategorieId == id);

                if (getMaterialCategorie == null)
                    return null;

                return getMaterialCategorie;
            }
            catch { return null; }

        }

        public List<MaterialCategorie> GetAllMaterialCategorie()
        {

            try
            {
                List<MaterialCategorie> getMaterialCategorie = Context.materialCategories.ToList();

                if (getMaterialCategorie == null)
                    return null;

                return getMaterialCategorie;
            }
            catch { return null; }

        }

        public IActionResult AddMaterialCategorie(MaterialCategorie MaterialCategorie)
        {
            try
            {
                if (MaterialCategorie == null)
                    return new StatusCodeResult(404);

                if (MaterialCategorie.Name == "" )
                    return new StatusCodeResult(404);

                Context.materialCategories.Add(MaterialCategorie);
                Context.SaveChanges();
                return new StatusCodeResult(200);
            }
            catch { return new StatusCodeResult(404); }
        }

        public IActionResult DeleteMaterialCategorie(int id)
        {
            try
            {
                MaterialCategorie MaterialCategorie = Context.materialCategories.FirstOrDefault(x => x.MaterialCategorieId == id);

                if (MaterialCategorie == null)
                    return new StatusCodeResult(404);

                Context.materialCategories.Remove(MaterialCategorie);
                Context.SaveChanges();
                return new StatusCodeResult(200);
            }
            catch { return new StatusCodeResult(404); }
        }

        public IActionResult PutMaterialCategorie(MaterialCategorie MaterialCategorie)
        {
            try
            {
                MaterialCategorie getMaterialCategorie = Context.materialCategories.FirstOrDefault(x => x.MaterialCategorieId == MaterialCategorie.MaterialCategorieId);

                if (MaterialCategorie == null)
                    return new StatusCodeResult(404);

                if (MaterialCategorie.Name == "")
                    return new StatusCodeResult(404);

                Context.Attach(getMaterialCategorie);
                Context.Entry(getMaterialCategorie).CurrentValues.SetValues(MaterialCategorie);
                Context.SaveChanges();
                return new StatusCodeResult(200);
            }
            catch { return new StatusCodeResult(404); }
        }

        
    }
}
