using System;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Inputs;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(HeroAnimator), typeof(CharacterController))]
    public class HeroAttack : MonoBehaviour
    {
        [SerializeField] private HeroAnimator _animator;
        [SerializeField] private CharacterController _characterController;

        private IInputService _input;
        private static int _layerMask;

        private void Awake()
        {
            _input = AllServices.Container.Single<IInputService>();

            _layerMask = 1 << LayerMask.NameToLayer("Hittable");
        }

        private Vector3 StartPoint() =>
            new Vector3(transform.position.x, _characterController.center.y / 2, transform.position.z);
    }
}