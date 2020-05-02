
# qz-blazor
Blazor wrapper around the QZ javascript library

## Supported Functions
Right know, only some features are implemented. If you need a specific functionality implemented just create a new issue and I will gladly add it to this project.

## Setup
### 1. Adding QzBlazor.js

Add the following to your `_Host.cshtml`.

```cshtml
<script src="_content/QzBlazor/QzBlazor.js"></script>
```

### 2. Adding qz-tray.js

Download QzTray. Inside the demo folder it should contain 3 files: qz-tray.js, rsvp-x.x.x.min.js and sha-256.min.js. Add these to your project and reference them, also in `_Host.csthml` like is done in [this](https://qz.io/wiki/getting-started#the-code) page.

## Usage
Please also refer to the sample project for usage.

To connect to the QZ-tray application running on your computer, create a new QZ object and call connect on it.
``` csharp
...
var qz = new Qz(JsRuntime);
...
```
The only parameter needed is an IJSRuntime. When running a normal Blazor application, the IJSRuntime can be achieved like this, inside a blazor component.
``` csharp
[Inject]
private IJSRuntime JsRuntime { get; set; }
```

For reference to getting the JsRuntime, see [this](https://docs.microsoft.com/en-us/aspnet/core/blazor/call-javascript-from-dotnet?view=aspnetcore-3.1)
