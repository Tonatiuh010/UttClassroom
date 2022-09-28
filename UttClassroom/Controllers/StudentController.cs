using Classes;
using Engine.BL;
using Engine.BO;
using Microsoft.AspNetCore.Mvc;

namespace UttClassroom.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : CustomController
{
    [HttpGet]
    public Result GetStudents()
        => RequestResponse(() => StudentsBL.GetStudents());

    [HttpGet("{id:int}")]
    public Result GetStudent(int id)
        => RequestResponse(() => StudentsBL.GetStudent(id));

    [HttpGet("group/{id:int}")]
    public Result GetStudentGroups(int id)
        => RequestResponse(() => StudentsBL.GetGroupStudents(id));
}