using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab1
{
    enum Alg {ECB, CBC};
    class DES
    {
        private BitArray GetBitArray(string Text)
        {
            var aByte = Encoding.GetEncoding(1251).GetBytes(Text);
            return new BitArray(aByte);
        }

        BitArray GetValue(BitArray aBite, int begin, int end)
        {
            BitArray Value = new BitArray((end - begin));
            int iBit = 0;
            for (var i = begin; i < end; i++)
            {
                Value[iBit] = aBite.Get(i);
                iBit++;
            }
            return Value;
        }

        byte BitArrayToByte(BitArray aBit)
        {
            byte result = 0;
            for (byte index = 0, m = 1; index < 8; index++, m *= 2)
                result += aBit.Get(index) ? m : (byte)0;
            return result;
        }

        string GetText(BitArray aBit)
        {
            byte[] RezArrayByte = new byte[aBit.Length / 8];
            var iByte = 0;
            for (var iBit = 0; iBit < aBit.Length; iBit += 8)
                RezArrayByte[iByte++] = BitArrayToByte(GetValue(aBit, iBit, iBit + 8));
            return Encoding.GetEncoding(1251).GetString(RezArrayByte);
        }
        public string Encript(Alg alg, string d, string k)
        {
            // Преобразуем исходные данные в бинарный массив
            BitArray data = GetBitArray(d);
            // Преобразуем ключ в бинарный массив
            BitArray key = GetBitArray(k);
            bool temp;
            for (int i = 0; i < key.Length; i += 8)
                for (int j = 0; j < 4; j++)
                {
                    temp = key[i + j];
                    key[i + j] = key[i + 7 - j];
                    key[i + 7 - j] = temp;
                }
            ECB ecb = new ECB();
            string rez = "";
            
            BitArray bloc = new BitArray(64);
            switch (alg)
            {
                case Alg.ECB: 
                    for (int i = 0; i < data.Count; i += 64)
                    {
                        bloc.SetAll(false);
                        for (int j = 0; (j < 64) && ((i + j) < data.Count); j++)
                            bloc[j] = data[i + j];
                        rez += GetText(ecb.Encrypt(bloc, key)); 
                    }
                    break;
                case Alg.CBC:
                    byte[] c0 = new byte[8];
                    // Генерируем гамму для С0
                    int A = 29, C = 27, T0 = 16, B = 128;
                    c0[0] = (byte)T0;
                    for (int t = 1; t < 8; t++)
                        c0[t] = (byte)((A * c0[t - 1] + C) % B);
                    // Преобразуем С0 в бинарный массив
                    BitArray c = new BitArray(c0);
                    // выполняем шифрование
                    for (int i = 0; i < data.Count; i += 64)
                    {
                        bloc.SetAll(false);
                        for (int j = 0; (j < 64) && ((i + j) < data.Count); j++)
                            bloc[j] = data[i + j];
                        c = ecb.Encrypt(bloc.Xor(c), key);
                        rez += GetText(c); 
                    }
                    break;
            }

            return rez;
        }

        public string Decript(Alg alg, string d, string k)
        {
            BitArray data = GetBitArray(d);
            BitArray key = GetBitArray(k);
            bool temp;
            for (int i = 0; i < key.Length; i += 8)
                for (int j = 0; j < 4; j++)
                {
                    temp = key[i + j];
                    key[i + j] = key[i + 7 - j];
                    key[i + 7 - j] = temp;
                }

            ECB ecb = new ECB();
            string rez = "";

            BitArray bloc = new BitArray(64);
            switch (alg)
            {
                case Alg.ECB:
                    for (int i = 0; i < data.Count; i += 64)
                    {
                        for (int j = 0; (j < 64) && ((i + j) < data.Count); j++)
                            bloc[j] = data[i + j];
                        rez += GetText(ecb.Decrypt(bloc, key));
                    }
                    break;
                case Alg.CBC:
                    byte[] c0 = new byte[8];
                    int A = 29, C = 27, T0 = 16, B = 128;
                    c0[0] = (byte)T0;
                    for (int t = 1; t < 8; t++)
                        c0[t] = (byte)((A * c0[t - 1] + C) % B);
                    BitArray c = new BitArray(c0);
                    for (int i = 0; i < data.Count; i += 64)
                    {
                        for (int j = 0; (j < 64) && ((i + j) < data.Count); j++)
                            bloc[j] = data[i + j]; 
                        rez += GetText(c.Xor(ecb.Decrypt(bloc, key)));
                        c = (BitArray)bloc.Clone();
                    }
                    break;
            }

            return rez;
        }
    }

}
