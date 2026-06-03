using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using TestMod1_LookForward.Core.HoverTips;
using TestMod1_LookForward.Core.Models.Relics; 

namespace TestMod1_LookForward.Core.Models.Cards
{
    public sealed class MeowPunch : CardModel 
    {
        public override IEnumerable<CardKeyword> CanonicalKeywords => new[] { CardKeyword.Exhaust };
        
        protected override IEnumerable<DynamicVar> CanonicalVars => [
            new DamageVar(0m, ValueProp.Move)
        ];

        protected override IEnumerable<IHoverTip> ExtraHoverTips => new[] { ModHoverTips.FanLevel };
        
        public MeowPunch() : base(0, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy) {}
        
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay) {
            int currentLevel = 0;
            var fanRelic = base.Owner.Relics.FirstOrDefault(r => r.Id == ModelDb.Relic<FanBadge>().Id);

            if (fanRelic != null && fanRelic.DynamicVars.TryGetValue("FanLevel", out var fanVar)) {
                currentLevel = (int)fanVar.BaseValue;
            }

            await DamageCmd.Attack(currentLevel)
                .FromCard(this)
                .Targeting(cardPlay.Target)
                .WithHitFx("vfx/vfx_attack_blunt_light") 
                .Execute(choiceContext);
        }

        protected override void OnUpgrade() {
            this.RemoveKeyword(CardKeyword.Exhaust);
        }
        
        protected override void AddExtraArgsToDescription(LocString description) {
            base.AddExtraArgsToDescription(description);

            var fanRelic = this.Owner.Relics.FirstOrDefault(r => r.Id == ModelDb.Relic<FanBadge>().Id);
            if (fanRelic != null && fanRelic.DynamicVars.TryGetValue("FanLevel", out var fanVar)) {
                this.DynamicVars.Damage.BaseValue = fanVar.BaseValue;
            }
        }
    }
}