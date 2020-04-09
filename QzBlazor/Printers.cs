using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using QzBlazor.Models;

namespace QzBlazor
{
    public class Printers
    {
        private IJSRuntime _jsRuntime;
        internal Printers(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<List<string>> GetAllPrinterNamesAsync()
        {
            var printerNames = await _jsRuntime.InvokeAsync<List<string>>("qz.printers.find");

            return printerNames;
        }

        /// <summary>
        /// Finds a printers name based on a query
        /// </summary>
        /// <param name="query">The string to use as query</param>
        /// <returns>The matched printer name</returns>
        /// <exception cref="T:System.ArgumentException">Query must not be null or empty</exception>
        public async Task<string> FindAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentException("Query must not be null or empty", nameof(query));
            }
            var printerName = await _jsRuntime.InvokeAsync<string>("qz.printers.find", query);

            return printerName;
        }

        public async Task<List<Printer>> GetPrinterDetailsAsync()
        {
            var printers = await _jsRuntime.InvokeAsync<List<Printer>>("qz.printers.details");

            return printers;
        }

        public async Task<string> DefaultPrinterNameAsync()
        {
            var printerName = await _jsRuntime.InvokeAsync<string>("qz.printers.getDefault");

            return printerName;
        }
    }
}
