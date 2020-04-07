using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using QzBlazor;

namespace QzBlazor.Sample.ServerSide.Pages
{
    public partial class Index
    {
        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        private Qz _qz;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _qz = new Qz(JsRuntime);
            }

            if (!await _qz.IsConnected())
            {
                var result = await _qz.Connect();
            }

            var isConnected = await _qz.IsConnected();

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
