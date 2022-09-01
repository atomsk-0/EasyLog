This project is not updated anymore please check [[EasyLogPlus](https://github.com/asoji/EasyLogPlus)] from asoji.

<h1 align="center">
  EasyLog
</h1>
<p align="center">
  Simple and easy to use logging system.
</p>

## How to use?
- Install Easy-Log from nuget or run this command in NuGet Package manager ``` Install-Package Easy-Log -Version 1.0.5 ```
- Add ``` using EasyLog; ```
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
  cfg.LogPath = Environment.CurrentDirectory + @"\Application.log";//Set path where you want log to be saved
  cfg.ShowDate = true;//If this is set to true it will add date to the log
  cfg.Console = true;//If this is set to true it will print the log to Console too
}
```
Then in your application main void add these
```cs
log.cfg = cfg;
SetConfig();
log.InitLogger();//Call this to init logger
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
