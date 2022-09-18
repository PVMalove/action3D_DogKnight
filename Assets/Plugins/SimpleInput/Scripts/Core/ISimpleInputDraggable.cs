using UnityEngine.EventSystems;

namespace Plugins.SimpleInput.Scripts.Core
{
	public interface ISimpleInputDraggable
	{
		void OnPointerDown( PointerEventData eventData );
		void OnDrag( PointerEventData eventData );
		void OnPointerUp( PointerEventData eventData );
	}
}