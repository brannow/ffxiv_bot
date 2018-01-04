using System;

using FFXIV_netBot.Module;

namespace FFXIV_netBot
{
    public class SettingsSingleton
    {
        private static SettingsSingleton instance;

        public Timings timings;

        private SettingsSingleton() { }

        public static SettingsSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SettingsSingleton();
                }
                return instance;
            }
        }
    }
}
