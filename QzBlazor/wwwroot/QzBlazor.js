
window.QzBlazor = {
    assemblyname: "QzBlazor",
    print: function (printerName, commands) {
        let config = qz.configs.create(printerName);

        qz.print(config, commands);
    }
};