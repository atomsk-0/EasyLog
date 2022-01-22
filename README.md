<h1 align="center">
  EasyLog
</h1>
<p align="center">
  Simple and easy to use.
</p>
## Setupping
- Install from nuget with name EasyLog or install with nuget package manager command ``` ? ```
- After install add ```cs using EasyLog; ```
- Then add
```cs
Logger log = new Logger();
Config cfg = new Config();
```

## Sending logs
- Debug Log
```cs
log.Debug("Hello from log, this is debug");
```

- Info Log
```cs
log.Info("Hello from log, this is info");
```

- Warning Log
```cs
log.Warning("Hello from log, this is warning");
```

- Error Log
```cs
log.Error("Hello from log, this is error");
```
