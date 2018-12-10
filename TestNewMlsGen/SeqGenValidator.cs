using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNewMlsGen
{
    public class SeqGenValidator:SeqGen
    {
        public SeqGenValidator(int feedback):this(new SeqGen(feedback))
        { }
        
        public SeqGenValidator(SeqGen sg) : base(sg)
        {
            AllocMemory();
        }

        private void AllocMemory()
        {
            _test = new ulong[(Period >> 6) + 1];
        }

        private ulong[] _test;


        public override int Feedback
        {
            get { return base.Feedback; }
            set
            {
                base.Feedback = value;
                if (IsResize) AllocMemory();
            }
        }

        public override bool Validate()
        {
            if (ParityBit(Feedback) || Feedback == 0) return false;
            Array.Clear(_test, 0, _test.Length);

            for (int j = 0; j < Period; j++)
            {
                var hi = (Lfsr & Period) >> 6;
                var li = 1UL << (Lfsr & 63);
                if ((_test[hi] & li) != 0) return false;
                _test[hi] |= li;
                NextValue();
            }

            Reset();
            IsValid = true;
            return true;
        }




        public List<int> CalculateDecimatMls ()
        {
            Array.Clear(_test, 0, _test.Length);
            var decimationList = new List<int>();
            var fbList = new List<int>();


            for (int j = 3; j < Period; j+=2)
            {
                var hi = (j) >> 6;
                var li = 1UL << (j & 63);

                if((_test[hi] & li) != 0) continue;
                if (Period % j == 0) continue;
                var x = j;

                for (int i = 1; i < Nbits; i++)
                {
                    x <<= 1;
                    x |= x >> Nbits;
                    x &= Period;

                     hi = (x) >> 6;
                     li = 1UL << (x & 63);
                    _test[hi] |= li;
                }

                 decimationList.Add(j);
            }



            foreach (var dper in decimationList)
            {
                long s = 0;
                for (var j = 0; j < Nbits * 2; j++)
                {
                    for (var i = 1; i < dper; i++) NextValue();
                    s <<= 1;
                    s |= NextValue();
                }
                fbList.Add(CalculateBMA(s, Nbits*2));

            }

            return fbList;
        }

        public int CalculateBMA(long Sx, int n)
        {
            long Bx, Tx, Cx;
            Bx = 1;
            Cx = 1;
            int L = 0, m = -1;
            for (int N = 0; N < n; N++)
            {
                var di = Xor(((1L<<(L+1))-1) & Cx & (Sx >> (n - 1 - N)));
                if (di != 0)
                {
                    Tx = Cx;
                    Cx ^=((1L<<n)-1) & (Bx<<(N-m));
                    if (2 * L <= N)
                    {
                        L = N + 1 - L;
                        m = N;
                        Bx = Tx;
                    }
                }
            }

            return bitReverse((int) (((1L << (L + 0)) - 1) & Cx));
        }

        public long Xor(long x)
        {
            x ^= x >> 1;
            x ^= x >> 2;
            x ^= x >> 4;
            x ^= x >> 8;
            x ^= x >> 16;
            x ^= x >> 32;
            return x&1;
        }


        public int bitReverse(int x)
        {
            var y = 0;
            while (x != 0)
            {
                y <<= 1;
                y |= 1 & x;
                x >>= 1;
            }
            return y;
        }
        
    }
}
