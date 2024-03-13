using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentLandController : MonoBehaviour
{
    public int LandScore;

    public GameObject YourLandText;
    public GameObject ParentLandPanel;
    public bool hasClimed;


    private void Start()
    {
        EventManager.Instance.OnLandSelected += OnLandSelected;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnLandSelected -= OnLandSelected;
    }

    private void OnLandSelected(ParentLandController land)
    {
        ParentLandPanel.SetActive(false);
        hasClimed = true;

        if (land == this)
        {
            YourLandText.SetActive(true);
            EventManager.Instance.TriggerScoreUpdate(LandScore);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasClimed)
        {
            return;
        }

        if (collision.TryGetComponent(out Player player))
        {
            ParentLandPanel.SetActive(true);
            player.ParentLandController = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (hasClimed)
        {
            return;
        }

        if (collision.TryGetComponent(out Player player))
        {
            ParentLandPanel.SetActive(false);
            player.ParentLandController = null;
        }
    }
}