using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaySystemTutorial : MonoBehaviour
{
    [SerializeField] SayStuff �}�Y��� = null;
    void Start()
    {
        SaySystem.instance.StartSay(�}�Y���, �}�Y��ܤ��X);
    }
    [SerializeField] SayStuff ���դF��� = null;
    [SerializeField] SayStuff �٬O������ = null;
    void �}�Y��ܤ��X(int result)
    {
        if (result == 0) // �^�� �ک��դF...
        {
            SaySystem.instance.AddSay(���դF���);
        }
        else if (result == 1) // �^�� �٬O������...
        {
            SaySystem.instance.AddSay(�٬O������, �٬O��������ܤ��X);
        }
        else if (result == 2) // �^�� �����������
        {
            // ԣ������
        }
    }
    void �٬O��������ܤ��X(int result)
    {
        if (result == 0) // �^�� �n��
        {
            SaySystem.instance.AddSay(�}�Y���, �}�Y��ܤ��X);
        }
        else if (result == 1) // �^�� ���ݭn
        {
            // ԣ������
        }
    }
}
