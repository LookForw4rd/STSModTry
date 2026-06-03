using System.Collections.Generic;
using Godot;
using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Characters;
using MegaCrit.Sts2.Core.Models.Relics;
using TestMod1_LookForward.Core.Models.CardPools;
using TestMod1_LookForward.core.Models.Cards;
using TestMod1_LookForward.Core.Models.Cards;
using TestMod1_LookForward.core.Models.PotionPools;
using TestMod1_LookForward.core.Models.RelicPools;
using TestMod1_LookForward.Core.Models.Relics;

namespace TestMod1_LookForward.Core.Models.Characters
{
    public sealed class Taffy : CharacterModel
    {
        public const string energyColorName = "taffy"; 

        public override CharacterGender Gender => CharacterGender.Feminine; 

        protected override CharacterModel? UnlocksAfterRunAs => null;

        public override Color NameColor => new Color("#D733A3"); 

        public override int StartingHp => 72; 

        public override int StartingGold => 100; 

        public override CardPoolModel CardPool => ModelDb.CardPool<TaffyCardPool>();

        public override PotionPoolModel PotionPool => ModelDb.PotionPool<TaffyPotionPool>();

        public override RelicPoolModel RelicPool => ModelDb.RelicPool<TaffyRelicPool>();

        public override List<CardModel> StartingDeck => [
            ModelDb.Card<StrikeTaffy>(),
            ModelDb.Card<StrikeTaffy>(),
            ModelDb.Card<StrikeTaffy>(),
            ModelDb.Card<StrikeTaffy>(),
            ModelDb.Card<StrikeTaffy>(),
            ModelDb.Card<MeowPunch>(),
        ]; 

        public override List<RelicModel> StartingRelics => [
            ModelDb.Relic<FanBadge>()
        ];

        public override float AttackAnimDelay => 0.15f;

        public override float CastAnimDelay => 0.25f;

        public override Color EnergyLabelOutlineColor => Colors.Pink;

        public override Color DialogueColor => Colors.Pink;

        public override Color MapDrawingColor => Colors.Pink;

        public override Color RemoteTargetingLineColor => Colors.Pink;

        public override Color RemoteTargetingLineOutline => Colors.Pink;
    
        public override string CharacterSelectSfx => ModelDb.Character<Ironclad>().CharacterSelectSfx;

        public override string CharacterTransitionSfx => "event:/sfx/ui/wipe_ironclad";

        public override List<string> GetArchitectAttackVfx() {
            return new List<string>();
        }
    }
}

