using Microsoft.DotNet.Scaffolding.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NWSInventaire.Server.Controllers;
using NWSInventaire.Server.Data;
using NWSInventaire.Server.Repository;
using NWSInventaire.Shared.Models;
using PingEquipementCavasXpert.Classes;
using System.Diagnostics;

namespace NWSInventaire.Server.HostedService
{
    public class LendHostedService : BackgroundService
    {

        private readonly IServiceProvider _provider;
        public LendHostedService(IServiceProvider serviceProvider)
        {
            _provider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                using (IServiceScope scope = _provider.CreateScope())
                {
                    DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();
                    List<Material> materialList = context.materials.Where(x => x.studentId != null && x.StartLend != null && x.EndLend != null).ToList();
                    List<Student> students = context.students.ToList();

                    MailService mailService = scope.ServiceProvider.GetRequiredService<MailService>();

                    string text1 = "N'oublier pas de rendre votre materiel prochainement : ";


                    if (materialList != null)
                    {
                        foreach (var material in materialList)
                        {

                            if (material.EndLend.Value.Date <= DateTime.UtcNow.Date && material.EndLend.Value.Date >= (DateTime.UtcNow - new TimeSpan(24, 0, 0)).Date)
                            {
                                if (DateTime.UtcNow.Hour + 1 >= material.EndLend.Value.Hour)
                                {
                                    //Debug.WriteLine((material.EndLend - DateTime.UtcNow).Value.Hours);
                                    //Debug.WriteLine("Tu est en retard Student : " + students.FirstOrDefault(x => x.StudentId == material.studentId).StudentFirstName + " Date Start: " + material.StartLend + " Date End: " + material.EndLend + " Date Now " + DateTime.Now.ToString() + " Date End - 48h: " + (material.EndLend + new TimeSpan(1, 0, 0)).ToString());

                                    int Calc = (material.EndLend - DateTime.UtcNow).Value.Hours;

                                    if (Calc <= 0 && material.FinalReminder == false)
                                    {
                                        string LastTime = (material.EndLend - DateTime.UtcNow).Value.Minutes.ToString();
                                        string text2 = "Il ne vous reste plus que " + LastTime + " Minutes pour rendre votre materiel, au dela des pénalité s'appliqueront.";

                                        bool result = mailService.SendGmail("A rendre", text1 + material.MaterialName, text2, students.FirstOrDefault(x => x.StudentId == material.studentId).StudentMail);

                                        if (result)
                                        {
                                            material.LastReminder = DateTime.UtcNow;
                                            material.FinalReminder = true;

                                            context.materials.Update(material);
                                            context.SaveChanges();
                                        }
                                    }

                                }
                            }



                            if (material.EndLend - new TimeSpan(48, 0, 0) <= DateTime.UtcNow)
                            {
                                if (material.LastReminder != null && material.FinalReminder == false)
                                {
                                    if (material.LastReminder + new TimeSpan(24, 0, 0) <= DateTime.UtcNow)
                                    {
                                        string LastTime = (material.EndLend - DateTime.UtcNow).Value.Hours.ToString();
                                        string text2 = "Il ne vous reste plus que : " + LastTime + "h pour rendre votre materiel, au dela des pénalité s'appliqueront";
                                        bool result = mailService.SendGmail("A rendre", text1 + material.MaterialName, text2, students.FirstOrDefault(x => x.StudentId == material.studentId).StudentMail);

                                        if(result)
                                        {
                                            material.LastReminder = DateTime.UtcNow;

                                            context.materials.Update(material);
                                            context.SaveChanges();
                                        }
                                    }
                                }

                                if (material.LastReminder == null)
                                {
                                    material.LastReminder = DateTime.UtcNow;

                                    context.materials.Update(material);
                                    context.SaveChanges();
                                }
                                //Debug.WriteLine("hé ho faut rendre le matos Student : " + students.FirstOrDefault(x => x.StudentId == material.studentId).StudentFirstName + " Date Start: " + material.StartLend + " Date End: " + material.EndLend + " Date Now " + DateTime.Now.ToString() + " Date End - 48h: " + (material.EndLend - new TimeSpan(48, 0, 0)).ToString());
                            }


                            
                        }
                    }


                }


                Debug.WriteLine("HostedService Cycle");
                await Task.Delay(new TimeSpan(0, 0, 10));
            }

        }

    }
}
