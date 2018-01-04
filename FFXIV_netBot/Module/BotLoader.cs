using System;
using System.Windows.Forms;
using System.Collections.Generic;

using FFXIV_netBot.Bot;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Permissions;
using System.Runtime.InteropServices;


namespace FFXIV_netBot.Module
{
    public class BotLoader
    {
        public static CoreBot loadBotModule(String configName, String routeName)
        {
            CoreBot bot = null;

            Module.SaveConfigHolder configHolder = new Module.SaveConfigHolder();
            List<Waypoint> wplist = BotLoader.loadWaypoints(routeName, "wpr");
            byte[] configBytes = BotLoader.loadFile(configName, "cfg");
            if (configBytes.Length > 0 && wplist.Count > 0)
            {
                configHolder.parseBytes(configBytes, true);
            }


            if(configHolder.type != ConfigType.None)
            {
                if(configHolder.type == ConfigType.Fishing)
                {
                    bot = new FishingBot(configHolder.fishingConfig, wplist);
                }
                else if (configHolder.type == ConfigType.Gathering)
                {
                    bot = new GatheringBot(configHolder.gatheringConfig, wplist);
                }else if (configHolder.type == ConfigType.Combat)
                {
                    bot = new CombatBot(configHolder.combatConfig, wplist);
                }
            }
            return bot;
        }

        public static Waypoint waypointFromBytes(byte[] arr)
        {
            Waypoint str = new Waypoint();

            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = (Waypoint)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }

        public static List<Waypoint> loadWaypoints(String fileName, String extension)
        {
            long fileSize = 0;
            List<Waypoint> waypointList = new List<Waypoint>();

            if (fileName != null && fileName.Length > 0)
            {
                try
                {
                    string regexSearch = new string(Path.GetInvalidPathChars());
                    Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
                    String validFileName = r.Replace(fileName, "");

                    String fullPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), validFileName);
                    fullPath = Path.ChangeExtension(fullPath, extension);

                    if (File.Exists(fullPath))
                    {
                        using (FileStream fs = new FileStream(fullPath, FileMode.Open))
                        {
                            using (BinaryReader binReader = new BinaryReader(fs))
                            {
                                int waypointSize = Marshal.SizeOf(new Waypoint());
                                fileSize = binReader.BaseStream.Length;
                                if (fileSize > 0 && fileSize % waypointSize == 0)
                                {
                                    double amount = fileSize / waypointSize;
                                    int amountOfWayPoints = (int)Math.Ceiling(amount);

                                    for (int i = 0; i < amountOfWayPoints; ++i)
                                    {
                                        byte[] bytes = binReader.ReadBytes(waypointSize);
                                        waypointList.Add(BotLoader.waypointFromBytes(bytes));
                                    }
                                }
                                binReader.Close();
                            }
                            fs.Close();
                        }
                    }
                }
                catch
                {
                }
            }
            return waypointList;
        }

        public static byte[] loadFile(String fileName, String extension)
        {
            bool successSave = false;
            bool invalidData = false;
            byte[] bytes = null;

            if (fileName != null && fileName.Length > 0)
            {
                try
                {
                    string regexSearch = new string(Path.GetInvalidPathChars());
                    Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
                    String validFileName = r.Replace(fileName, "");

                    String fullPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), validFileName);
                    fullPath = Path.ChangeExtension(fullPath, extension);

                    if (File.Exists(fullPath))
                    {
                        using (FileStream fs = new FileStream(fullPath, FileMode.Open))
                        {
                            using (BinaryReader binReader = new BinaryReader(fs))
                            {
                                bytes = binReader.ReadBytes((int)binReader.BaseStream.Length);
                                binReader.Close();
                                successSave = true;
                            }
                            fs.Close();
                        }
                    }
                    else
                    {
                        successSave = false;
                    }
                }
                catch
                {
                    successSave = false;
                }
            }

            if (successSave && !invalidData)
            {
                return bytes;
            }
            else
            {
                return new byte[0];
            }
        }
    }
}
