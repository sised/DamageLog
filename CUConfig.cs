using Terraria;
using Terraria.ModLoader.Config;
using Newtonsoft.Json;
using System.ComponentModel;

namespace DamageLog
{
    public class CUConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        [DefaultValue(false)]
        [Label("Log start/stop recording in chat (see config)")]
        public bool RecordLog;
        [DefaultValue(false)]
        [Label("Log enemy hits in chat")]
        public bool DamageLog;
        [DefaultValue(false)]
        [Label("Clear projectiles & hostile NPCs on death")]
        public bool ClearEverythingOnDeath;
    }
}
