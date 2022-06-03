﻿using Earth.Core.Contracts.ApplicationServices.Commands;
using Earth.Core.Contracts.ApplicationServices.Common;
using Earth.Core.Domain.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Zamin.Extensions.Logger.Abstractions;
using Zamin.Extentions.Translations.Abstractions;

namespace Earth.Core.ApplicationServices.Commands;

public class CommandDispatcherDomainExceptionHandlerDecorator : CommandDispatcherDecorator
{
    #region Fields
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<CommandDispatcherDomainExceptionHandlerDecorator> _logger;
    #endregion

    #region Constructors
    public CommandDispatcherDomainExceptionHandlerDecorator(CommandDispatcher commandDispatcher, IServiceProvider serviceProvider, ILogger<CommandDispatcherDomainExceptionHandlerDecorator> logger) : base(commandDispatcher)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    #endregion

    #region Send Commands
    public override async Task<CommandResult> Send<TCommand>(TCommand command)
    {
        try
        {
            var result = _commandDispatcher.Send(command);
            return await result;
        }
        catch (DomainStateException ex)
        {
            _logger.LogError(ZaminEventId.DomainValidationException, ex, "Processing of {CommandType} With value {Command} failed at {StartDateTime} because there are domain exceptions.", command.GetType(), command, DateTime.Now);
            return DomainExceptionHandlingWithoutReturnValue<TCommand>(ex);
        }
        catch (AggregateException ex)
        {
            if (ex.InnerException is DomainStateException domainStateException)
            {
                _logger.LogError(ZaminEventId.DomainValidationException, domainStateException, "Processing of {CommandType} With value {Command} failed at {StartDateTime} because there are domain exceptions.", command.GetType(), command, DateTime.Now);
                return DomainExceptionHandlingWithoutReturnValue<TCommand>(domainStateException);
            }
            throw ex;
        }

    }

    public override async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)
    {
        try
        {
            var result = await _commandDispatcher.Send<TCommand, TData>(command);
            return result;

        }
        catch (DomainStateException ex)
        {
            _logger.LogError(ZaminEventId.DomainValidationException, ex, "Processing of {CommandType} With value {Command} failed at {StartDateTime} because there are domain exceptions.", command.GetType(), command, DateTime.Now);
            return DomainExceptionHandlingWithReturnValue<TCommand, TData>(ex);
        }
        catch (AggregateException ex)
        {
            if (ex.InnerException is DomainStateException domainStateException)
            {
                _logger.LogError(ZaminEventId.DomainValidationException, ex, "Processing of {CommandType} With value {Command} failed at {StartDateTime} because there are domain exceptions.", command.GetType(), command, DateTime.Now);
                return DomainExceptionHandlingWithReturnValue<TCommand, TData>(domainStateException);
            }
            throw ex;
        }
    }
    #endregion

    #region Privaite Methods
    private CommandResult DomainExceptionHandlingWithoutReturnValue<TCommand>(DomainStateException ex)
    {
        var commandResult = new CommandResult
        {
            Status = ApplicationServiceStatus.InvalidDomainState
        };

        commandResult.AddMessage(GetExceptionText(ex));

        return commandResult;
    }

    private CommandResult<TData> DomainExceptionHandlingWithReturnValue<TCommand, TData>(DomainStateException ex)
    {
        var commandResult = new CommandResult<TData>()
        {
            Status = ApplicationServiceStatus.InvalidDomainState
        };

        commandResult.AddMessage(GetExceptionText(ex));

        return commandResult;
    }

    private string GetExceptionText(DomainStateException domainStateException)
    {
        var translator = _serviceProvider.GetService<ITranslator>();
        if (translator == null)
            return domainStateException.ToString();

        var result = (domainStateException?.Parameters.Any() == true) ?
             translator[domainStateException.Message, domainStateException.Parameters] :
               translator[domainStateException?.Message];

        _logger.LogInformation(ZaminEventId.DomainValidationException, "Domain Exception message is {DomainExceptionMessage}", result);

        return result;
    }
    #endregion
}
