using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace QzBlazor
{
    public class Qz
    {
        private readonly IJSRuntime _runtime;
        public Qz(IJSRuntime runtime)
        {
            _runtime = runtime;
        }

        public async Task<bool> Connect()
        {
            try
            {
                await _runtime.InvokeVoidAsync("qz.websocket.connect");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> IsConnected()
        {
            try
            {
                return await _runtime.InvokeAsync<bool>("qz.websocket.isActive");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
