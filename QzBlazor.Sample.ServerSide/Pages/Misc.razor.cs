using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using QzBlazor;
using QzBlazor.Models;

namespace QzBlazor.Sample.ServerSide.Pages
{
    public partial class Misc
    {
        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        private Qz _qz;

        private string _version;

        private string PrinterQuery { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _qz = new Qz(JsRuntime);
            }

            if (!await _qz.IsConnectedAsync())
            {
                var result = await _qz.ConnectAsync();
            }
            
            await base.OnAfterRenderAsync(firstRender);
        }

        private async void GetVersion()
        {
            if (await _qz.IsConnectedAsync())
            {
                _version = await _qz.GetVersionAsync();
                StateHasChanged();
            }
        }
    }
}
