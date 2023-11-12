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
        if (other.CompareTag("Player")) // Проверяем, что объект, вошедший в триггер, имеет тег "Player"
        {
            // Добавьте здесь команды, которые нужно выполнить, когда игрок заходит в триггер
            Debug.Log("Player entered the trigger zone");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем, что объект, находящийся в триггере, имеет тег "Player"
        {
            if(sc.LockBeginScenaryComlete)
            timeInTrigger += Time.deltaTime; // Увеличиваем время нахождения в триггере на время между кадрами
            
        }
    }
    private void Update()
    {
        
        if (timeInTrigger > 60f && timeInTrigger < 65 && !sc.LockComplete)
        {
            text.text = "Хм, не очень похоже на РАБОЧИЙ стол...";
        }
    }
    IEnumerator WritingSingleText(float sleepTime, string currentText)
    {
        yield return new WaitForSeconds(sleepTime);
        text.text = currentText;
    }
}
