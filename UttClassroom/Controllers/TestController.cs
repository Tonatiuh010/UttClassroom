using Classes;
using Engine.BL;
using Engine.BO;
using Microsoft.AspNetCore.Mvc;

namespace UttClassroom.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : CustomController
{
    [HttpGet]
    public Result GetStudents() 
        => RequestResponse(() => StudentsBL.GetStudents());

}
