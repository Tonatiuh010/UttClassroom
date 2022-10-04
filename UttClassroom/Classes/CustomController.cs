using System;
using System.Collections;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Engine.BL;
using Engine.BO;
using Engine.Constants;
using D = Engine.BL.Delegates;
using Engine.Services;
using UttClassroom.Classes;
using System.Text.Json;
using UttClassroom.Classes.Converters;

namespace Classes;

public abstract class CustomController : ControllerBase
{
    protected List<RequestError> ErrorsRequest { get; set; } = new List<RequestError>();
    private ExceptionManager ErrorManager { get; set; }

    public CustomController()
    {
        ErrorManager = new (SetErrorOnRequest);
    }

    protected void SetErrorOnRequest(Exception ex, string msg) 
        => ErrorsRequest.Add(new RequestError() {
            Info = msg,
            Exception = ex
        });

    protected Result RequestResponse(
        D.ActionResult action,
        D.ActionResult? action2 = null,
        D.ActionResult? action3 = null,
        D.ActionResult? action4 = null
    ) => RequestBlock(result => {
        if (result != null)
        {
            result.Data = action();

            if (action2 != null)
                result.Data2 = action2();

            if (action3 != null)
                result.Data3 = action3();

            if (action4 != null)
                result.Data4 = action4();

            result.Message = C.COMPLETE;

        }

        return result ?? throw new Exception("RequestResponse result is Empty");
    });

    protected HttpResponseMessageResult RequestResponseJson(
        D.ActionResult action,
        D.ActionResult? action2 = null,
        D.ActionResult? action3 = null,
        D.ActionResult? action4 = null
    )
    {
        Result result = RequestResponse(action, action2, action3, action4);
        string json = JsonSerializer.Serialize(result, new JsonSerializerOptions() { 
            Converters =
            {
                new JsonResultConverter(),
            }
        } );

        var response = new HttpResponseMessage()
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
        };

        return new HttpResponseMessageResult(response);
  
    }

    protected Result RequestResponse(D.ActionResult_R action) => RequestBlock( result => {
        if (action != null)
        {
            var res = action();
            result = res ?? new Result() { Status = "ERROR", Message = "Not Result Founded!!!" };
        }

        return result;
    });

    private Result RequestBlock(D.CallbackResult action)
    {
        //bl.DomainUrl = DomainUrl;
        Result result = new()
        {
            Status = C.OK
        };

        try
        {
            result = action(result);

            if (ErrorsRequest != null && ErrorsRequest.Count > 0)
            {
                throw new Exception("Errores en request");
            }

        }
        catch (Exception ex)
        {
            ErrorResult(this, result, ex);
        }

        ErrorManager.Dispose();

        return result;
    }

    public static void ErrorResult(CustomController controller, Result result, Exception? ex = null)
    {
        result.Status = C.ERROR;
        result.Data = RequestError.FormatErrors(controller.ErrorsRequest);        

        if (ex != null)
        {
            result.Message = ex.Message;
        }
        else
        {
            result.Message = "Error doing something!";
        }
    }

    public static T? GetItem<T>(List<T> list, string? emptyMsg = null)
    {
        if (list != null && list.Count > 0)
        {
            return list[0];
        }

        return default;
    }

}

// public Uri Uri => new($"{Request.Scheme}://{Request.Host}{Request.PathBase}{Request.Path}{Request.QueryString}");
// public string DomainUrl => $"{Uri.Scheme}://{Uri.Authority}";