using UnityEditor;

namespace Plugins.SimpleInput.Editor
{
	[CustomPropertyDrawer( typeof( Scripts.SimpleInput.KeyInput ) )]
	public class KeyInputDrawer : BaseInputDrawer
	{
		public override string ValueToString( SerializedProperty valueProperty )
		{
			return valueProperty.boolValue.ToString();
		}
	}
}