using ShowNow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShowNow
{
    public class LogManager
    {
        #region 单例
        private static readonly object InstanceLock = new object();
        private static LogManager _instance;

        public static LogManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (InstanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LogManager();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        public LockedQueue<string> Logs = new LockedQueue<string>();
    }
}

