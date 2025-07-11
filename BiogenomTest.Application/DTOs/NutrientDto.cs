namespace BiogenomTest.Application.DTOs;

public record NutrientDto(
    string Name, 
    string Unit, 
    double CurrentValue, 
    double MinNormalValue, 
    double? MaxNormalValue, 
    string Status); 