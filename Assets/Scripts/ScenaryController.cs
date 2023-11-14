using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScenaryController : MonoBehaviour
{
    private RaycastInteraction ScenaryScript;
    public TMP_Text text;
    public bool LockBeginScenaryComlete = false;
    public bool LockScenaryChekComplete = false;
    public bool LockComplete = false;
    public bool RuchkaSearchBegin = false;
    public bool RuchkaSearch = false;
    public bool RuchkaComplete = false;
    public bool DoorOpenComplete = false;
    public bool ImageCreatingBegin = false;
    public bool SearchUpItemComplete = false;
    public bool SearchDownItemComplete = false;
    public bool ImageCreateComplete = false;
    bool flagSearhItem = false;
    public bool ImageCreating = false;
    public bool WallDestroyBegin = false;
    public bool WallDestroyChek = false;
    public bool WallDestroyflag = false;
    public bool WallDestroyComplete = false;
    
    public string pass;

    public RadioScript1 track;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        ScenaryScript = GameObject.Find("Player").GetComponent<RaycastInteraction>();
        string username = Environment.UserName;
        text.text = "������,"+ username+ ",����� ���������� � �������! � ����������,��� �� ������: ������������� �� ��� � �� ��������� ������ � ��� �����";
        track.NextTrack();
        StartCoroutine(WritingSingleText(3, ""));
        StartCoroutine(WritingSingleText(4, "� ��, � ������ ����� � ����� ������. ���������� �� ������ �� ����."));
        StartCoroutine(WritingSingleText(7, ""));
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
            pass = "82308";
            File.WriteAllText(filePath, pass);

            StartCoroutine(WritingSingleText(0, "��, ������ ����� ���. ����� �� ������� �����, �� ������ ���� ���."));
            StartCoroutine(WritingSingleText(4, ""));
            timer = 0;
            

        }
        if(!LockComplete && timer > 120 && timer < 125)
        {
            text.text = "�� ����� ������ ������, �� �� ���� ������� ����� �� �������� �����.";
        }
        if (!LockComplete && timer > 180 && timer < 185)
        {
            text.text = "������, �� ��������, ��������. �������� �������� ����, �����������. �����, �������, ���-������ �����?";
        }
        if(!LockComplete && timer > 300 && timer<305)
        {
            text.text = "�, ����, �� �������� �� ��� �� ���� ������� ����!";
        }
        if (RuchkaSearchBegin && RuchkaSearch == false && !RuchkaComplete)
        {
            RuchkaSearch = true;
            timer = 0;
            StartCoroutine(WritingSingleText(0, "�����, ������ ���-�� ����� ���������� ����� � �������� �����. � ��� ��� ������ � �������?"));
            StartCoroutine(WritingSingleText(6, ""));
            StartCoroutine(WritingSingleText(7, "�, ����! ����� ���-������ ������� �� ����� � �������� � �����. ����� ��������."));
            StartCoroutine(WritingSingleText(12, ""));
        }
        if (!RuchkaComplete && timer > 45 && timer < 50)
        {
            text.text = "�� ������� � ���� ������� ������ ��� �����? ������ ����!";
            

        }
        else if (text.text == "�� ������� � ���� ������� ������ ��� �����? ������ ����!")
        {
            text.text = "";
        }

        if (!RuchkaComplete && timer > 100 && timer < 105)
        {
            text.text = "����� ���-�� ���� �������� �����? ��, �����, �������� ����� �� ����������...";
            

        }
        else if (text.text == "����� ���-�� ���� �������� �����? ��, �����, �������� ����� �� ����������...")
        {
            text.text = "";
        }
        if (RuchkaSearch && RuchkaComplete)
        {
            RuchkaSearch = false;
            RuchkaSearchBegin = false;
            StartCoroutine(WritingSingleText(0, "��, ���� ��... ���������! �� ����, �� ��� � � �����������. �������� ������!"));
            StartCoroutine(WritingSingleText(5, ""));
        }
        if (DoorOpenComplete && ImageCreatingBegin == false)
        {
            ImageCreatingBegin = true;
            StartCoroutine(WritingSingleText(0, "��, ����������... �� �� �����. ����� ���-������, ����� ������� ��� �����."));
            StartCoroutine(WritingSingleText(4, ""));
            StartCoroutine(WritingSingleText(5, "�������, ��� �������, ���Ҩ����� ��������."));
            StartCoroutine(WritingSingleText(9, ""));
            timer = 0;
        }
        if(ImageCreatingBegin && timer > 60 && timer < 65 && !ImageCreateComplete)
        {
            text.text = "��������� � �����, ����� ����� ��� ����� � ��� �������� ������. �� ��� ������� � ����...";
            
        }
        else if(text.text == "��������� � �����, ����� ����� ��� ����� � ��� �������� ������. �� ��� ������� � ����...")
        {
            text.text = "";
        }
        if(!flagSearhItem && SearchDownItemComplete && SearchUpItemComplete && !ImageCreateComplete)
        {
            timer = 0;
        }
        if(flagSearhItem && timer > 60 && timer < 65 && !ImageCreateComplete)
        {
            text.text = "�������� �������� �������� �� ��������� ���� \n��� ������ ��� - ������� ����!";
        }
        else if(text.text == "�������� �������� �������� �� ��������� ���� \n��� ������ ��� - ������� ����!")
        {
            text.text = "";
        }
        if (ImageCreating && !ImageCreateComplete)
        {
            text.text = "��, ��, � ����� � ����������... � ����� �� ��� � ���������? ";
            
        }
        else
        {
            if(text.text == "��, ��, � ����� � ����������... � ����� �� ��� � ���������? ")
            {
                text.text = "";
            }
        }
        if (ImageCreateComplete && !WallDestroyBegin)
        {
            timer = 0;
            StartCoroutine(WritingSingleText(0, "���, �� ������� ���� ������... �� �� �����.������ �������� ������� �����!"));
            StartCoroutine(WritingSingleText(5, ""));
            
            WallDestroyBegin = true;
        }
        if(WallDestroyChek && !WallDestroyflag)
        {
            StartCoroutine(WritingSingleText(0, "���, �� ���� � �������� ������� ���... ����� ����� ��� ���� �����?"));
            StartCoroutine(WritingSingleText(4, ""));
            StartCoroutine(WritingSingleText(5, "������ ���? ������ ����� �!"));
            StartCoroutine(WritingSingleText(9, ""));
            timer = 0;
            WallDestroyflag = true;
        }
        if (WallDestroyChek && !WallDestroyComplete && timer > 30 && timer < 35)
        {
            text.text = "�� ��, �� ����. ����� �����!";
        }
        else if (text.text == "�� ��, �� ����. ����� �����!")
            text.text = "";
        if(WallDestroyComplete && !WallDestroyflag && timer > 60 && timer < 65)
        {
            text.text = "��� �� �������� �����, ����� �� ��� � ��� ����������� ����������";
        }
        else if(text.text == "��� �� �������� �����, ����� �� ��� � ��� ����������� ����������")
        {
            text.text = "";
        }
        if (WallDestroyComplete && !WallDestroyflag && timer > 90 && timer < 95)
        {
            text.text = "���� ������������� ��� ������ ������ �������?";
        } else if (text.text == "���� ������������� ��� ������ ������ �������?")
        {
            text.text = "";
        }








    }
    
    IEnumerator WritingSingleText(float sleepTime, string currentText)
    {
        yield return new WaitForSeconds(sleepTime);
        text.text = currentText;
        //if (currentText != "")
        //{
        //    yield return new WaitForSeconds(sleepTime);
        //    text.text = "";
        //}
    }
    

}
