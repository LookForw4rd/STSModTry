using System.Collections;
using System.Collections.Generic;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;

namespace TestMod1_LookForward.Core.Models.Relics
{
    public class FanBadge : RelicModel
    {
        public override RelicRarity Rarity => RelicRarity.Starter;

        protected override IEnumerable<DynamicVar> CanonicalVars => [
            new DynamicVar("FanLevel", 1)
        ];
        
        public override bool ShowCounter => true;
        
        public override int DisplayAmount => (int)this.DynamicVars["FanLevel"].BaseValue;

        public void AddFanLevel(int amount = 1) {
            this.DynamicVars["FanLevel"].BaseValue += amount;
            InvokeDisplayAmountChanged();
            Flash();
        }
    }
}

