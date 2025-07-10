using BiogenomTest.Domain.Models;

namespace BiogenomTest.Infrastructure.Entities
{
    public class NutritionReportEntity
    {
        public int Id { get;  set; }
        public DateTime CreationDate { get;  set; } = DateTime.Now;

        /// <summary>
        /// Навигационное свойство к списку нутриентов, представляющих текущее потребление
        /// </summary>
        public List<NutrientEntity> CurrentIntake { get;  set; } = [];

        /// <summary>
        /// Навигационное свойство к списку рекомендованных БАД
        /// </summary>
        public List<SupplementEntity> RecommendedSupplements { get;  set; } = [];

        /// <summary>
        /// Навигационное свойство к списку преимуществ приема БАД
        /// </summary>
        public List<AdvantageEntity> Advantages { get; set; } = [];
    }
}
