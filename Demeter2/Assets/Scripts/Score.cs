using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public bool tarlakontrol;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (tarlakontrol != true)
            {
                tarlakontrol = true;
                Debug.Log(tarlakontrol);
            }
        }
    }
}
