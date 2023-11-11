using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesktopTrigger : MonoBehaviour
{
   public Text text;
    private float timeInTrigger = 0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ���������, ��� ������, �������� � �������, ����� ��� "Player"
        {
            // �������� ����� �������, ������� ����� ���������, ����� ����� ������� � �������
            Debug.Log("Player entered the trigger zone");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) // ���������, ��� ������, ����������� � ��������, ����� ��� "Player"
        {
            timeInTrigger += Time.deltaTime; // ����������� ����� ���������� � �������� �� ����� ����� �������
            
        }
    }
    private void Update()
    {
        if(timeInTrigger > 30f && timeInTrigger<35) 
        {
            text.text = "�� ������, ��� �� ���� ����� ������������� ��������?";
        }
        if (timeInTrigger > 60f && timeInTrigger < 65)
        {
            text.text = "��, �� ����� ������ �� ������� ����...";
        }
    }
    IEnumerator WritingSingleText(float sleepTime, string currentText)
    {
        yield return new WaitForSeconds(sleepTime);
        text.text = currentText;
    }
}
