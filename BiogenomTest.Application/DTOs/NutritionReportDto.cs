namespace BiogenomTest.Application.DTOS;

public record NutritionReportDto
{
    public DateTime CreationDate { get; init; }

    public List<NutrientDto> CurrentIntake { get; init; } = [];

    public List<NutrientDto> NewIntake { get; init; } = [];

    public List<SupplementDto> RecommendedSupplements { get; init; } = [];

    public List<AdvantageDto> Advantages { get; init; } = [];
} 