using UnityEditor;

namespace Plugins.SimpleInput.Editor
{
	[CustomPropertyDrawer( typeof( Scripts.SimpleInput.AxisInput ) )]
	public class AxisInputDrawer : BaseInputDrawer
	{
		public override string ValueToString( SerializedProperty valueProperty )
		{
			return valueProperty.floatValue.ToString();
		}
	}
}