using System.Collections.Generic;

namespace BiogenomTest.Infrastructure.Entities
{
    public class SupplementEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        /// <summary>
        /// Навигационное свойство к списку нутриентов, входящих в состав БАД
        /// </summary>
        public List<SupplementNutrientEntity> Nutrients { get; set; } = [];
    }
}
