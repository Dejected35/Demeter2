using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetupPanel : MonoBehaviour
{
    public Button StartIdButton;
    public Button StartGame;

    public GameObject StartPanelObj;
    public GameObject IdPanelObj;
    public GameObject ScorePanel;

    public PlayerData PlayerData;

    public TMP_InputField NameField;
    public TMP_InputField SurnameField;
    public TMP_InputField IdField;
    public TMP_InputField AdressField;


    protected void Awake()
    {
        GetComponent<Image>().enabled = true;
        ResetData();

        IdPanelObj.SetActive(false);
        StartPanelObj.SetActive(true);


        StartIdButton.onClick.AddListener(OnStartId);
        StartGame.onClick.AddListener(OnStartGame);
    }

    private void ResetData()
    {
        PlayerData.Name = "Şinasi";
        PlayerData.Surname = "Beyazsakal";
        PlayerData.Id = "123456";
        PlayerData.Adress = "Örnekköy Mah.";


        NameField.text = PlayerData.Name;
        SurnameField.text = PlayerData.Surname;
        IdField.text = PlayerData.Id;
        AdressField.text = PlayerData.Adress;
    }

    private void OnStartGame()
    {
        if (NameField.text != null)
        {
            PlayerData.Name = NameField.text;
        }

        if (SurnameField.text != null)
        {
            PlayerData.Surname = SurnameField.text;
        }

        if (IdField.text != null)
        {
            PlayerData.Id = IdField.text;
        }

        if (AdressField.text != null)
        {
            PlayerData.Adress = AdressField.text;
        }


        PlayerMovementController.Instance.CanMove = true;
        gameObject.SetActive(false);
        ScorePanel.SetActive(true);
    }

    private void OnStartId()
    {
        IdPanelObj.SetActive(true);
        StartPanelObj.SetActive(false);
    }
}