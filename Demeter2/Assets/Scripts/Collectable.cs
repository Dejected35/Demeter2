using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [OnValueChanged(nameof(SetType))]
    public CollectableType Type;
    
    public List<Sprite> Sprites;
    public SpriteRenderer SpriteRenderer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PlayerInteracted(player);
        }
    }

    public void SetType()
    {
        switch (Type)
        {
            case CollectableType.Wheat:
                SpriteRenderer.sprite = Sprites[0];
                break;
            case CollectableType.Atatohumu:
                SpriteRenderer.sprite = Sprites[1];
                break;
            case CollectableType.GDOtohumu:
                SpriteRenderer.sprite = Sprites[2];
                break;
            case CollectableType.HayvansalG:
                SpriteRenderer.sprite = Sprites[3];
                break;
            case CollectableType.KimyasalG:
                SpriteRenderer.sprite = Sprites[4];
                break;
        }
    }
    
    private void PlayerInteracted(Player player)
    {
        switch (Type)
        {
            case CollectableType.Wheat:
                player.numWheatSeed++;
                break;
            case CollectableType.Carrot:
                player.numCarrotSeed++;
                break;
            case CollectableType.Corn:
                player.numCornSeed++;
                break;
            case CollectableType.Atatohumu:
                player.numAtatohumu++;
                break;
            case CollectableType.GDOtohumu:
                player.numGDOtohumu++;
                break;
            case CollectableType.HayvansalG:
                player.numGDOtohumu++;
                break;
            case CollectableType.KimyasalG:
                player.numGDOtohumu++;
                break;
        }

        Destroy(gameObject);
    }
}


public enum CollectableType
{
    Wheat,
    Carrot,
    Corn,
    Atatohumu,
    GDOtohumu,
    HayvansalG,
    KimyasalG
}
