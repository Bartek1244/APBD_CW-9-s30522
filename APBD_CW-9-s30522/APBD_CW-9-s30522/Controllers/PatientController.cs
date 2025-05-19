using APBD_CW_9_s30522.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_CW_9_s30522.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController(IDbService dbService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPatientsWithDetailsAsync()
    {
        return Ok(await dbService.GetPatientsWithDetailsAsync());
    }
}