using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab1
{
    class ECB
    {
        // Элемент это позиция из исходного текста, а индекс - это позиция в новом тексте
        byte[] TranspositOTTable = new byte[64]{ 57, 49, 41, 33, 25, 17, 9, 1, 59, 51, 43, 35, 27, 19, 11, 3,
                                    61, 53, 45, 37, 29, 21, 13, 5, 63, 55, 47, 39, 31, 23, 15, 7,
                                    56, 48, 40, 32, 24, 16, 8,  0, 58, 50, 42, 34, 26, 18, 10, 2,
                                    60, 52, 44, 36, 28, 20, 12, 4, 62, 54, 46, 38, 30, 22, 14, 6};
        byte[] ExtensionRTable = new byte[48]{ 31, 0, 1, 2, 3, 4, 3, 4, 5, 6, 7, 8, 7, 8, 9, 10, 11, 12, 
                                        11, 12, 13, 14, 15, 16, 15, 16, 17, 18, 19, 20, 19, 20, 21,
                                        22, 23, 24, 23, 24, 25, 26, 27, 28, 27, 28, 29, 30, 31, 0};
        byte[, ,] STable = new byte[8, 4, 16]
        {
            {
                { 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7 },
                { 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8 },
                { 4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0 },
                { 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 }
            },
            {
                { 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10 },
                { 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 },
                { 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15 },
                { 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 }
            },
            {
                { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8 },
                { 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1 },
                { 13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7 },
                { 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 }
            },
            {
                { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 },
                { 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9 },
                { 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4 },
                { 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 }
            },
            {
                { 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 },
                { 14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6 },
                { 4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14 },
                { 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 }
            },
            {
                { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 },
                { 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 },
                { 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6 },
                { 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 }
            },
            {
                { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 },
                { 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6 },
                { 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2 },
                { 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 }
            },
            {
                { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 },
                { 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2 },
                { 7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 13, 5, 8 },
                { 2, 1, 14, 7, 4, 10, 8, 13, 5, 12, 9, 0, 3, 5, 5, 11 }
            }
        };
        byte[] TranspositPTable = new byte[32]{ 15, 6, 19, 20, 28, 11, 27, 16, 0, 14, 22, 25, 4, 17, 30, 9,
                                                1, 7, 23, 13, 31, 26, 2, 8, 18, 12, 29, 5, 21, 10, 3, 24};
        byte[] TranspositionPC1Table = new byte[56]{ 56, 48, 40, 32, 24, 16, 8, 0, 57, 49, 41, 33, 25, 17,
                                                9, 1, 58, 50, 42, 34, 26, 18, 10, 2, 59, 51, 43, 35,
                                                62, 54, 46, 38, 30, 22, 14, 6, 61, 53, 45, 37, 29, 21,
                                                13, 5, 60, 52, 44, 36, 28, 20, 12, 4, 27, 19, 11, 3};
        byte[] TranspositionPC2Table = new byte[48]{ 13, 16, 10, 23, 0, 4, 2, 27, 14, 5, 20, 9, 22, 18, 11, 3,
                                                25, 7, 15, 6, 26, 19, 12, 1, 40, 51, 30, 36, 46, 54, 29, 39,
                                                50, 44, 32, 47, 43, 48, 38, 55, 33, 52, 45, 41, 49, 35, 28, 31};
        byte[] LSTable = new byte[16] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

        private BitArray TranspositBits(BitArray data, byte[] transpositTable)
        {
            BitArray transpositData = new BitArray(transpositTable.Length);
            for (byte i = 0; i < transpositTable.Length; i++)
            {
                transpositData[i] = data.Get(transpositTable[i]);
            }
            return transpositData;
        }

        private BitArray ITranspositBits(BitArray data, byte[] transpositTable)
        {
            BitArray transpositData = new BitArray(transpositTable.Length);
            for (byte i = 0; i < transpositTable.Length; i++)
            {
                transpositData[transpositTable[i]] = data.Get(i);
            }
            return transpositData;
        }

        public BitArray Encrypt(BitArray data, BitArray key)
        {
            BitArray L = new BitArray(32);  
            BitArray R = new BitArray(32); 
            // Начальная перестановка IP входного блока
            BitArray inf = TranspositBits(data, TranspositOTTable);
            BitArray oldR;

            // Разделение входного блока
            // на левую и правую полублока
            for(byte i = 0; i < 32; i++)
            {
                L[i] = inf[i];
                R[i] = inf[32 + i];
            }

            // 16 циклов шифрующих преобразований
            for (byte i = 0; i < 16; i++)
            {
                oldR = R;
                R = L.Xor(fRK(oldR, GetKeyI(key, (byte)(i + 1))));
                L = oldR;
            }

            // Объединение полублоков
            for (byte i = 0; i < 32; i++)
            {
                inf[i] = L[i];
                inf[32 + i] = R[i];
            }

            // Завершающая обратная перестановка
            return ITranspositBits(inf, TranspositOTTable);
        }

        public BitArray Decrypt(BitArray data, BitArray key)
        {
            BitArray L = new BitArray(32);
            BitArray R = new BitArray(32);
            // Начальная перестановка IP входного блока
            BitArray inf = TranspositBits(data, TranspositOTTable);
            BitArray oldL;

            // Разделение входного блока
            // на левую и правую полублока
            for (byte i = 0; i < 32; i++)
            {
                L[i] = inf[i];
                R[i] = inf[32 + i];
            }

            // 16 циклов шифрующих преобразований
            for (byte i = 16; i > 0; i--)
            {
                oldL = L;
                L = R.Xor(fRK(oldL, GetKeyI(key, i)));
                R = oldL;
            }

            // Объединение полублоков
            for (byte i = 0; i < 32; i++)
            {
                inf[i] = L[i];
                inf[32 + i] = R[i];
            }

            // Завершающая обратная перестановка
            return ITranspositBits(inf, TranspositOTTable);
        }

        // Генерация ключа для n-ого цикла шифрования
        BitArray GetKeyI(BitArray key, byte n) // key 64bit(inf 56bit) ret 48bit
        {
            BitArray data = TranspositBits(key, TranspositionPC1Table);
            BitArray L = new BitArray(28);
            BitArray R = new BitArray(28);
            bool Ls, Rs;

            for (byte i = 0; i < 28; i++)
            {
                L[i] = data[i];
                R[i] = data[28 + i];
            }

            for (byte i = 0; i < n; i++)
            {
                for (byte m = 0; m < LSTable[i]; m++)
                {
                    Ls = L[0];
                    Rs = R[0];
                    for (byte j = 0; j < 27; j++)
                    {
                        L[j] = L[j + 1];
                        R[j] = R[j + 1];
                    }
                    L[27] = Ls;
                    R[27] = Rs;
                }
            }

            for (byte i = 0; i < 28; i++)
            {
                data[i] = L[i];
                data[28 + i] = R[i];
            }

            return TranspositBits(data, TranspositionPC2Table);
        }

        BitArray fRK(BitArray R, BitArray K) // R = 32; K = 48; ret = 32
        {
            // перестановка и расширение R до 48bit
            BitArray extensR = TranspositBits(R, ExtensionRTable); 
            // Гаммирование вектора К и расширения R
            BitArray xorRK = extensR.Xor(K);
            // Преобразование на S блоках
            BitArray s = S(xorRK);
            // Перестановка вектора s
            return TranspositBits(s, TranspositPTable);
        }

        BitArray S(BitArray data) // data 48 bit; ret 32
        {
            byte k, l, inf;
            BitArray rez = new BitArray(32);
            byte index = 0;

            for (byte i = 0; i < 48; i+=6)
            {
                if (data[i])
                    if (data[i + 5]) k = 3;
                    else k = 2;
                else
                    if (data[i + 5]) k = 1;
                    else k = 0;

                l = 0;
                for (byte j = 1; j < 5; j++)
                {
                    l = (byte)(l << 1);
                    if (data[i + j]) l = (byte)(l | 0x1);
                } 

                inf = STable[i/6, k, l];
                for (int j = 3; j >= 0; j--)
                {
                    rez[index] = (((inf >> j) & 0x1) == 1);
                    index++;
                }
            }
            return rez;
        }




    }
}
