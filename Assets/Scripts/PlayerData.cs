using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]//!!不要忘记添加Serializable
public class PlayerData : IPersistenceData
{
    public const string SAVE_KEY = "PlayerData"; //必须指定一个Key用于指代存档文件名
    [SerializeField, HideInInspector] //private的成员不能被序列化
    private int number;
    public string firstSaveTime;
    public string lastSaveTime;
    public DateTime _firstSaveTime;//这一行是无效的，DateTime不能被序列化，必须转换为基本数据类型。
    public Dictionary<int, string> _dic;//这一行是无效的，字典也不能被序列化

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
