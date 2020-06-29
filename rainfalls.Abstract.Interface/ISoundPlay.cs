using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rainfalls.Abstract.Interface
{
    public interface ISoundPlay
    {
        void AppendSoundAcc();
        void RemoveSoundAcc();
        void RemoveSoundAcc(int t);
    }
}
