using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLS_Gen_PC
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

        
    }
}
