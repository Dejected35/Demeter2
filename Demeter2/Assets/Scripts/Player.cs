using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public int numCarrotSeed;
    public int numWheatSeed;
    public int numCornSeed;
    
    public ParentLandController ParentLandController;
    internal int numAtatohumu;
    internal int numGDOtohumu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance != null)
        {
            Destroy(gameObject);
        }
    }
    


    public void SetLand()
    {
        if (ParentLandController != null)
        {
            EventManager.Instance.TriggerLandSelected(ParentLandController);
        }
    }
}