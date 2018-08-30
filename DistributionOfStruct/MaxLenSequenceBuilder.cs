using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using FFTWSharp;


namespace DistributionOfStruct
{
    public class MaxLenSequenceBuilder
    {
        public int NumBits { get; }
        public int Period { get; }
        public int Feedback { get; private set; }
        private int Lfsr { get; set; }

        private readonly ulong[] _testAray;
        private readonly fftw_complexarray _real;
        private readonly fftw_complexarray _complex;
        private readonly fftw_plan _forward;
        private readonly fftw_plan _backward;

        private double[] _correlations;
        private double[] _mls;

        public IEnumerable<double> Correlations => _correlations.Take(Period);

        public int FullPeriod { get; private set; }

        public MaxLenSequenceBuilder(int nBits)
        {
            NumBits = nBits;
            Feedback = 1 << (NumBits - 1);
            Period = CalcPeriod(Feedback);
            _testAray = new ulong[(Period >> 6) + 1]; //AllocMemory();
            --Feedback;

            FullPeriod = Period; //var N = Period * minDisc * nPer;
            var ArrSz = ((FullPeriod + 1) / 2) * 2;
               _mls = new double[ArrSz];
            _correlations = new double[ArrSz];
           
            _real = new fftw_complexarray(ArrSz / 2);
            _complex = new fftw_complexarray(FullPeriod / 2 + 1);
            _forward = fftw_plan.dft_r2c_1d(FullPeriod, _real, _complex, fftw_flags.Estimate | fftw_flags.DestroyInput);
            _backward = fftw_plan.dft_c2r_1d(FullPeriod, _complex, _real, fftw_direction.Backward, fftw_flags.Estimate);
        }

        public bool CreateNextMaxLenSequence()
        {
            for (++Feedback; Feedback < 1 << NumBits; Feedback++)
            {
                if (Validate()) 
                {
                    CreateMaxLenSequence();
                    return true;
                }
            }
            return false;
        }

        private void CreateMaxLenSequence()
        {
            var minDisc = 1;
            var nPer = 1;
            var tEnv = 0.8;
            var dnl = 0.4;
            var q = 2;

            var N = Period * minDisc * nPer;
            var ArrSz = ((N + 1) / 2) * 2;
            var OnePer = Period * minDisc;
            

            var exp = 1.0;
            if (Math.Sign(tEnv) != 0) exp = 1 - Math.Exp(-1.0 / tEnv);
            var aq = q * Math.Pow(q, 1.0 / (q - 1)) / (q - 1) * dnl;

            var uc = 0.0;
            var unl = 0.0;
            Reset();
            for (var i = 0; i < N; i++)
            {
                var x = NextValue() * 2 - 1;
                _mls[i] = x;
                _correlations[i] = unl;
                uc += (x - uc) * exp;
                unl = uc + (Math.Abs(Math.Pow(uc, q - 1)) - 1) * aq * uc;
            }

            _real.SetData(_mls);
            _forward.Execute();
            var fftMls = _complex.GetData_Complex();
            _real.SetData(_correlations);
            _forward.Execute();
            _complex.SetData(_complex.GetData_Complex().Zip(fftMls, (x, y) => Complex.Conjugate(y) * x / N).ToArray());
            _backward.Execute();
            _correlations = _real.GetData_double();
        }


        public void Reset()
        {
            Lfsr = 1;
        }
        public int NextValue()
        {
            var res = Lfsr & 1;
            Lfsr >>= 1;
            if (res == 1) Lfsr ^= Feedback;
            //return res;
            return Lfsr & 1;
        }

       
        private void AllocMemory()
        {
           // _testAray = new ulong[(Period >> 6) + 1];
        }

        public bool Validate()
        {
            if (ParityBit(Feedback) || Feedback == 0) return false;
            Array.Clear(_testAray, 0, _testAray.Length);
            Reset();

            for (var j = 0; j < Period; j++)
            {
                var high = (Lfsr & Period) >> 6;
                var low = 1UL << (Lfsr & 63);
                if ((_testAray[high] & low) != 0) return false;
                _testAray[high] |= low;
                NextValue();
            }
            return true;
        }





        public static int CalcPeriod(int fb)
        {
            fb |= fb >> 1;
            fb |= fb >> 2;
            fb |= fb >> 4;
            fb |= fb >> 8;
            fb |= fb >> 16;
            return fb;
        }

        public static int CalcNumBits(int per)
        {
            int n = 0;
            while (per > 30)
            {
                per >>= 5;
                n += 5;
            }
            while (per > 0)
            {
                per >>= 1;
                n += 1;
            }
            return n;
        }

        public static int Phi(int n) //Функция Эйлера
        {
            int res = n;
            for (int i = 2; i * i <= n; ++i)
                if (n % i == 0)
                {
                    while (n % i == 0) n /= i;
                    res -= res / i;
                }
            if (n > 1) res -= res / n;
            return res;
        }

        public static bool ParityBit(int n)
        {
            n ^= n >> 1;
            n ^= n >> 2;
            n ^= n >> 4;
            n ^= n >> 8;
            n ^= n >> 16;
            n &= 1;
            return n == 1;
        }


        public int GetMaxFeedbackCount()
        {
            return NumBits < 2 ? 0 : Phi(Period) / NumBits;
        }
    }
}
