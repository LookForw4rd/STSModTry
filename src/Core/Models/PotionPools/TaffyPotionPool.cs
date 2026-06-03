using System.Collections.Generic;
using Godot;
using MegaCrit.Sts2.Core.Models;

namespace TestMod1_LookForward.core.Models.PotionPools
{
    public partial class TaffyPotionPool : PotionPoolModel
    {
        public override string EnergyColorName => "taffy";
    
        public override Color LabOutlineColor => new Color("#D733A3");
    
        protected override List<PotionModel> GenerateAllPotions() {
            return [
            ];
        }
    }
}

