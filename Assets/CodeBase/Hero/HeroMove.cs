using CodeBase.Infrastructure.Services;
using CodeBase.Services.Inputs;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(CharacterController))]
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 2.5f;
        [SerializeField] private CharacterController _characterController;

        private IInputService _input;
        private HeroAnimator _heroAnimator;

        private void Awake()
        {
            _input = AllServices.Container.Single<IInputService>();
            
            _characterController = GetComponent<CharacterController>();
            _heroAnimator = GetComponent<HeroAnimator>();
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_input.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = Camera.main.transform.TransformDirection(_input.Axis);
                movementVector.y = 0f;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;

            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
        }
    }
}