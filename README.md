## ToolWatch Logger

This simple lightweight logging library allows you to log messages for your .net projects. Currently, there is only one logger available - `ConsoleLogger`. Yet, the power of this library lies in its extensibility. One can easily extend the library to add more kinds of logger such as file logger, database logger and such. The library also allows you to pass a formatter to format your message the way you want it. Extensions methods are provided to make logging less verbose (pun intended).

### Using the library

#### Getting Started
Right now the library is provided as a project and not as a nuget package. Start by adding the project directly.

Create an instance of `ConsoleLogger` and call `Log()` method passing a message and the log type.
```cs
var logger = new ConsoleLogger();
logger.Log("log this message", LogType.Debug);
```

By default `ConsoleLogger` logs any messages despite the log type as the default is set to `None`.
You can customize this by passing a different log type. Also, it uses a pass through formatter which doesn't format the message at all.

A message is only logged if the set level is higher or equal to the intented log type. So, for an example, if LogLevel set for console is `INFO`, any level higher or equals to Info is logged - in this case `DEBUG`, `WARNING`, `CRITCIAL` etc. However, `VERBOSE`, being lower in the order than `INFO` is ignored.

### TODO
* Create a Nuget package
* Add more logger types
* Add more formatters
* Allow to pass exceptions for better stack tracing

