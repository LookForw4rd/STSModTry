using Godot;
using MegaCrit.Sts2.Core.Models;
using TestMod1_LookForward.core.Models.Cards;
using TestMod1_LookForward.Core.Models.Cards;

namespace TestMod1_LookForward.Core.Models.CardPools
{
    public sealed class TaffyCardPool : CardPoolModel
    {
        public override string Title => "taffy";
        public override string EnergyColorName => "taffy";
        public override string CardFrameMaterialPath => "card_frame_taffy";
        public override Color DeckEntryCardColor => new Color("#C546EC");
        public override Color EnergyOutlineColor => new Color("#D733A3");
        public override bool IsColorless => false;
        
        protected override CardModel[] GenerateAllCards() {
            return new CardModel[] {
                ModelDb.Card<StrikeTaffy>(),
                ModelDb.Card<MeowPunch>(),
            };
        }
    }
}

