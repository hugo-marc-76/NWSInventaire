using Microsoft.AspNetCore.Mvc;
using NWSInventaire.Server.Data;
using NWSInventaire.Shared.Models;

namespace NWSInventaire.Server.Repository
{
    public class LendRepository : RepositoryBase
    {

        public LendRepository(DataContext context) : base(context) { }

        public IActionResult CreateNewLend(Material material)
        {

            if(material == null)
                return new StatusCodeResult(404);

            if(material.MaterialId == null || material.LinkAllMaterial == Guid.Empty || material.MaterialName == "" || material.MaterialCategorieId == null || material.MaterialCategorieId < 0 || material.studentId == null || material.studentId < 0 || material.StartLend == null || material.EndLend == null)
                return new StatusCodeResult(404);

            Material getMaterial = Context.materials.FirstOrDefault(x => x.MaterialId == material.MaterialId);

            if(getMaterial == null)
                return new StatusCodeResult(404);

            Context.Attach(getMaterial);
            Context.Entry(getMaterial).CurrentValues.SetValues(material);
            Context.SaveChanges();
            return new StatusCodeResult(202);
        }

        public IActionResult DeleteLend(int id)
        {
            if (id < 0)
                return new StatusCodeResult(404);

            Material getMaterial = Context.materials.FirstOrDefault(x => x.MaterialId == id);

            if (getMaterial == null)
                return new StatusCodeResult(404);

            Material material = getMaterial;

            material.studentId = null;
            material.StartLend = null;
            material.EndLend = null;
            material.LastReminder = null;

            Context.Attach(getMaterial);
            Context.Entry(getMaterial).CurrentValues.SetValues(material);
            Context.SaveChanges();
            return new StatusCodeResult(202);
        }

    }
}
