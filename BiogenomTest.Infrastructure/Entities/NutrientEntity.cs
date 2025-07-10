namespace BiogenomTest.Infrastructure.Entities
{
    public class NutrientEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        /// <summary>
        /// Текущее значение
        /// </summary>
        public double CurrentValue { get; set; }
        /// <summary>
        /// Минимальное нормальное значение
        /// </summary>
        public double MinNormalValue { get; set; }
        /// <summary>
        /// Максимальное нормальное значение (может быть null)
        /// </summary>
        public double? MaxNormalValue { get; set; }
    }
}
