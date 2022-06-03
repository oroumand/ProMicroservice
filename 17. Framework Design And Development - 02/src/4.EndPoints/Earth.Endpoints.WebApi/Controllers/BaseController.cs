﻿using Earth.Core.Contracts.ApplicationServices.Commands;
using Earth.Core.Contracts.ApplicationServices.Common;
using Earth.Core.Contracts.ApplicationServices.Events;
using Earth.Core.Contracts.ApplicationServices.Queries;
using Earth.Endpoints.WebApi.Extentions;
using Earth.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Zamin.Extentions.Serializers.Abstractions;

namespace Earth.Endpoints.WebApi.Controllers;

public class BaseController : Controller
{
    protected ICommandDispatcher CommandDispatcher => HttpContext.CommandDispatcher();
    protected IQueryDispatcher QueryDispatcher => HttpContext.QueryDispatcher();
    protected IEventDispatcher EventDispatcher => HttpContext.EventDispatcher();
    protected ZaminServices ZaminApplicationContext => HttpContext.ZaminApplicationContext();

    public IActionResult Excel<T>(List<T> list)
    {
        var serializer = (IExcelSerializer)HttpContext.RequestServices.GetRequiredService(typeof(IExcelSerializer));
        var bytes = serializer.ListToExcelByteArray(list);
        return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
    }
    public IActionResult Excel<T>(List<T> list, string fileName)
    {
        var serializer = (IExcelSerializer)HttpContext.RequestServices.GetRequiredService(typeof(IExcelSerializer));
        var bytes = serializer.ListToExcelByteArray(list);
        return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{fileName}.xlsx");
    }


    protected async Task<IActionResult> Create<TCommand, TCommandResult>(TCommand command) where TCommand : class, ICommand<TCommandResult>
    {
        var result = await CommandDispatcher.Send<TCommand, TCommandResult>(command);
        if (result.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode((int)HttpStatusCode.Created, result.Data);
        }
        return BadRequest(result.Messages);
    }

    protected async Task<IActionResult> Create<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        var result = await CommandDispatcher.Send(command);
        if (result.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode((int)HttpStatusCode.Created);
        }
        return BadRequest(result.Messages);
    }

    protected async Task<IActionResult> Edit<TCommand, TCommandResult>(TCommand command) where TCommand : class, ICommand<TCommandResult>
    {
        var result = await CommandDispatcher.Send<TCommand, TCommandResult>(command);
        if (result.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode((int)HttpStatusCode.OK, result.Data);
        }
        else if (result.Status == ApplicationServiceStatus.NotFound)
        {
            return StatusCode((int)HttpStatusCode.NotFound, command);
        }
        return BadRequest(result.Messages);
    }

    protected async Task<IActionResult> Edit<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        var result = await CommandDispatcher.Send(command);
        if (result.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode((int)HttpStatusCode.OK);
        }
        else if (result.Status == ApplicationServiceStatus.NotFound)
        {
            return StatusCode((int)HttpStatusCode.NotFound, command);
        }
        return BadRequest(result.Messages);
    }


    protected async Task<IActionResult> Delete<TCommand, TCommandResult>(TCommand command) where TCommand : class, ICommand<TCommandResult>
    {
        var result = await CommandDispatcher.Send<TCommand, TCommandResult>(command);
        if (result.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode((int)HttpStatusCode.NoContent, result.Data);
        }
        else if (result.Status == ApplicationServiceStatus.NotFound)
        {
            return StatusCode((int)HttpStatusCode.NotFound, command);
        }
        return BadRequest(result.Messages);
    }

    protected async Task<IActionResult> Delete<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        var result = await CommandDispatcher.Send(command);
        if (result.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode((int)HttpStatusCode.NoContent);
        }
        else if (result.Status == ApplicationServiceStatus.NotFound)
        {
            return StatusCode((int)HttpStatusCode.NotFound, command);
        }
        return BadRequest(result.Messages);
    }

    protected async Task<IActionResult> Query<TQuery, TQueryResult>(TQuery query) where TQuery : class, IQuery<TQueryResult>
    {
        var result = await QueryDispatcher.Execute<TQuery, TQueryResult>(query);
        if (result.Status == ApplicationServiceStatus.NotFound || result.Data == null)
        {
            return StatusCode((int)HttpStatusCode.NoContent);
        }
        else if (result.Status == ApplicationServiceStatus.Ok)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Messages);
    }
}
