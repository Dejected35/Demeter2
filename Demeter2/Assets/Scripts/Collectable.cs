using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collactable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent(out Player player))
        {
            player.numCarrotSeed++;
            Destroy(this.gameObject);
        }
    }
}
