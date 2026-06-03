using System.Collections;
using System.Collections.Generic;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Saves.Runs;

namespace TestMod1_LookForward.Core.Models.Relics
{
    public class FanBadge : RelicModel
    {
        public override RelicRarity Rarity => RelicRarity.Starter;

        protected override IEnumerable<DynamicVar> CanonicalVars => [
            new DynamicVar("FanLevel", 1m),
            new DynamicVar("ExpRemaining", 10m)
        ];
        
        public override bool ShowCounter => true;
        
        public override int DisplayAmount => (int)this.DynamicVars["FanLevel"].BaseValue;

        private int _currentExp;

        [SavedProperty]
        public int CurrentExp {
            get => _currentExp;
            set {
                AssertMutable();
                _currentExp = value;
                UpdateExpDynamicVar();
            }
        }
        
        // 获得当前等级下想要提升等级所需的最大exp
        private int GetMaxExpForLevel(int level) {
            return level * 10;
        }

        private void UpdateExpDynamicVar() {
            int currentLevel = (int)this.DynamicVars["FanLevel"].BaseValue;
            int maxExp = GetMaxExpForLevel(currentLevel);
            this.DynamicVars["ExpRemaining"].BaseValue = maxExp - CurrentExp;
        }

        public void AddExp(int amount) {
            CurrentExp += amount;
            
            int currentLevel = (int)this.DynamicVars["FanLevel"].BaseValue; 
            int maxExp = GetMaxExpForLevel(currentLevel);
            bool leveledUp = false;

            while (CurrentExp >= maxExp) {
                CurrentExp -= maxExp;
                currentLevel++;
                leveledUp = true;
                maxExp = GetMaxExpForLevel(currentLevel);
            }

            if (leveledUp) {
                this.DynamicVars["FanLevel"].BaseValue = currentLevel;
                InvokeDisplayAmountChanged(); 
                Flash(); 
            }
            UpdateExpDynamicVar();
        }
    }
}

