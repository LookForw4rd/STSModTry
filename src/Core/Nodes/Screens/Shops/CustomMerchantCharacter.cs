using MegaCrit.Sts2.Core.Nodes.Screens.Shops; // 引入原版商人角色的命名空间

namespace TestMod1_LookForward.Core.Nodes.Screens.Shops
{
    public partial class CustomMerchantCharacter : NMerchantCharacter
    {
        public new void PlayAnimation(string anim, bool loop = false) {
            return; 
        }
    }
}
