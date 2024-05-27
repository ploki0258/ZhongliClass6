using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ScriptableObject 自訂物件

[CreateAssetMenu(fileName = "新的文本", menuName = "Jack/建立新文本")]
public class SayStuff : ScriptableObject
{
    // 表單
    [SerializeField] [Header("填寫行數")]
    public List<SayData> list;
    public List<string> opctionList;
}

/// <summary>
/// 對話資料
/// </summary>
[System.Serializable]
public struct SayData
{
    /// <summary>
    /// 對話內容
    /// </summary>
    public string info;

    /// <summary>
    /// 對話人名
    /// </summary>
    public string title;
}