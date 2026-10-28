# Common.Logging.Log4Net.Universal
Common Logging adapter for Log4Net

## Initialization

Use the application's existing root configuration to include all of its configured
providers, such as JSON files and environment variables:

```csharp
Log4NetInitializer.Initialize(configuration);
```

The method reads the `LogConfiguration` section and does not create, reload, or
dispose the supplied configuration. For example:

```json
{
  "LogConfiguration": {
    "factoryAdapter": {
      "type": "Common.Logging.Log4Net.Universal.Log4NetFactoryAdapter, Common.Logging.Log4Net.Universal",
      "arguments": {
        "configType": "EXTERNAL"
      }
    }
  }
}
```
