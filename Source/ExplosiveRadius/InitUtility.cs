using System.Collections.Generic;
using HarmonyLib;
using LudeonTK;
using RimWorld;
using Verse;

namespace CF_ExplosiveRadius;

[StaticConstructorOnStartup]
public static class InitUtility
{
    private static readonly HashSet<ThingDef> patchedExplosives;

    static InitUtility()
    {
        new Harmony("com.colinfang.ExplosiveRadius").PatchAll();
        patchedExplosives = [];
        foreach (var allDef in DefDatabase<ThingDef>.AllDefs)
        {
            if (allDef.specialDisplayRadius != 0f)
            {
                continue;
            }

            var compProperties = allDef.GetCompProperties<CompProperties_Explosive>();
            if (compProperties == null)
            {
                continue;
            }

            allDef.specialDisplayRadius = compProperties.explosiveRadius;
            patchedExplosives.Add(allDef);
        }
    }

    [DebugAction("ExplosiveRadius", actionType = DebugActionType.Action,
        allowedGameStates = AllowedGameStates.PlayingOnMap)]
    public static void LogPatchedExplosives()
    {
        foreach (var patchExplosives in patchedExplosives)
        {
            Log.Message($"PatchedExplosives: {patchExplosives}");
        }
    }
}