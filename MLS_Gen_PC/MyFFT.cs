using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MLS_Gen_PC
{
    public class MyFFT
    {
        public MyFFT(int n)
        {
            if (n < 2 || (n & (n - 1)) != 0) throw new ArgumentException("n != pow(2, x)", "n");
            int nd2 = n/2;
            N = n; 
           // LogN = 1;
           // while ((1 << LogN) != n) LogN++;

            W = new Complex[nd2];
            double ang = -Math.PI / nd2;
            for (int i = 0; i < nd2; i++)
            {
                W[i] = new Complex(Math.Cos(i*ang), Math.Sin(i*ang));
            }
        }

        public readonly int N;
        //public readonly int LogN;
        public readonly Complex[] W;

        public void SFFT(Complex[] s)
        {
            if (N != s.Length) throw new ArgumentException("len s != n", "s");

            for (int step = N/2, mulI = 1; step > 0; step >>= 1, mulI <<= 1)
            {
                for (int bias = step; bias < N; bias += step*2)
                {
                    for (int i = 0; i < step; i++)
                    {
                        int fi = i + bias - step;
                        int si = i + bias;
                        var fs = s[fi];
                        var ss = s[si];

                        s[fi] = fs + ss;
                        s[si] = (fs - ss) * W[i * mulI];
                    }
                }
            }
        }

        public void EmaxxFFT(Complex[] a)
        {
            int n = a.Length;
            for (int len = 2; len <= n; len <<= 1)
            {
                double ang = 2 * Math.PI / len * -1;
                Complex wlen = new Complex(Math.Cos(ang), Math.Sin(ang));
                for (int i = 0; i < n; i += len)
                {
                    Complex w = new Complex(1,0);
                    for (int j = 0; j < len / 2; ++j)
                    {
                        Complex u = a[i + j],  v = a[i + j + len / 2] * w;
                        a[i + j] = u + v;
                        a[i + j + len / 2] = u - v;
                        w *= wlen;
                    }
                }
            }
        }

        public void BitRevers(Complex[] s)
        {
            if (N != s.Length) throw new ArgumentException("len s != n", "s");

            for (int a = 1; a < N; a++)
            {
                int b = 0;
                for (int j = 1; j < N; j <<= 1)
                {
                    b <<= 1;
                    if ((a & j) != 0) b |= 1;
                }
                if (b > a)
                {
                    Complex t = s[a];
                    s[a] = s[b];
                    s[b] = t;
                }
            }
        }
    }
}
