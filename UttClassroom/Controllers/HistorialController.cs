using Classes;
using Engine.BL;
using Engine.BO;
using Microsoft.AspNetCore.Mvc;

namespace UttClassroom.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HistorialController : CustomController
{
    [HttpGet("{id:int}")]
    public Result GetStudentStats(int id)
        => RequestResponse(
            () => ItemStats.ToJsonObject( HistorialBL.GetStudentStats(id) ),
            () => StudentsBL.GetStudent(id)
        );

    [HttpGet("groupStats")]
    public Result GetGroupStats() 
        => RequestResponse(
            () => ItemStats.ToJsonObject (HistorialBL.GetGroupStats())
        );
}