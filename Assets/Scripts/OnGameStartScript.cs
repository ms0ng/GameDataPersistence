using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnGameStartScript : MonoBehaviour
{
    public Button btnAdd;
    public Button btnMin;
    public Button btnRdm;
    public TextMeshProUGUI numText;

    private PlayerData playerData;


    void Awake()
    {
        playerData = GameDataPersistenceManager.Instance.LoadData<PlayerData>(PlayerData.SAVE_KEY);
        if (playerData == null) playerData = new PlayerData();
        Debug.Log("Last Save Number: " + playerData.Number);
        Debug.Log("First Save Time(UTC): " + playerData.firstSaveTime);
        Debug.Log("Last Save Time(UTC): " + playerData.lastSaveTime);
    }

    void Start()
    {
        btnAdd.onClick.AddListener(OnAdd);
        btnMin.onClick.AddListener(OnMin);
        btnRdm.onClick.AddListener(OnRdm);
        btnAdd.onClick.AddListener(SaveAfterEdit);
        btnMin.onClick.AddListener(SaveAfterEdit);
        btnRdm.onClick.AddListener(SaveAfterEdit);

        numText.text = playerData.Number.ToString();
        playerData.OnNumberChanged += OnNumChanged;
    }

    void OnAdd()
    {
        playerData.Number++;
    }
    void OnMin()
    {
        playerData.Number--;
    }

    void OnRdm()
    {
        playerData.Number += UnityEngine.Random.Range(-999, 999);
    }

    void SaveAfterEdit()
    {
        playerData.lastSaveTime = DateTime.UtcNow.ToString();
        GameDataPersistenceManager.Instance.SaveData(playerData);
        Debug.Log("Last Save Time: " + playerData.lastSaveTime);
    }

    void OnNumChanged(int num)
    {
        numText.text = num.ToString();
    }
}
