using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using QzBlazor.Config;

namespace QzBlazor
{
    public class Qz
    {
        private readonly IJSRuntime _jsRuntime;

        public Printers Printers { get; }
        public Qz(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
            Printers = new Printers(jsRuntime);
        }

        public async Task<bool> ConnectAsync()
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("qz.websocket.connect");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> IsConnectedAsync()
        {
            try
            {
                return await _jsRuntime.InvokeAsync<bool>("qz.websocket.isActive");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<string> GetVersionAsync()
        {
            try
            {
                return await _jsRuntime.InvokeAsync<string>("qz.api.getVersion");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Print(string printerName, List<string> data)
        {
            await _jsRuntime.InvokeVoidAsync("QzBlazor.print", printerName, data);
        }
    }
}
