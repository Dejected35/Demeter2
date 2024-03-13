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
            PlayerMovementController.Instance.CanMove = false;
            DOVirtual.DelayedCall(1f, (() =>
            {
                PlayerMovementController.Instance.CanMove = true;
            }));
            
            PlayerAnimator.SetTrigger(HitTrigger);
        }
    }
}