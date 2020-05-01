using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using QzBlazor.Models;

namespace QzBlazor.Config
{
    public class Config
    {
        private Config() { }

        public object bounds { get; set; }
        public string colorType { get; set; }
        public int copies { get; set; }
        public int density { get; set; }
        public bool duplex { get; set; }
        public object fallbackDensity { get; set; }
        public string interpolation { get; set; }
        public object jobName { get; set; }
        public bool legacy { get; set; }
        public int margins { get; set; }
        public object orientation { get; set; }
        public object paperThickness { get; set; }
        public object printerTray { get; set; }
        public bool rasterize { get; set; }
        public int rotation { get; set; }
        public bool scaleContent { get; set; }
        public object size { get; set; }
        public string units { get; set; }
        public bool altPrinting { get; set; }
        public object encoding { get; set; }
        public object endOfDoc { get; set; }
        public int perSpool { get; set; }
    }

    public class DirtyOpts
    {
    }

    public class Printer
    {
        public string name { get; set; }
    }

    public class PrinterConfig
    {
        public Config config { get; set; }
        public DirtyOpts _dirtyOpts { get; set; }
        public Printer printer { get; set; }

        public static async Task<PrinterConfig> GetConfigAsync(IJSRuntime jsRuntime, string printerName)
        {
            var config = await jsRuntime.InvokeAsync<PrinterConfig>("qz.configs.create", printerName);

            return config;
        }
    }
}
