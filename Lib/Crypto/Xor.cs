using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Crypto
{
    public class Xor
    {
        private byte[] secret;

        public Xor(byte[] secret)
        {
            if (secret.Length == 0)
                throw new ArgumentOutOfRangeException("secret length must be greater than 0");

            this.secret = secret;
        }

        public byte[] DoXor(byte[] input)
        {
            byte[] result = new byte[input.Length];

            for (int index = 0, secretIndex = 0; index < input.Length; index++, secretIndex = (secretIndex + 1) % secret.Length)
                result[index] = (byte)(input[index] ^ secret[secretIndex]);

            return result;
        }
 
        public String DoXor(byte[] input, Encoding encoding)
        {
            if (encoding == null)
                throw new ArgumentNullException("encoding");

            var xoredBytes = DoXor(input);
            return encoding.GetString(xoredBytes);
        }
    }
}
