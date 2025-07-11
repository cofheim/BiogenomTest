using BiogenomTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BiogenomTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NutritionReportsController : ControllerBase
{
    private readonly INutritionReportService _nutritionReportService;

    public NutritionReportsController(INutritionReportService nutritionReportService)
    {
        _nutritionReportService = nutritionReportService;
    }

    /// <summary>
    /// получает последний индивидуальный отчет о качестве питания
    /// </summary>
    [HttpGet("latest")]
    public async Task<IActionResult> GetLatestReport()
    {
        var reportDto = await _nutritionReportService.GetLatestReportDtoAsync();

        if (reportDto == null)
        {
            return NotFound("Отчет о питании не найден.");
        }

        return Ok(reportDto);
    }
} 