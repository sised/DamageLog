﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.GameInput;

namespace DamageLog.Properties
{
    public class Mplayer : ModPlayer
    {
        bool Recording = false;
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (DamageLog.Recording.JustPressed && ModContent.GetInstance<CUConfig>().RecordLog)
            {
                Recording = !Recording;
                if(Recording)
                {
                    Main.NewText("[RECORDING]", 255, 0, 0);
                }
                else Main.NewText("[STOPPED RECORDING]", 100, 0, 0);
            }
        }
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if(ModContent.GetInstance<CUConfig>().DamageLog)
                Main.NewText(player.name + " got hit by " + npc.FullName + ", " + damage.ToString() + " Damage!", Color.IndianRed);
            
        }
        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            if (ModContent.GetInstance<CUConfig>().DamageLog)
                Main.NewText(player.name + " got hit by " + proj.Name + ", " + damage.ToString() + " Damage!", Color.IndianRed);
        }
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if(damageSource.SourceOtherIndex == 0 && ModContent.GetInstance<CUConfig>().DamageLog)
            {
                Main.NewText(player.name + " fell, " + damage.ToString() + " Damage!", Color.IndianRed);
            }
            if (damageSource.SourceOtherIndex == 2 && ModContent.GetInstance<CUConfig>().DamageLog)
            {
                Main.NewText(player.name + " got burned in lava, " + damage.ToString() + " Damage!", Color.IndianRed);
            }
            return true;
        }
        public override void OnHitPvp(Item item, Player target, int damage, bool crit)
        {
            if (ModContent.GetInstance<CUConfig>().DamageLog)
                Main.NewText(target.name + " got hit by " + player.name + ", " + damage.ToString() + " Damage!", Color.IndianRed);
        }
    }
}
