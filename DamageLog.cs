using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using System.Linq;

namespace DamageLog
{
	public class DamageLog : Mod
	{
		public static ModHotKey Recording;
		
        public override void Load()
        {
            Recording = RegisterHotKey("Record Button", "Subtract");
        }
        public override void Unload()
        {
            Recording = null;
        }
    }
    public class MNPC : GlobalNPC
    {
        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            if (Main.player.Count(p => p.active && !p.dead) == 0 && ModContent.GetInstance<CUConfig>().ClearEverythingOnDeath && npc.CanBeChasedBy())
            {
                npc.active = false;
            }
        }
    }
    public class MProj : GlobalNPC
    {
        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            if (Main.player.Count(p => p.active && !p.dead) == 0 && ModContent.GetInstance<CUConfig>().ClearEverythingOnDeath)
            {
                npc.active = false;
            }
        }
    }
}