using System.Reflection;
using Godot;
using MegaCrit.Sts2.Core.Nodes.Vfx.Utilities;

namespace TestMod1_LookForward.Core.Nodes.Vfx.Utilities
{
	public partial class CustomParticlesContainer : NParticlesContainer
	{
		public override void _Ready() {
			base._Ready();
			
			var emptyArray = new Godot.Collections.Array<GpuParticles2D>();
			FieldInfo fieldInfo = typeof(NParticlesContainer).GetField("_particles", BindingFlags.NonPublic | BindingFlags.Instance);
		
			if (fieldInfo != null) {
				fieldInfo.SetValue(this, emptyArray);
			}
		}
	}
}
