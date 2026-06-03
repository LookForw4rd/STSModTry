using System;
using System.Reflection;
using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Localization;
using TestMod1_LookForward.Core.Models.Cards;

namespace TestMod1_LookForward.patches
{
    public static class CustomUnplayableMessageManager
    {
        public static CardModel LastCheckedCard;
    }

    [HarmonyPatch] 
    public static class CardModel_CanPlay_Patch
    {
        public static MethodBase TargetMethod() {
            return typeof(CardModel).GetMethod(
                nameof(CardModel.CanPlay), 
                new Type[] { typeof(UnplayableReason).MakeByRefType(), typeof(AbstractModel).MakeByRefType() }
            );
        }

        [HarmonyPrefix]
        public static void Prefix(CardModel __instance) {
            CustomUnplayableMessageManager.LastCheckedCard = __instance;
        }
    }
    
    [HarmonyPatch] 
    public static class UnplayableReason_GetDialogue_Patch
    {
        public static MethodBase TargetMethod() {
            var type = AccessTools.TypeByName("MegaCrit.Sts2.Core.Entities.Cards.UnplayableReasonExtensions");
            return AccessTools.Method(type, "GetPlayerDialogueLine");
        }

        [HarmonyPostfix]
        public static void Postfix(UnplayableReason reason, ref LocString __result) {
            var card = CustomUnplayableMessageManager.LastCheckedCard;
            if (card is FansLightBoard fansCard)
                if (fansCard.Owner != null && fansCard.Owner.Gold < fansCard.DynamicVars["PayAmount"].IntValue)
                    __result = new LocString("cards", "NOT_ENOUGH_GOLD");

            CustomUnplayableMessageManager.LastCheckedCard = null;
        }
    }
}
