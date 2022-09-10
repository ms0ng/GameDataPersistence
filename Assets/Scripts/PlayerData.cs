using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]//!!��Ҫ�������Serializable
public class PlayerData : IPersistenceData
{
    public const string SAVE_KEY = "PlayerData"; //����ָ��һ��Key����ָ���浵�ļ���
    [SerializeField, HideInInspector] //private�ĳ�Ա���ܱ����л�
    private int number;
    public string firstSaveTime;
    public string lastSaveTime;
    public DateTime _firstSaveTime;//��һ������Ч�ģ�DateTime���ܱ����л�������ת��Ϊ�����������͡�
    public Dictionary<int, string> _dic;//��һ������Ч�ģ��ֵ�Ҳ���ܱ����л�

    public int Number { get => number; set => SetNumber(value); }
    public Action<int> OnNumberChanged;


    public PlayerData()
    {
        number = 0;
        firstSaveTime = DateTime.UtcNow.ToString();
        lastSaveTime = DateTime.UtcNow.ToString();
    }

    public string GetSaveKey()
    {
        return SAVE_KEY;
    }
    public void SetNumber(int num)
    {
        number = num;
        OnNumberChanged.Invoke(num);
    }
}
