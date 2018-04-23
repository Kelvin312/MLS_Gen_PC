using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLS_Gen_PC
{
    public class SeqGen
    {
        public SeqGen(int feedback)
        {
            Recalc(feedback);
        }

        public SeqGen(SeqGen sg)
        {
            _feedback = sg.Feedback;
            IsValid = sg.IsValid;
            IsResize = sg.IsResize;
            Period = sg.Period;
            Nbits = sg.Nbits;
            MaxFeedbackCount = sg.MaxFeedbackCount;
            Reset();
        }

        private void Recalc(int feedback)
        {
            _feedback = feedback;
            IsValid = false;
            IsResize = true;
            Period = CalcPeriod(_feedback);
            Nbits = CalcNbits(Period);
            MaxFeedbackCount = Nbits < 2 ? 0 : Phi(Period) / Nbits;
            Reset();
        }

        protected int Lfsr;
        private int _feedback;

        public virtual int Feedback
        {
            get
            {
                return _feedback;
            }
            set
            {
                IsResize = false;
                Reset();
                if (value != _feedback)
                {
                    if (Period != CalcPeriod(value)) Recalc(value);
                    _feedback = value;
                    IsValid = false;
                }
            } 
        }
        public int Period { get; private set; }
        public int Nbits { get; private set; }
        public int MaxFeedbackCount { get; private set; }
        public bool IsResize { get; private set; }
        public bool IsValid { get; set; }

        public static int CalcPeriod(int fb)
        {
            fb |= fb >> 1;
            fb |= fb >> 2;
            fb |= fb >> 4;
            fb |= fb >> 8;
            fb |= fb >> 16;
            return fb;
        }

        public static int CalcNbits(int per)
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


        public virtual bool Validate()
        {
            if (!IsValid)
            {
                var temp = new SeqGenValidator(this);
                IsValid = temp.Validate();
            }
            return IsValid;
        }
    }
}
