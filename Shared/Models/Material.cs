namespace NWSInventaire.Shared.Models
{
    public class Material
    {
        public int? MaterialId { get; set; }

        public Guid LinkAllMaterial { get; set; }

        public string MaterialName { get; set; }

        public string? MaterialDescription { get; set; }

        public int? MaterialCategorieId { get; set; }

        public int? studentId { get; set; }

        //public int? studentId { get; set; }

        public DateTime? StartLend { get; set; }

        public DateTime? EndLend { get; set; }

        public DateTime? LastReminder { get; set; }

    }

    
}
