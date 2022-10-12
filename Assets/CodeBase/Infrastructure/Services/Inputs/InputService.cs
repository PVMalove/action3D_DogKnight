using Plugins.SimpleInput.Scripts;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Inputs
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        private const string ButtonAttack = "Fire";
        private const string ButtonSprint = "Sprint";

        public abstract Vector2 Axis { get; }

        public bool IsAttackButtonDown() =>
            SimpleInput.GetButtonDown(ButtonAttack);

        public bool IsSprintingButton() =>
            SimpleInput.GetButton(ButtonSprint);

        protected static Vector2 SimpleInputAxis() =>
            new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}