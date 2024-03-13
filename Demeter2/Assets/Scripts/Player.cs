using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public int numCarrotSeed;
    public int numWheatSeed;
    public int numCornSeed;
    public int numAtatohumu;
    public int numGDOtohumu;

    public ParentLandController ParentLandController;
    public SmallLandController SmallLand;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
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