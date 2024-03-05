using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int numCarrotSeed;
    public int numWheatSeed;
    public int numCornSeed;
    
    public ParentLandController ParentLandController;


    private void Start()
    {
        Debug.Log(EventManager.Instance);
    }


    public void SetLand()
    {
        if (ParentLandController != null)
        {
            EventManager.Instance.TriggerLandSelected(ParentLandController);
        }
    }
}