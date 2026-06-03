using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models;
using TestMod1_LookForward.Core.Models.CardPools;
using TestMod1_LookForward.core.Models.Cards;
using TestMod1_LookForward.Core.Models.Cards;
using TestMod1_LookForward.Core.Models.Characters;
using TestMod1_LookForward.core.Models.PotionPools;
using TestMod1_LookForward.core.Models.RelicPools;

namespace TestMod1_LookForward.patches
{
    [HarmonyPatch(typeof(ModelDb), nameof(ModelDb.AllCardPools), MethodType.Getter)]
    public static class ModelDbAllCardPoolsPatch
    {
        static void Postfix(ref IEnumerable<CardPoolModel> __result) {
            __result = __result
                .Append(ModelDb.CardPool<TaffyCardPool>())
                .Distinct();
        }
    }
    
    [HarmonyPatch(typeof(ModelDb), nameof(ModelDb.AllCards), MethodType.Getter)]
    public static class ModelDbAllCardsPatch {
        static void Postfix(ref IEnumerable<CardModel> __result) {
            __result = __result
                .Append(ModelDb.Card<StrikeTaffy>())
                .Append(ModelDb.Card<MeowPunch>())
                .Distinct();
        }
    }

    [HarmonyPatch(typeof(ModelDb), nameof(ModelDb.AllRelicPools), MethodType.Getter)]
    public static class ModelDbAllRelicPoolsPatch
    {
        static void Postfix(ref IEnumerable<RelicPoolModel> __result) {
            __result = __result
                .Append(ModelDb.RelicPool<TaffyRelicPool>())
                .Distinct();
        }
    }
    
    [HarmonyPatch(typeof(ModelDb), nameof(ModelDb.AllPotionPools), MethodType.Getter)]
    public static class ModelDbAllPotionPoolsPatch
    {
        static void Postfix(ref IEnumerable<PotionPoolModel> __result) {
            __result = __result
                .Append(ModelDb.PotionPool<TaffyPotionPool>())
                .Distinct();
        }
    }
    
    [HarmonyPatch(typeof(ModelDb), nameof(ModelDb.AllCharacters), MethodType.Getter)]
    public static class ModelDbAllCharactersPatch
    {
        static void Postfix(ref IEnumerable<CharacterModel> __result) {
            __result = __result
                .Append(ModelDb.Character<Taffy>())
                .Distinct();
        }
    }
}
