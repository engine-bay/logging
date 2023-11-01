# EngineBay.Logging

[![NuGet version](https://badge.fury.io/nu/EngineBay.Logging.svg)](https://badge.fury.io/nu/EngineBay.Logging)
[![Maintainability](https://api.codeclimate.com/v1/badges/b546e073e91e11e2acfc/maintainability)](https://codeclimate.com/github/engine-bay/logging/maintainability)
[![Test Coverage](https://api.codeclimate.com/v1/badges/b546e073e91e11e2acfc/test_coverage)](https://codeclimate.com/github/engine-bay/logging/test_coverage)

Logging module for EngineBay published to [EngineBay.Logging](https://www.nuget.org/packages/EngineBay.Logging/) on NuGet.

## About 

The [module registration](EngineBay.Logging/LoggingModule.cs) adds a logging service to the service collection, with a configurable logging level. Some filters are applied, giving "noisy systems" (e.g. `Microsoft`, `Microsoft.AspNetCore.DataProtection`, and `System`) a log level one higher so that the EngineBay's log level can be set to something lower without being drowned out by logs from these libraries.

The module also contains a [configuration class](EngineBay.Logging/LoggingConfiguration.cs) that exposes two static methods which provide appropriate values based on the environment variables `LOGGING_SENSITIVE_DATA_ENABLED` and `LOGGING_LEVEL`. 