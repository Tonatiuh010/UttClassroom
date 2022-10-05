using Classes;
using Engine.BL;
using Engine.BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UttClassroom.Classes;

namespace UttClassroom.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogController : CustomController
{
    [HttpGet("asset")]
    public Result GetAssets()
        => RequestResponse(() => CatalogsBL.GetAssets());

    [HttpGet("asset/{id:int}")]
    public Result GetAsset(int id)
        => RequestResponse(() => CatalogsBL.GetAsset(id));

    [HttpGet("address")]
    public Result GetAddresses()
        => RequestResponse(() => CatalogsBL.GetAddresses());

    [HttpGet("address/{id:int}")]
    public Result GetAddress(int id)
        => RequestResponse(() => CatalogsBL.GetAddress(id));

    [HttpGet("contact")]
    public Result GetContacts()
        => RequestResponse(() => CatalogsBL.GetContacts());

    [HttpGet("contact/{id:int}")]
    public Result GetContact(int id)
        => RequestResponse(() => CatalogsBL.GetContact(id));

    [HttpGet("contact/family")]
    public Result GetContactFamilies()
        => RequestResponse(() => CatalogsBL.GetContactFamilies());

    [HttpGet("contact/family/{id:int}")]
    public Result GetContactFamily(int id)
        => RequestResponse(() => CatalogsBL.GetContactFamily(id));

    [HttpGet("location")]
    public Result GetLocations() 
        => RequestResponse(() => CatalogsBL.GetLocations());

    [HttpGet("location/{id:int}")]
    public Result GetLocation(int id)
        => RequestResponse(() => CatalogsBL.GetLocation(id));

    [HttpGet("labor")]
    public Result GetLabors()
        => RequestResponse(() => CatalogsBL.GetLabors());

    [HttpGet("labor/{id:int}")]
    public Result GetLabor(int id)
        => RequestResponse(() => CatalogsBL.GetLabor(id));

    [HttpGet("major")]
    public Result GetMajors()
        => RequestResponse(() => CatalogsBL.GetMajors());

    [HttpGet("major/{id:int}")]
    public Result GetMajor(int id)
        => RequestResponse(() => CatalogsBL.GetMajor(id));

    [HttpGet("scholarly")]
    public Result Getscholarls()
        => RequestResponse(() => CatalogsBL.GetScholars());

    [HttpGet("scholarly/{id:int}")]
    public Result GetScholarly(int id)
        => RequestResponse(() => CatalogsBL.GetScholarly(id));

    [HttpGet("full")]
    public Result GetFullAsset1()
        => RequestResponse(() => CatalogsBL.GetFullAsset());

}