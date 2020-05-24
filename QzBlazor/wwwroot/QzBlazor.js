
window.QzBlazor = {
    assemblyname: "QzBlazor",
    print: function (printerName, commands) {
        let config = qz.configs.create(printerName);

        qz.print(config, commands);
    }
};

qz.security.setCertificatePromise(function (resolve, reject) {
    //Call .net method from here to sign
    DotNet.invokeMethodAsync('QzBlazor', 'Certificate').then(data => resolve(data));
});

qz.security.setSignatureAlgorithm("SHA1"); // Since 2.1
qz.security.setSignaturePromise(function (toSign) {
    //Call .net method from here to sign
    return function (resolve, reject) {
        DotNet.invokeMethodAsync('QzBlazor', 'Signature', toSign).then(data => resolve(data));
            //.then(data => data.ok ? resolve(data.text()) : reject(data.text()));
    };
});