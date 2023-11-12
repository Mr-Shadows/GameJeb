using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DesktopTrigger : MonoBehaviour
{
    public ScenaryController sc;
    public TMP_Text text;
    public float timeInTrigger = 0f;
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
            if(sc.LockBeginScenaryComlete)
            timeInTrigger += Time.deltaTime; // ����������� ����� ���������� � �������� �� ����� ����� �������
            
        }
    }
    private void Update()
    {
        
        if (timeInTrigger > 60f && timeInTrigger < 65 && !sc.LockComplete)
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
