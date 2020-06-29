using System;
using System.Collections.Generic;
using System.Text;
using rainfalls.path;
namespace rainfalls.state
{
    public class workAreaState
    {
        private int m_nCurLevel;
        public int Level
        {
            set
            {
                m_nCurLevel = value;
            }
            get
            {
                return m_nCurLevel;
            }
        }
    }
}
