using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Des
    {
        // Элемент это позиция из исходного текста, а индекс - это позиция в новом тексте
        byte[] TranspositOTTable = new byte[64]{ 58, 50, 42, 34, 26, 18, 10, 2, 60, 52, 44, 36, 28, 20, 12, 4,
                                    62, 54, 46, 38, 30, 22, 14, 6, 64, 56, 48, 40, 32, 24, 16, 8,
                                    57, 49, 41, 33, 25, 17, 9,  1, 59, 51, 43, 35, 27, 19, 11, 3,
                                    61, 53, 45, 37, 29, 21, 13, 5, 63, 55, 47, 39, 31, 23, 15, 7};

        byte[] ExtensionRTable = new byte[48]{ 32, 1, 2, 3, 4, 5, 4, 5, 6, 7, 8, 9, 8, 9, 10, 11, 12, 13, 
                                        12, 13, 14, 15, 16, 17, 16, 17, 18, 19, 20, 21, 20, 21, 22,
                                        23, 24, 25, 24, 25, 26, 27, 28, 29, 28, 29, 30, 31, 32, 1};
        byte[] TranspositSTable = new byte[32]{ 16, 7, 20, 21, 29, 12, 28, 17, 1, 15, 23, 26, 5, 18, 31, 10,
                                                2, 8, 24, 14, 32, 27, 3, 9, 19, 13, 30, 6, 22, 11, 4, 25};
        byte[] TranspositionPC1Table = new byte[56]{ 57, 49, 41, 33, 25, 17, 9, 1, 58, 50, 42, 34, 26, 18,
                                                10, 2, 59, 51, 43, 35, 27, 19, 11, 3, 60, 52, 44, 36,
                                                63, 55, 47, 39, 31, 23, 15, 7, 62, 54, 46, 38, 30, 22,
                                                14, 6, 61, 53, 45, 37, 29, 21, 13, 5, 28, 20, 12, 4};
        byte[] TranspositionPC2Table = new byte[48]{ 14, 17, 11, 24, 1, 5, 3, 28, 15, 6, 21, 10, 23, 19, 12, 4,
                                                26, 8, 16, 7, 27, 20, 13, 2, 41, 52, 31, 37, 47, 55, 30, 40,
                                                51, 45, 33, 48, 44, 49, 39, 56, 34, 53, 46, 42, 50, 36, 29, 32};
        byte[] LSTable = new byte[16] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };
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

        public Des() { }

        // Этап 1: перестановка битов открытого текста(ОТ)
        UInt64 TranspositionOT(UInt64 ot)
        {
            UInt64 rez = 0;
            
            for (byte i = 0; i < 64; i++)
            {
                rez |= ((ot >> (TranspositOTTable[i] - 1)) & 0x0001) << i;
            }

            return rez;
        }

        // Этап 2: Основной цикл
        public UInt64 Encrypt(UInt64 ot, UInt64 key)
        {
            UInt32 L, R, temp;
            UInt64 data = TranspositionOT(ot);

            L = (UInt32)((data >> 32) & 0xFFFFFFFF);
            R = (UInt32)(data & 0xFFFFFFFF);

            for(byte i = 0; i < 16; i++)
            {
                temp = R;
                R = L ^ fRK(R, GetKeyI(key, i+1));
                L = temp;
            }

            data = (L << 32) | R;

            return InverseTransposition(data);
        }

        public UInt64 Decrypt(UInt64 zt, UInt64 key)
        {
            UInt32 L, R;
            UInt64 data = TranspositionOT(zt);

            L = (UInt32)((data >> 32) & 0xFFFFFFFF);
            R = (UInt32)(data & 0xFFFFFFFF);

            for (int i = 15; i >= 0; i--)
            {
                R = L ^ fRK(R, GetKeyI(key, (byte)i));
                L = R;
            }

            data = R | (L << 32);

            return InverseTransposition(data);
        }

        UInt64 InverseTransposition(UInt64 data)
        {
            UInt64 rez = 0;
            for(byte i = 0; i < 64; i++)
                if (((data >> i) & 0x1) == 1) rez = rez | (UInt64)(1 << (TranspositOTTable[i] - 1));
            return rez;
        }

        UInt32 fRK(UInt32 R, UInt64 K)
        {
            UInt64 extensR = ExtensionR(R);
            UInt64 sumRK = extensR ^ K;
            UInt32 s = S(sumRK);
            return TranspositionS(s);
        }

        // Расширение R
        UInt64 ExtensionR(UInt32 R)
        { 
            UInt64 E = 0;            

            for (byte i = 0; i < 48; i++)
            {
                E |= ((R >> (ExtensionRTable[i] - 1)) & 0x001) << i;
            }

            return E;
        }

        UInt32 S(UInt64 data)
        {
            byte k, l;
            UInt32 rez = 0;
            byte inf;

            for(byte i = 0; i < 8; i++)
            {
                inf = (byte)(data & 0x3F);
                data >>= 6;

                k = (byte)(((inf << 1) | (inf >> 5)) & 0x03);
                l = 0;
                for(byte j = 1; j < 5; j++)
                    l = (byte)((l << 1) | ((inf >> j) & 0x01));
                rez = rez | (UInt32)(STable[i, k, l] << (i * 4));
            }
            return rez;
        }

        UInt32 TranspositionS(UInt32 s)
        { 
            UInt32 rez = 0;
            
            for (byte i = 0; i < 32; i++)
            {
                rez |= ((s >> (TranspositSTable[i] - 1)) & 0x01) << i;
            }

            return rez;
        }

        UInt64 GetKeyI(UInt64 key, byte n)
        {
            UInt64 data = TranspositionPC1(key);
            UInt32 L = (UInt32)((data >> 28) & 0xFFFFFFF);
            UInt32 R = (UInt32)(data & 0xFFFFFFF);

            for(byte i = 0; i < n; i++)
            {
                R = R >> LSTable[i];
                L = L >> LSTable[i];
            }

            data = (R << 32) | L;

            return TranspositionPC2(data);
        }

        UInt64 TranspositionPC1(UInt64 key)
        {
            UInt64 rez = 0;

            for (byte i = 0; i < 56; i++)
            {
                rez |= ((key >> (TranspositionPC1Table[i] - 1)) & 0x01) << i;
            }

            return rez;
        }

        UInt64 TranspositionPC2(UInt64 key)
        {
            UInt64 rez = 0;

            for (byte i = 0; i < 48; i++)
            {
                rez |= ((key >> (TranspositionPC2Table[i] - 1)) & 0x01) << i;
            }

            return rez;
        }
    }
}
