using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NWSInventaire.Server.Data;
using NWSInventaire.Shared.Models;

namespace NWSInventaire.Server.Repository
{
    public class MaterialRepository : RepositoryBase
    {
        public MaterialRepository(DataContext context) : base(context) { }

        public Material GetMaterial(int id)
        {

            try
            {
                if (id < 0)
                    return null;
                
                Material getMaterial = Context.materials.FirstOrDefault(x => x.MaterialId == id);

                if (getMaterial == null)
                    return null;

                return getMaterial;
            }
            catch{ return null; }

        }

        public List<Material> GetAllMaterial()
        {

            try
            {
                List<Material> getMaterial = Context.materials.ToList();

                if(getMaterial == null)
                    return null;

                return getMaterial;
            }
            catch{ return null; }

        }

        public int GetMaterialStock(int id)
        {
            try
            {
                Material getMaterial = Context.materials.FirstOrDefault(a => a.MaterialId == id);

                int getMaterialStock = Context.materials.Where(a => a.LinkAllMaterial == getMaterial.LinkAllMaterial).Count();

                if (getMaterialStock < 1)
                    return -1;

                return getMaterialStock;
            }
            catch { return -1; }
        }

        public IActionResult AddMaterial(Material material)
        {
            try
            {
                if (material == null)
                    return new StatusCodeResult(404);

                if (material.MaterialName == "")
                    return new StatusCodeResult(404);

                material.LinkAllMaterial = Guid.NewGuid();
                Context.materials.Add(material);
                Context.SaveChanges();
                return new StatusCodeResult(200);
            } 
            catch { return new StatusCodeResult(404); }
        }

        public IActionResult AddMultipleMaterial(MultipleMaterial multipleMaterial)
        {
            try
            {
                if (multipleMaterial == null)
                    return new StatusCodeResult(404);

                if (multipleMaterial.material == null)
                    return new StatusCodeResult(404);

                if (multipleMaterial.StockMaterial < 1)
                    return new StatusCodeResult(404);

                multipleMaterial.material.LinkAllMaterial = Guid.NewGuid();
                for (int i = 0; multipleMaterial.StockMaterial > i; i++)
                {
                    multipleMaterial.material.MaterialId = null;
                    Context.materials.Add(multipleMaterial.material);
                    Context.SaveChanges();
                }
                return new StatusCodeResult(200);
            }
            catch { return new StatusCodeResult(404); }
        }

        public IActionResult DeleteMaterial(int id)
        {
            try
            {
                Material material = Context.materials.FirstOrDefault(x => x.MaterialId == id);

                if (material == null)
                    return new StatusCodeResult(404);

                if (material.studentId != null)
                    return new StatusCodeResult(404);


                Context.materials.Remove(material);
                Context.SaveChanges();
                return new StatusCodeResult(200);
            }
            catch { return new StatusCodeResult(404); }
        }

        public IActionResult PutMaterial(MultipleMaterial multipleMaterial)
        {
            try
            {
                List<Material> getMaterialList = Context.materials.Where(a => a.LinkAllMaterial == multipleMaterial.material.LinkAllMaterial).ToList();

                if (getMaterialList == null)
                    return new StatusCodeResult(404);

                if (getMaterialList.Count < 1)
                    return new StatusCodeResult(404);

                if (multipleMaterial.StockMaterial < 1)
                    return new StatusCodeResult(404);

                if(multipleMaterial.StockMaterial > getMaterialList.Count)
                {
                    int diff = multipleMaterial.StockMaterial - getMaterialList.Count;
                    for (int i = 0; diff > i; i++)
                    {
                        multipleMaterial.material.MaterialId = null;
                        Context.materials.Add(multipleMaterial.material);
                        Context.SaveChanges();
                    }
                }
                
                if(multipleMaterial.StockMaterial < getMaterialList.Count)
                {
                    int diff = getMaterialList.Count - multipleMaterial.StockMaterial;
                    List<Material> getMaterialListStudentIfNotDifined = getMaterialList.Where(a => a.studentId == null).ToList();

                    foreach(Material material in getMaterialListStudentIfNotDifined)
                    {
                        
                        Context.materials.Remove(material);
                        Context.SaveChanges();

                        getMaterialList.Remove(material);

                        if (Context.materials.Where(a => a.LinkAllMaterial == multipleMaterial.material.LinkAllMaterial).Count() == multipleMaterial.StockMaterial)
                        {
                            break;
                        }

                    }


                }

                foreach(var material in getMaterialList)
                {

                    multipleMaterial.material.MaterialId = material.MaterialId;
                    multipleMaterial.material.StartLend = material.StartLend;
                    multipleMaterial.material.EndLend = material.EndLend;
                    multipleMaterial.material.studentId = material.studentId;
                    multipleMaterial.material.LastReminder = material.LastReminder;

                    Context.Attach(material);
                    Context.Entry(material).CurrentValues.SetValues(multipleMaterial.material);
                    Context.SaveChanges();
                }
                return new StatusCodeResult(200);

            }
            catch { return new StatusCodeResult(404); }
        }

       // <--- END CLASS --->

    }
}
