using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using QzBlazor;
using QzBlazor.Config;

namespace QzBlazor.Sample.ServerSide.Pages
{
    public partial class Configs
    {
        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        private string printerName { get; set; }

        private async Task GetConfig()
        {
            var config = await PrinterConfig.GetConfigAsync(JsRuntime, printerName);
        }
    }
}
