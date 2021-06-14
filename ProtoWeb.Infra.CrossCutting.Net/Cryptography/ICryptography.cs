using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Infra.CrossCutting.Net.Cryptography
{
    public interface ICryptography
    {
        string EncryptString(string plainText);
        string DecryptString(string cipherTextString);
        //string Encrypt(string clearText);
        //string Decrypt(string cipherText);


        //string EncryptStringToBytes_Aes(string plainText);
        //string DecryptStringFromBytes_Aes(string plainText);


        //string EncryptStringToBytes(string plainText);
        //string DecryptStringFromBytes(string plainTex);
    }
}
