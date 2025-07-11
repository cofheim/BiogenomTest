namespace BiogenomTest.Application.DTOS;

public record NutrientDto(
    string Name, 
    string Unit, 
    double CurrentValue, 
    double MinNormalValue, 
    double? MaxNormalValue, 
    string Status); 