using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScenaryController : MonoBehaviour
{
    private RaycastInteraction ScenaryScript;
    public Text text;
    public bool LockBeginScenaryComlete = false;
    public bool LockScenaryChekComplete = false;
    public bool LockComplete = false;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        ScenaryScript = GameObject.Find("Player").GetComponent<RaycastInteraction>();
        string username = Environment.UserName;
        text.text = "������,"+ username+ ",����� ���������� � �������! � ����������,��� �� ������: ������������� �� ��� � �� ��������� ������ � ��� �����";
        StartCoroutine(WritingSingleText(5, "� ��, � ������ ����� � ����� ������. ���������� �� ������ �� ����."));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(ScenaryScript.LockScenary == true && LockBeginScenaryComlete == false)
        {
            LockBeginScenaryComlete = true;
            string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "PASSWORD.txt");

            // Write some text to the file
            string pass = "82308";
            File.WriteAllText(filePath, pass);
            text.text = "����������:��, ������ ����� ���. ����� �� ������� �����, �� ������ ���� ���.";
            timer = 0;

        }
        if(LockComplete = false && timer > 120 && timer < 125)
        {
            text.text = "�� ����� ������ ������, �� �� ���� ������� ����� �� �������� �����.";
        }
        if (LockComplete = false && timer > 180 && timer < 185)
        {
            text.text = "������, �� ��������, ��������. �������� �������� ����, �����������. �����, �������, ���-������ �����?";
        }
        if(LockComplete = false && timer > 300 && timer<305)
        {
            text.text = "�, ����, �� �������� �� ��� �� ���� ������� ����!";
        }


    }
    
    IEnumerator WritingSingleText(float sleepTime, string currentText)
    {
        yield return new WaitForSeconds(sleepTime);
        text.text = currentText;
    }

}
