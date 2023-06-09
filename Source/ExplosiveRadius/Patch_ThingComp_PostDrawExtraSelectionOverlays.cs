using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace CF_ExplosiveRadius;

[HarmonyPatch(typeof(ThingComp))]
[HarmonyPatch("PostDrawExtraSelectionOverlays")]
public static class Patch_ThingComp_PostDrawExtraSelectionOverlays
{
    public static void Postfix(ThingComp __instance)
    {
        if (__instance is not CompExplosive compExplosive)
        {
            return;
        }

        var num = compExplosive.ExplosiveRadius();
        if (num > 0.1f)
        {
            GenDraw.DrawRadiusRing(__instance.parent.Position, num, Color.yellow);
        }
    }
}