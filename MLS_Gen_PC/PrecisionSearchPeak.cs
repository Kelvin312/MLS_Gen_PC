using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MLS_Gen_PC
{
    using T = Double;

    public class PrecisionSearchPeak  
    {

        private SeqGen _gen;

        private readonly int _minDisc;
        public int OnePer { get; }
        public int N { get; }
        public int[] Mls { get; private set; }
        public T[] ResponseE { get; private set; }
        public T[] ResponseNL { get; private set; }
        public T[] CorrelationE { get; private set; }
        public T[] CorrelationNL { get; private set; }

        public PrecisionSearchPeak(SeqGen gen, int minDisc, int nPer, double tEnv, double dnl, int q) //q>1
        {

            _gen = gen;
            N = _gen.Period * minDisc * nPer;
            _minDisc = minDisc;
            OnePer = _gen.Period * minDisc;

            _q = q;
            //exp = 1 - Math.Exp(-1.0 / tEnv);
            _exp = 1;
            if (Math.Sign(tEnv) != 0)
            {
                T emul = 1;
                T x = -1 / (T) tEnv;
                T oldExp = 0;
                for (int i = 1; oldExp != _exp; i++)
                {
                    oldExp = _exp;
                    emul *= x / i;
                    _exp += emul;
                }
                _exp = 1 - _exp;
            }
            _aq = 1;
            if (q != 1)
            {
                _aq = q * ((T) Math.Pow(q, 1.0 / (q - 1))) / (q - 1) * (T) dnl;
            }

            Mls = new int[OnePer];
            ResponseE = new T[N];
            ResponseNL = new T[N];
            CorrelationE = new T[N + OnePer];
            CorrelationNL = new T[N + OnePer];
        }

        public bool SetGen(SeqGen gen)
        {
            if (_gen.Period != gen.Period) return false;
            _gen = gen;
            return true;
        }

        private readonly T _exp;
        private readonly T _aq;
        private readonly int _q;

        private T SignPow(T val, int p)
        {
            T res = 1;
            for (int i = 0; i < p; i++)
            {
                res *= val;
            }
            return Math.Abs(res) * Math.Sign(val);
        }

        public void Calculate()
        {
            T a0 = 1 - _aq;
            T uc = 0;
            T unl = 0;
            _gen.Reset();

            for (int i = 0; i < (N / _minDisc); i++)
            {
                var x = _gen.NextValue() * 2 - 1;
                for (int j = 0; j < _minDisc; j++)
                {
                    var arrI = i * _minDisc + j;
                    if (arrI < OnePer) Mls[arrI] = x;
                    ResponseE[arrI] = uc;
                    ResponseNL[arrI] = unl;

                    uc += (x - uc) * _exp;
                    unl = a0 * uc + _aq * SignPow(uc, _q);
                }
            }

            for (int i = 0; i < (N + OnePer); i++)
            {
                T ce = 0;
                T cnl = 0;
                for (int j = 0; j < OnePer; j++)
                {
                    int k = i + j - OnePer;
                    if (k >= 0 && k < N)
                    {
                        ce += Mls[j] * ResponseE[k];
                        cnl += Mls[j] * ResponseNL[k];
                    }
                }
                CorrelationE[i] = ce;
                CorrelationNL[i] = cnl;
            }
        }

        public T[] SubCorNlCorE()
        {
            return CorrelationE.Zip(CorrelationNL, (x, y) => y - x).ToArray();
        }
    }
}
