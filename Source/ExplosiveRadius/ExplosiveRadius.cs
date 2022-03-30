#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;
using HarmonyLib;
using UnityEngine;
using System.Reflection;

namespace CF_ExplosiveRadius
{
    public class Patcher : Mod
    {
        public static Settings Settings = new();

        public Patcher(ModContentPack pack) : base(pack)
        {
            Settings = GetSettings<Settings>();
            DoPatching();
        }
        public override string SettingsCategory()
        {
            return "Explosive Radius";
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            var list = new Listing_Standard();
            list.Begin(inRect);
            // list.CheckboxLabeled("Draw explosive radius", ref Settings.DrawExplosiveRadius);
            list.End();
            base.DoSettingsWindowContents(inRect);
        }

        public override void WriteSettings() {
            base.WriteSettings();
        }

        public void DoPatching()
        {
            var harmony = new Harmony("com.colinfang.ExplosiveRadius");
            harmony.PatchAll();
        }
    }

    public class Settings : ModSettings
    {
        // public bool DrawExplosiveRadius = true;
        public override void ExposeData()
        {
            // Scribe_Values.Look(ref DrawExplosiveRadius, nameof(DrawExplosiveRadius), true);
            base.ExposeData();
        }
    }


    [StaticConstructorOnStartup]
    public static class InitUtility
    {
        public static readonly HashSet<ThingDef> PatchedExplosives = new();

        static InitUtility()
        {
            foreach (var t in DefDatabase<ThingDef>.AllDefs)
            {
                if (t.specialDisplayRadius == 0 && t.GetCompProperties<CompProperties_Explosive>() is { } comp)
                {
                    t.specialDisplayRadius = comp.explosiveRadius;
                    PatchedExplosives.Add(t);
                }

            }
        }


        [DebugAction("ExplosiveRadius", null, false, false, actionType = DebugActionType.Action, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        public static void LogPatchedExplosives()
        {
            foreach (var t in PatchedExplosives)
            {
                Log.Message($"PatchedExplosives: {t}");
            }
        }

    }

    [HarmonyPatch(typeof(ThingComp))]
    [HarmonyPatch(nameof(ThingComp.PostDrawExtraSelectionOverlays))]
    public static class Patch_ThingComp_PostDrawExtraSelectionOverlays
    {
        public static void Postfix(ThingComp __instance)
        {
            // For an actual thing, draw a better overlay which considers `stackCount`
            // It is drawn over the existing `specialDisplayRadius`
            // See `Thing.DrawExtraSelectionOverlays`
            if (__instance is CompExplosive comp)
            {
                var radius = comp.ExplosiveRadius();
                if (radius > 0.1f)
                {
                    GenDraw.DrawRadiusRing(__instance.parent.Position, radius, Color.yellow);
                }

            }
        }
    }



}