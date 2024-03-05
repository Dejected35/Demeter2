using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    
    public int Score;

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



    public event Action<ParentLandController> OnLandSelected;

    public void TriggerLandSelected(ParentLandController land)
    {
        OnLandSelected?.Invoke(land);
    }
    
    
    public event Action<int> OnScoreUpdate;

    [Button]
    public void TriggerScoreUpdate(int value)
    {
        Score += value;
        OnScoreUpdate?.Invoke(Score);
    }

}
