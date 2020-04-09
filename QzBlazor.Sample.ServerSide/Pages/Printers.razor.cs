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
    public partial class Printers
    {
        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        private Qz _qz;

        private List<string> _printerNames;
        private string _printerName;
        private List<Printer> _printerDetails;

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

        private async void FindAllPrinters()
        {
            if (await _qz.IsConnectedAsync())
            {
                _printerNames = await _qz.Printers.GetAllPrinterNamesAsync();
                StateHasChanged();
            }
        }

        private async void FindPrinter()
        {
            if (await _qz.IsConnectedAsync())
            {
                _printerName = await _qz.Printers.FindAsync(PrinterQuery);
                StateHasChanged();
            }
        }

        private async void PrinterDetails()
        {
            if (await _qz.IsConnectedAsync())
            {
                _printerDetails = await _qz.Printers.GetPrinterDetailsAsync();
                StateHasChanged();
            }
        }
    }
}
