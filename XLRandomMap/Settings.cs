using System;
using UnityModManagerNet;

namespace XLRandomMap
{
    [Serializable]
    public class Settings : UnityModManager.ModSettings
    {
        public bool AutoLoadMaps { get; set; } = true;

        public static Settings Instance { get; set; }
        public static UnityModManager.ModEntry ModEntry;

        public Settings() : base()
        {

        }

        public override void Save(UnityModManager.ModEntry modEntry)
        {
            Save(this, modEntry);
        }

        public void Save()
        {
            Save(ModEntry);
        }
    }
}
