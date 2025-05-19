using APBD_CW_9_s30522.DTOs;
using APBD_CW_9_s30522.Exceptions;
using APBD_CW_9_s30522.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_CW_9_s30522.Controllers;

[ApiController]
[Route("[controller]")]
public class PrescriptionController(IDbService dbService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePrescriptionAsync(PrescriptionCreateDto prescription)
    {
        try
        {
            var createdPrescriptionId = await dbService.CreatePrescriptionAsync(prescription);
            return StatusCode(201, createdPrescriptionId);
        }
        catch (NotFoundException eNotFound)
        {
            return NotFound(eNotFound.Message);
        }
        catch (DataMissMatchException eDataMissMatch)
        {
            return Conflict(eDataMissMatch.Message);
        }
        catch (LimitExceededException eLimitExceeded)
        {
            return BadRequest(eLimitExceeded.Message);
        }
        
        
    }
}