using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaySystemManager : SampleSingleton<SaySystemManager>
{
    public TextAsset mainData = null;
    public List<LanguageData> languageDataList = new List<LanguageData>();
    public LogType logType = LogType.disabled;
    public enum LogType
    {
        disabled = 0,
        enabled = 1,
    }

    public override void OnLoad()
    {
        base.OnLoad();

        mainData = Resources.Load<TextAsset>("SaySystemData/MainData");
        if (logType == LogType.enabled)
            Debug.Log("�ѪR��ܸ��");
        // Ū��Ķ�����}�C
        languageDataList = new List<LanguageData>();
        LanguageData temp = new LanguageData();
        temp.data = new List<string>();
        bool haveData = false;
        string[] ogdata = mainData.text.Split('\n');
        if (logType == LogType.enabled)
            Debug.Log("��ƪ��� : " + ogdata.Length);
        for (int i = 0; i < ogdata.Length; i++)
        {
            // �p�G�o�{�o�O�@�Ӽ��ҴN�ˬd�O�_�n�s�W�y��
            string ogdataTrim = ogdata[i].Trim();
            if (ogdataTrim[0] == '<' && ogdataTrim[ogdataTrim.Length - 1] == '>')
            {
                for (int j = 0; j < 28; j++)
                {
                    string languageName = ((LanguageISO639_1)j).ToString();
                    // �o��n�h���e�᪺< >
                    string ogdataTrimInfo = ogdataTrim.Substring(1, ogdataTrim.Length - 2);
                    // �o�{�y��
                    if (languageName.Trim() == ogdataTrimInfo.Trim())
                    {
                        // ����ƪ��ܥ��O��
                        if (haveData)
                        {
                            // �[�J��C��
                            if (logType == LogType.enabled)
                                Debug.Log("��X�X : " + temp.language.ToString());
                            languageDataList.Add(temp);
                            temp = new LanguageData();
                            temp.data = new List<string>();
                        }
                        temp.language = (LanguageISO639_1)j;
                        temp.data.Add("---------�����---------");
                        haveData = true;
                    }
                }
            }
            if (haveData)
            {
                if (logType == LogType.enabled)
                    Debug.Log(ogdata[i]);
                temp.data.Add(ogdata[i]);
            }
        }
        if (haveData)
        {
            if (logType == LogType.enabled)
                Debug.Log("��X�X : " + temp.language.ToString());
            languageDataList.Add(temp);
        }
        if (logType == LogType.enabled)
            Debug.Log("�ѪR����");

        // �ˬd�C��languageDataList����Ƽƶq�O�_�@�P
        int count = languageDataList[0].data.Count;
        for (int i = 0; i < languageDataList.Count; i++)
        {
            if (count != languageDataList[i].data.Count)
            {
                Debug.LogError("�y�� : " + languageDataList[i].language.ToString() + " ��Ƽƶq : " + languageDataList[i].data.Count + " �P��L�y�����@�P�A�нT�{�O�_���ʺ|½Ķ�C");
            }
        }
    }

    /// <summary>���o���</summary>
    public string GetText(LanguageISO639_1 language, string indexName)
    {
        // �NindexName�ഫ���Ʀr
        int index = 0;
        if (int.TryParse(indexName.Trim(), out index))
        {
            return GetText(language, index);
        }
        else
        {
            return "Error �е���ơA�Ѧ�MainData���C";
        }
    }
    /// <summary>���o���</summary>
    public string GetText(LanguageISO639_1 language, int index)
    {
        if (languageDataList.Count == 0)
            return "";
        for(int i = 0; i < languageDataList.Count; i++)
        {
            if (languageDataList[i].language == language)
            {
                if (languageDataList[i].data.Count <= index)
                    return "";
                return languageDataList[i].data[index].Trim();
            }
        }
        return "";
    }
}
[System.Serializable]
public struct LanguageData
{
    public LanguageISO639_1 language;
    public List<string> data;
}
public enum LanguageCN : int
{
    �c�餤�� = 0,
    ²�餤�� = 1,
    ���J�� = 2,
    ������ = 3,
    ������ = 4,
    �^�� = 5,
    ������ = 6,
    �k�� = 7,
    �w�� = 8,
    �I���Q�� = 9,
    �q�j�Q�� = 10,
    ��� = 11,
    ���� = 12,
    ���¤� = 13,
    �i���� = 14,
    �������_����� = 15,
    �������_�ڦ� = 16,
    ù�����Ȥ� = 17,
    �X�� = 18,
    ��Z����_��Z�� = 19,
    ���� = 20,
    ���� = 21,
    �g�ը�� = 22,
    �O�[�Q�Ȥ� = 23,
    �Q�J���� = 24,
    ��þ�� = 25,
    ��Z����_�ԤB���w = 26,
    �V�n�� = 27,
}
public enum LanguageISO639_1 : int
{
    zh_TW = 0,
    zh_CN = 1,
    cs = 2,
    da = 3,
    nl = 4,
    en = 5,
    fi = 6,
    fr = 7,
    de = 8,
    hu = 9,
    it = 10,
    ja = 11,
    ko = 12,
    nb = 13,
    pl = 14,
    pt_PT = 15,
    pt_BR = 16,
    ro = 17,
    ru = 18,
    es_ES = 19,
    sv = 20,
    th = 21,
    tr = 22,
    bg = 23,
    uk = 24,
    el = 25,
    es_LA = 26,
    vi = 27,
}