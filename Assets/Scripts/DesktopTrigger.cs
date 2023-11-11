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
            timeInTrigger += Time.deltaTime; // Увеличиваем время нахождения в триггере на время между кадрами
            
        }
    }
    private void Update()
    {
        if(timeInTrigger > 30f && timeInTrigger<35) 
        {
            text.text = "Ты уверен, что на этом столе действительно работали?";
        }
        if (timeInTrigger > 60f && timeInTrigger < 65)
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
