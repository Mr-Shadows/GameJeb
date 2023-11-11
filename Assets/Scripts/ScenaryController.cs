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
    

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        ScenaryScript = GameObject.Find("Player").GetComponent<RaycastInteraction>();
        string username = Environment.UserName;
        text.text = "Привет,"+ username+ ",добро пожаловать в комнату! Я рассказчик,тут всё просто: прислушивайся ко мне и мы выберемся отсюда в два счёта";
        StartCoroutine(WritingSingleText(5, ""));
        StartCoroutine(WritingSingleText(10, "И да, я просто голос в твоей голове. Постарайся не думать об этом."));
    }

    // Update is called once per frame
    void Update()
    {
        if(LockBeginScenaryComlete)
            timer += Time.deltaTime;
        if(ScenaryScript.LockScenary == true && LockBeginScenaryComlete == false)
        {
            LockBeginScenaryComlete = true;
            string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "PASSWORD.txt");

            // Write some text to the file
            string pass = "82308";
            File.WriteAllText(filePath, pass);
            text.text = "Хм, похоже нужен код. Глянь на рабочем столе, он должен быть там.";
            timer = 0;

        }
        if(!LockComplete && timer > 120 && timer < 125)
        {
            text.text = "Не люблю вешать ярлыки, но на твоём рабочем столе их довольно много.";
        }
        else if (!LockComplete && timer > 180 && timer < 185)
        {
            text.text = "Слушай, ты наверное, утомился. Попробуй свернуть игру, осмотреться. Может, увидишь, что-нибудь новое?";
        }
        else if(!LockComplete && timer > 300 && timer<305)
        {
            text.text = "О, БОГИ, да посмотри ты уже на свой рабочий стол!";
        }
        else if(!LockComplete && timer > 5)
            text.text = " ";

    }
    
    IEnumerator WritingSingleText(float sleepTime, string currentText)
    {
        yield return new WaitForSeconds(sleepTime);
        text.text = currentText;
        if (currentText != " ")
        {
            yield return new WaitForSeconds(sleepTime);
            text.text = " ";
        }
    }
    public void WriteCompleteLock()
    {

    }

}
