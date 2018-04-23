using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Numerics;
using FFTWSharp;

namespace MLS_Gen_PC
{
    using T = Double;
    public class SearchPeak
    {
        private SeqGen _gen;

        private readonly bool _isFastMode;
        private readonly int _minDisc;
        public int OnePer { get; }
        public int N { get; }
        private int ArrSz { get; }
        public T[] Mls { get; private set; }
        public T[] ResponseE { get; private set; }
        public T[] ResponseNL { get; private set; }
        public T[] CorrelationE { get; private set; }
        public T[] CorrelationNL { get; private set; }


        public SearchPeak(SeqGen gen, int minDisc, int nPer, double tEnv, double dnl, int q, bool isFastMode = false)
        {
            _gen = gen;
            _isFastMode = isFastMode;
            if (isFastMode)
            {
                minDisc = nPer = 1;
            }

            N = _gen.Period * minDisc * nPer;
            ArrSz = ((N + 1) / 2) * 2;
            _minDisc = minDisc;
            OnePer = _gen.Period * minDisc;

            _q = q;
            _exp = 1;
            if (Math.Sign(tEnv) != 0) _exp = 1 - Math.Exp(-1.0 / tEnv);
            _aq = q * Math.Pow(q, 1.0 / (q - 1)) / (q - 1) * dnl;

            Mls = new T[ArrSz];
            if (!isFastMode)
            {
                Array.Clear(Mls, 0, Mls.Length);
                ResponseE = new T[ArrSz];
                CorrelationE = new T[ArrSz];
                CorrelationNL = new T[ArrSz];
            }
            ResponseNL = new T[ArrSz];

            real = new fftw_complexarray(ArrSz / 2);
            complex = new fftw_complexarray(N / 2 + 1);
            forward = fftw_plan.dft_r2c_1d(N, real, complex, fftw_flags.Estimate | fftw_flags.DestroyInput);
            backward = fftw_plan.dft_c2r_1d(N, complex, real, fftw_direction.Backward, fftw_flags.Estimate);
        }

        private readonly double _exp;
        private readonly double _aq;
        private readonly int _q;

        private fftw_complexarray real;
        private fftw_complexarray complex;
        private fftw_plan forward;
        private fftw_plan backward;

        public bool SetNewGen(SeqGen gen)
        {
            if (gen.Period != _gen.Period) return false;
            _gen = gen;
            return true;
        }


        //public float[] Correct(float[] data)
        //{
        //    var res = new float[ArrSz];
        //    for (int i = 1; i < N; i++)
        //    {
        //        res[i] = data[i] - data[N - i];
        //    }
        //    res[0] = data[0];
        //    return res;
        //}

        //public int GetPeak()
        //{
        //    int maxI = Correlation.Length/2;
        //    for (int i = 2; i < Correlation.Length; i++)
        //    {
        //        if (Correlation[i].CompareTo(Correlation[maxI]) > 0) maxI = i;
        //    }
        //    return maxI;
        //}

        //public void Normalize()
        //{
        //    int n = Correlation.Length;
        //    Correlation = Correlation.Select(x => (float)Math.Round(x + 1)).ToArray();
        //}

        //public float[] DeltaCalculate()
        //{
        //    var mlsInt = new int[ArrSz];
        //    var responseNlInt = new int[ArrSz];
        //    int amp = (int)Math.Round(Math.Pow(10, 180 / 20.0));

        //    double uc = 0;
        //    _gen.Reset();

        //    for (int i = 0; i < N; i++)
        //    {
        //        var x = _gen.NextValue() * 2 - 1;
        //        var unl = (1 - aq) * uc + aq * uc * Math.Abs(Math.Pow(uc, q - 1));
        //        mlsInt[i] = i < _gen.Period ? x : 0;
        //        responseNlInt[i] = (int)Math.Round(unl * amp);
        //        uc += (x - uc) * exp;
        //    }

        //    real.SetData(mlsInt.Select((x)=>(float)x).ToArray());
        //    forward.Execute();
        //    var fftMls = complex.GetData_Complex();

        //    real.SetData(responseNlInt.Select((x) => (float)x).ToArray());
        //    forward.Execute();

        //    complex.SetData(complex.GetData_Complex().Zip(fftMls, (x, y) => Complex.Conjugate(y) * x / N).ToArray());
        //    backward.Execute();
        //    var fftCorr = real.GetData_float();

        //    var delta = new float[ArrSz];
        //    for (int i = 0; i < N; i++)
        //    {
        //        long res = 0;
        //        for (int j = 0; j < N; j++)
        //        {
        //            int k = i + j - N;
        //            if (k < 0) k += N;
        //            res += mlsInt[j] *1L* responseNlInt[k];
        //        }
        //        delta[i] = (long)Math.Round(fftCorr[i]) - res;
        //    }
        //    return delta;
        //}
           

       

        public void Calculate()
        {
            double uc = 0;
            double unl = 0;
            _gen.Reset();

            if (_isFastMode)
            {
                for (int i = 0; i < N; i++)
                {
                    var x = _gen.NextValue() * 2 - 1;
                    Mls[i] = x;
                    ResponseNL[i] = (T)unl;
                    uc += (x - uc) * _exp;
                    unl = uc + (Math.Abs(Math.Pow(uc, _q - 1)) - 1) * _aq * uc;
                }
            }
            else
            {
                for (int i = 0; i < N / _minDisc; i++)
                {
                    var x = _gen.NextValue() * 2 - 1;
                    for (int j = 0; j < _minDisc; j++)
                    {
                        var arrI = i * _minDisc + j;
                        if (arrI < OnePer) Mls[arrI] = x;
                        ResponseE[arrI] = (T)uc;
                        ResponseNL[arrI] = (T)unl;
                        uc += (x - uc) * _exp;
                        unl = uc + (Math.Abs(Math.Pow(uc, _q - 1)) - 1) * _aq * uc;
                    }
                }
            }
               

            real.SetData(Mls);
            forward.Execute();
            var fftMls  = complex.GetData_Complex();

            if (!_isFastMode)
            {
                real.SetData(ResponseE);
                forward.Execute();
                complex.SetData(complex.GetData_Complex()
                    .Zip(fftMls, (x, y) => Complex.Conjugate(y) * x / N)
                    .ToArray());
                backward.Execute();
                CorrelationE = real.GetData_double();
            }
            real.SetData(ResponseNL);
            forward.Execute();
            complex.SetData(complex.GetData_Complex().Zip(fftMls, (x, y) => Complex.Conjugate(y) * x / N).ToArray());
            backward.Execute();
            if(_isFastMode) ResponseNL = real.GetData_double();
            else  CorrelationNL = real.GetData_double();
        }

    }
}
