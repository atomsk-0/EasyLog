<h1 align="center">
  EasyLog
</h1>
<p align="center">
  Simple and easy to use.
</p>
## How to use?
- Install from nuget or run command `?`
- Add ```cs
using EasyLog;
```
to top
Then add
```cs
Logger log = new Logger();
Config cfg = new Config();
```
If you want customize settings add
```cs
void SetConfig()
{
  cfg.LogPath = "NewLog.log";//Set path where you want log to be saved
  cfg.Date = false;//If this is set to true it will add date to the log
  cfg.Console = false;//If this is set to true it will print the log to Console too
}
```
Then in your application main void add these
```
log.cfg = cfg;
SetConfig();//Run this function only if you want set custom settings
```

## Sending logs
- Debug Log
```cs
log.Debug("Hello from log, this is debug");
```

-Info Log
```cs
log.Info("Hello from log, this is info");
```

-Warning Log
```cs
log.Warning("Hello from log, this is warning");
```

-Error Log
```cs
log.Error("Hello from log, this is error");
```
