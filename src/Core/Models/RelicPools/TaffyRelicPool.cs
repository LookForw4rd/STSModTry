using System.Collections.Generic;
using Godot;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Relics;
using TestMod1_LookForward.Core.Models.Relics;

namespace TestMod1_LookForward.core.Models.RelicPools
{
    public partial class TaffyRelicPool : RelicPoolModel
    {
        public override string EnergyColorName => "taffy";
    
        public override Color LabOutlineColor => new Color("#D733A3");

        protected override List<RelicModel> GenerateAllRelics() {
            return [
                ModelDb.Relic<FanBadge>()
            ];
        }
    }
}

