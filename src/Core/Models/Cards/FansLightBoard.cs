using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using TestMod1_LookForward.Core.HoverTips;
using TestMod1_LookForward.Core.Models.Relics;

namespace TestMod1_LookForward.Core.Models.Cards
{
    public sealed class FansLightBoard : CardModel
    {
        protected override IEnumerable<DynamicVar> CanonicalVars => [
            new IntVar("PayAmount", 5m)
        ];

        protected override IEnumerable<IHoverTip> ExtraHoverTips => [
            ModHoverTips.PayMoney,
        ];
        
        public FansLightBoard() : base(0, CardType.Skill, CardRarity.Basic, TargetType.Self) {}

        protected override bool IsPlayable => base.Owner.Gold >= base.DynamicVars["PayAmount"].IntValue;

        // 在拥有足够金币打出本牌时，设置让卡面周围发出金光
        protected override bool ShouldGlowGoldInternal => IsPlayable; 

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
        {
            int payAmount = base.DynamicVars["PayAmount"].IntValue;
            base.Owner.Gold -= payAmount; 

            var fanRelic = base.Owner.Relics.FirstOrDefault(r => r.Id == ModelDb.Relic<FanBadge>().Id) as FanBadge;
            if (fanRelic != null) 
                fanRelic.AddExp(payAmount);

            await Cmd.Wait(0.2f);
        }

        protected override void OnUpgrade() {
            base.DynamicVars["PayAmount"].UpgradeValueBy(5m);
        }
    }
}