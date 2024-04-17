using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        public static PlayerAnimatorController Instance;


        public Animator PlayerAnimator;
        private static readonly int HitTrigger = Animator.StringToHash("HitTrigger");

        private Tween _hitTween;

        private void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != null)
            {
                Destroy(gameObject);
            }
        }


        [Button]
        public void Hit()
        {
            PlayerAnimator.SetTrigger(HitTrigger);
        }


        public void Stop()
        {
            PlayerMovementController.Instance.Rb.velocity = Vector2.zero;
            PlayerMovementController.Instance.CanMove = false;
        }

        public void Move()
        {
            PlayerMovementController.Instance.Rb.velocity = Vector2.zero;
            PlayerMovementController.Instance.CanMove = true;
        }
    }
}