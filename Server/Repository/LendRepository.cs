using Microsoft.AspNetCore.Mvc;
using NWSInventaire.Server.Data;
using NWSInventaire.Shared.Models;
using PingEquipementCavasXpert.Classes;
using System.Diagnostics;

namespace NWSInventaire.Server.Repository
{
    public class LendRepository : RepositoryBase
    {

        private readonly MailService mailService;

        public LendRepository(DataContext context, MailService _mailService) : base(context) 
        { 
            mailService = _mailService;
        }

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
            return new StatusCodeResult(200);
        }

        public IActionResult SendReminder(int id)
        {

            if(id == null)
                return new StatusCodeResult(404);

            if (id < 0)
                return new StatusCodeResult(404);

            Material material = Context.materials.FirstOrDefault(x => x.MaterialId == id);

            if (material == null)
                return new StatusCodeResult(404);

            Student student = Context.students.FirstOrDefault(x => x.StudentId == material.studentId);

            if (student == null)
                return new StatusCodeResult(404);

            int Calc = (material.EndLend - DateTime.UtcNow).Value.Hours;

            string text1 = "N'oublier pas de rendre votre materiel prochainement : ";
            string text2;

            if (Calc > 0)
            {
                string LastTime = (material.EndLend - DateTime.UtcNow).Value.Hours.ToString();
                text2 = "Il ne vous reste plus que " + LastTime + " Heures pour rendre votre matériel, au dela des pénalité s'appliqueront.";
            }
            else if (Calc < -1)
            {
                text1 = "Veuiller rendre votre matériel au plus vite : ";
                text2 = "Vous avez dépassé le temps impartie pour rendre votre matériel des pénalité s'appliqueront.";
            }
            else
            {
                string LastTime = (material.EndLend - DateTime.UtcNow).Value.Minutes.ToString();
                text2 = "Il ne vous reste plus que " + LastTime + " Minutes pour rendre votre matériel, au dela des pénalité s'appliqueront.";
            }

            bool result = mailService.SendGmail("A rendre", text1 + material.MaterialName, text2, student.StudentMail);

            if (result)
            {
                return new StatusCodeResult(200);
            }
            else
            {
                return new StatusCodeResult(404);
            }

        }
    }
}
