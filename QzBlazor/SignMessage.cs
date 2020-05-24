using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QzBlazor
{
    public static class SignMessage
    {
        public static string Cert;
        public static string PrivateKeyPath;
        public static string Password;

        [JSInvokable]
        public static async Task<string> Certificate()
        {
            if (string.IsNullOrWhiteSpace(Cert))
            {
                throw new Exception("Certificate is empty");
            }
            return Cert;
        }

        [JSInvokable]
        public static async Task<string> Signature(string toSign)
        {
            if (string.IsNullOrWhiteSpace(PrivateKeyPath))
            {
                throw new Exception("Private Key path is empty");
            }


            var cert = new X509Certificate2(PrivateKeyPath, Password, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
            RSA csp = cert.GetRSAPrivateKey();

            var data = new ASCIIEncoding().GetBytes(toSign);
            var hash = new SHA1Managed().ComputeHash(data);

            var signature = Convert.ToBase64String(csp.SignHash(hash, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1));

            return signature;
        }
    }
}
