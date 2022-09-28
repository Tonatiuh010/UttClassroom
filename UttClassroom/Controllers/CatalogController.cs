using Classes;
using Engine.BL;
using Engine.BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

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


    [HttpGet("full")]
    public Result GetFullAsset()
        => RequestResponse(() => {
            var assets = CatalogsBL.GetFullAsset();
            //var serJ = JsonSerializer.Serialize();
            //var obj2 = JsonSerializer.Deserialize<object>(assets.ToString());
            var obj = assets.ToObject<object>();
            return obj;
        });
}