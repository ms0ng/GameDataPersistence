using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 序列化字典，可以被Unity序列化存储。但是必须继承并指定Key和Value的类型。当且仅当TKey和TValue类型确定时，Unity才会序列化该字典.
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TValue"></typeparam>
[Serializable]
public abstract class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField, HideInInspector]
    private List<TKey> keys = new List<TKey>();
    [SerializeField, HideInInspector]
    private List<TValue> values = new List<TValue>();

    public void OnBeforeSerialize()
    {
        this.keys.Clear();
        this.values.Clear();

        foreach (var item in this)
        {
            this.keys.Add(item.Key);
            this.values.Add(item.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        this.Clear();
        for (int i = 0; i < this.keys.Count && i < this.values.Count; i++)
        {
            this[this.keys[i]] = this.values[i];
        }
    }
}

#region 使用示例

#if UNITY_EDITOR

public class ExampleForSerializableDictionary : ScriptableObject
{

    //Unity不会序列化带泛型的类。所以这里要定义一个空类，把带泛型的类包装成不带泛型的类。同时固定死了Key和Value的类型，建议单独用一个Define.cs定义所有需要用到的类型。不要忘了带上[Serializable]。
    [Serializable]
    public class ExampleStringIntMap : SerializableDictionary<string, int> { }




    [Header("Inspector面板")]
    //使用方法1：
    public ExampleStringIntMap publicMap;
    //使用方法2：
    [SerializeField]
    private ExampleStringIntMap privateMap;
    //使用方法3：带上属性
    [SerializeField]
    private ExampleStringIntMap _privateMap;
    public ExampleStringIntMap PropertyMap { get => _privateMap; set { } } //要支持接口，字典必须不能是属性

    //错误的使用方法
    [ShowInInspector]
    public ExampleStringIntMap WrongMap { get; set; }
    /*
     * 属性不支持序列化，必须是成员变量
     * private的变量记得加[SerializeField]
     * 序列化字典和Odin无关，因此没有Odin插件也可以序列化，只是不支持编辑查看字典
     * Odin在这里的唯一作用是可视化操作字典，所以[ShowInInspector]等没有卵用
     */
}
#endif
#endregion