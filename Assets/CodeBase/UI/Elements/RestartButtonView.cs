using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class RestartButtonView : MonoBehaviour
    {
        [SerializeField] private Button restartButton;

        public event UnityAction Play
        {
            add
            {
                Assert.IsNotNull(restartButton, "Play button not defined");
                restartButton.onClick.AddListener(value);
            }
            remove
            {
                Assert.IsNotNull(restartButton, "Play button not defined");
                restartButton.onClick.RemoveListener(value);
            }
        }
    }
}