using Classes;
using Engine.BL;
using Engine.BO;
using Microsoft.AspNetCore.Mvc;

namespace UttClassroom.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupController : CustomController
{
    [HttpGet]
    public Result GetGroups() 
        => RequestResponse(() => GroupBL.GetGroups());

    [HttpGet("{id:int}")]
    public Result GetGroup(int id) 
        => RequestResponse(() => GroupBL.GetGroup(id));

    [HttpGet("student/{id:int}")]
    public Result GetStudentGroup(int id)
        => RequestResponse(() => GroupBL.GetStudentGroup(id));
}

