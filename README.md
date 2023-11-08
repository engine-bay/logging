# EngineBay.Logging

[![NuGet version](https://badge.fury.io/nu/EngineBay.Logging.svg)](https://badge.fury.io/nu/EngineBay.Logging)
[![Maintainability](https://api.codeclimate.com/v1/badges/b546e073e91e11e2acfc/maintainability)](https://codeclimate.com/github/engine-bay/logging/maintainability)
[![Test Coverage](https://api.codeclimate.com/v1/badges/b546e073e91e11e2acfc/test_coverage)](https://codeclimate.com/github/engine-bay/logging/test_coverage)

Logging module for EngineBay published to [EngineBay.Logging](https://www.nuget.org/packages/EngineBay.Logging/) on NuGet.

## About 

The [module registration](EngineBay.Logging/LoggingModule.cs) adds a logging service to the service collection, with a configurable logging level. Some filters are applied, giving "noisy systems" (e.g. `Microsoft`, `Microsoft.AspNetCore.DataProtection`, and `System`) a log level one higher so that the EngineBay's log level can be set to something lower without being drowned out by logs from these libraries.

The module also contains a [configuration class](EngineBay.Logging/LoggingConfiguration.cs) that exposes two static methods which provide appropriate values based on the environment variables `LOGGING_SENSITIVE_DATA_ENABLED` and `LOGGING_LEVEL`. 

## Usage

`ILogger<T> logger` can be dependency injected, where T is the type whose name is used for the logger category name.  This logger can be used to log messages at different logging levels. 

You may wish to build extensions, such as [EngineBay.Authentication's LoggerExtensions](https://github.com/engine-bay/authentication/blob/main/EngineBay.Authentication/Logging/LoggerExtensions.cs), if you have common log messages you wish to reuse. 

### Registration

This module cannot run on its own. You will need to register it in your application to use its functionality. See the [Demo API registration guide](https://github.com/engine-bay/demo-api).

### Environment Variables

See the [Documentation Portal](https://github.com/engine-bay/documentation-portal/blob/main/EngineBay.DocumentationPortal/DocumentationPortal/docs/documentation/configuration/environment-variables.md#logging).

## Dependencies

* [EngineBay.Core](https://github.com/engine-bay/core)