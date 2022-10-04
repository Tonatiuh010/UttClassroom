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
            () => HistorialBL.GetStudentStats(id).Select(x => x.ToJsonObject()),
            () => StudentsBL.GetStudent(id)
        );

}