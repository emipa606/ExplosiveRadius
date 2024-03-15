using System.Collections.Generic;
using HarmonyLib;
using LudeonTK;
using RimWorld;
using Verse;

namespace CF_ExplosiveRadius;

[StaticConstructorOnStartup]
public static class InitUtility
{
    public static readonly HashSet<ThingDef> PatchedExplosives;

    static InitUtility()
    {
        new Harmony("com.colinfang.ExplosiveRadius").PatchAll();
        PatchedExplosives = [];
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
            PatchedExplosives.Add(allDef);
        }
    }

    [DebugAction("ExplosiveRadius", actionType = DebugActionType.Action,
        allowedGameStates = AllowedGameStates.PlayingOnMap)]
    public static void LogPatchedExplosives()
    {
        foreach (var patchExplosives in PatchedExplosives)
        {
            Log.Message($"PatchedExplosives: {patchExplosives}");
        }
    }
}