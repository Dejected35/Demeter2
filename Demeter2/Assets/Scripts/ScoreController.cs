using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class ScoreController : MonoBehaviour
    {

        public TextMeshProUGUI ScoreText;
        
        private void Start()
        {
            EventManager.Instance.OnScoreUpdate += OnScoreUpdated;
        }

        private void OnDestroy()
        {
            EventManager.Instance.OnScoreUpdate -= OnScoreUpdated;
        }


        private void OnScoreUpdated(int score)
        {
            ScoreText.text = "Score: " + score;
        }
        
    }
}