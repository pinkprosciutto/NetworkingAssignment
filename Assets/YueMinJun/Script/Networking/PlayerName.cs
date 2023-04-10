using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerName : MonoBehaviour
{

    [SerializeField] private TMP_InputField nameInput = null;
    [SerializeField] private Button continueButton = null;

    public static string DisplayName { get; private set; }
    private const string PlayerPrefName = "PlayerName";

    void Start()
    {
        SetupInputField();
    }

    private void Update()
    {
        SetPlayerName("Bob");
    }
    public void SetupInputField()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefName)) return;

        string defaultName = PlayerPrefs.GetString(PlayerPrefName);
        nameInput.text = defaultName;
        SetPlayerName(defaultName);
    }

    public void SetPlayerName(string name)
    {
        Debug.Log(name);
        continueButton.interactable = !string.IsNullOrEmpty(name); //enables if the name is not empty 
    }

    public void SavePlayerName()
    {
        DisplayName = nameInput.text;
        PlayerPrefs.SetString(PlayerPrefName, DisplayName);
    }
}
