using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using rainfalls.path;
using rainfalls.Abstract.Interface;
namespace rainfalls.Business.SoundPlay
{
    public class CAlarmSound : ISoundPlay, IDisposable
    {
        private static CAlarmSound uniqueInstance;
        private int m_nAcc;
        private static readonly object padlock = new object();
        Thread m_pSoundThread = null;
        protected bool disposed = false;
        [System.Runtime.InteropServices.DllImport("winmm")]
        extern static bool PlaySound(string strFile, IntPtr hMod, int flag);
        private CAlarmSound()
        {
            m_nAcc = 0;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static CAlarmSound getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new CAlarmSound();
                    }
                }
            }
            return uniqueInstance;
        }
        public enum Flags : int
        {
            SND_SYNC = 0x0,    // play synchronously (default) 
            SND_ASYNC = 0x1,    // play asynchronously 
            SND_NODEFAULT = 0x2,    // silence (!default) if sound not found 
            SND_MEMORY = 0x4,      // pszSound points to a memory file 
            SND_LOOP = 0x8,    // loop the sound until next sndPlaySound 
            SND_NOSTOP = 0x10,      // don't stop any currently playing sound 
            SND_NOWAIT = 0x2000,    // don't wait if the driver is busy 
            SND_ALIAS = 0x10000,    // name is a registry alias 
            SND_ALIAS_ID = 0x110000,// alias is a predefined ID 
            SND_FILENAME = 0x20000, // name is file name 
            SND_RESOURCE = 0x40004, // name is resource name or atom 
        };
        void SoundThread()
        {
            try
            {
                for (; ; )
                {
                    if (m_nAcc > 0)
                        PlaySound(paths.soundPath, IntPtr.Zero, (int)(Flags.SND_FILENAME | Flags.SND_SYNC));
                }


            }
            catch (Exception e)
            {
                //Shared.Base.CLog.LOG(e.Message);
                //Shared.Base.CLog.LOG("Exception occur in SoundThread()");
            }
        }
        private void StartSoundThread()
        {
            if (m_pSoundThread == null)
            {

                m_pSoundThread = new Thread(new ThreadStart(SoundThread));
                m_pSoundThread.Start();

            }
        }
        private void StopSoundThread()
        {
            if (m_nAcc <= 0)
            {
                if (m_pSoundThread != null)
                    if (m_pSoundThread.IsAlive)
                        m_pSoundThread.Abort();
                m_pSoundThread = null;
            }
        }
        public void AppendSoundAcc()
        {
            m_nAcc++; StartSoundThread();
        }

        public void RemoveSoundAcc()
        {
            m_nAcc--; StopSoundThread();
        }
        public void RemoveSoundAcc(int t)
        {
            m_nAcc -= t; StopSoundThread();
        }
        public void Dispose()
        {
            if (!this.disposed)
            {
                try
                {
                    if (m_pSoundThread != null)
                        if (m_pSoundThread.IsAlive)
                            m_pSoundThread.Abort();
                }
                finally
                {
                    this.disposed = true;
                    GC.SuppressFinalize(this);
                }
            }
        }
    }
}
