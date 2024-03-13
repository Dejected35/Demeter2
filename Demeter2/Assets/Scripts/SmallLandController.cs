using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class SmallLandController : MonoBehaviour
    {
        public int LandScore;
        
        public SpriteRenderer landImage;
        public Sprite baseLand;
        public Sprite usedLand;
        public Sprite grownLand;
        public GameObject collectable;
        public bool isEmpty;


        private void OnDisable()
        {
            DOTween.KillAll(true);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!isEmpty)
            {
                return;
            }

            if (collision.TryGetComponent(out Player player))
            {
                player.SmallLand = this;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            /*if (!isEmpty)
            {
                return;
            }*/

            if (collision.TryGetComponent(out Player player))
            {
                if (player.SmallLand == this)
                {
                    player.SmallLand = null;
                }
            }
        }

        public void SetLand()
        {
            EventManager.Instance.TriggerScoreUpdate(LandScore);
            isEmpty = false;
            landImage.sprite = usedLand;

            DOVirtual.DelayedCall(5f, (() =>
            {
                landImage.sprite = grownLand;
                DOVirtual.DelayedCall(5f, (() =>
                {
                    landImage.sprite = baseLand;
                    var obj = Instantiate(collectable,transform);
                    obj.transform.localPosition = Vector3.zero;
                    collectable.GetComponent<Collectable>().SetType();
                    isEmpty = true;
                }));
            }));
        }
    }
}