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
    public RadioScript1 ozv;
    public Collider DverRuchka;
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

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        ScenaryScript = GameObject.Find("Player").GetComponent<RaycastInteraction>();
        string username = Environment.UserName;
        text.text = "Привет,"+ username+ " ,добро пожаловать в комнату! Я рассказчик,тут всё просто: прислушивайся ко мне и мы выберемся отсюда в два счёта";
        StartCoroutine(WritingSingleText(3, ""));
        StartCoroutine(WritingSingleText(4, "И да, я просто голос в твоей голове. Постарайся не думать об этом."));
        StartCoroutine(WritingSingleText(7, ""));
    }

    // Update is called once per frame
    void Update()
    {
        if (LockBeginScenaryComlete)
            timer += Time.deltaTime;
        if (ScenaryScript.LockScenary == true && LockBeginScenaryComlete == false)
        {
            LockBeginScenaryComlete = true;
            string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "PASSWORD.txt");

            // Write some text to the file
            pass = "82308";
            File.WriteAllText(filePath, pass);

            StartCoroutine(WritingSingleText(0, "Хм, похоже нужен код. Глянь на рабочем столе, он должен быть там."));
            ozv.NextTrack();
            StartCoroutine(WritingSingleText(4, ""));
            timer = 0;


        }
        if (!LockComplete && timer > 20 && timer < 25)
        {
            text.text = "Не люблю вешать ярлыки, но на твоём рабочем столе их довольно много.";
            ozv.NextTrack();
        }
        if (!LockComplete && timer > 50 && timer < 55)
        {
            text.text = "Слушай, ты наверное, утомился. Попробуй свернуть игру, осмотреться. Может, увидишь, что-нибудь новое?";
            ozv.NextTrack();
        }
        if (!LockComplete && timer > 70 && timer < 75)
        {
            text.text = "О, боги, ДА ПОСМОТРИ ТЫ УЖЕ НА СВОЙ РАБОЧИЙ СТОЛ!";
            ozv.NextTrack();
        }
        if (RuchkaSearchBegin && RuchkaSearch == false && !RuchkaComplete)
        {
            RuchkaSearch = true;
            timer = 0;
            StartCoroutine(WritingSingleText(0, "Класс, похоже кто-то забыл прикрепить ручку к текстуре двери. И как нам теперь её открыть?"));
            ozv.NextTrack();
            StartCoroutine(WritingSingleText(6, ""));
            StartCoroutine(WritingSingleText(7, "О, знаю! Найди что-нибудь похожее на ручку и приделай к двери. Авось прокатит."));
            ozv.NextTrack();
            StartCoroutine(WritingSingleText(12, ""));
        }
        if (!RuchkaComplete && timer > 45 && timer < 50 && LockComplete)
        {
            text.text = "Ну неужели в этой комнате совсем нет ручек? Должны быть!";
            ozv.NextTrack();


        }
        else if (text.text == "Ну неужели в этой комнате совсем нет ручек? Должны быть!")
            
        {

            text.text = "";
        }

        if (!RuchkaComplete && timer > 100 && timer < 105 && LockComplete)
        {
            text.text = "Может где-то есть ненужные ручки? Ну, такие, которыми никто не пользуется...";
            ozv.NextTrack();


        }
        else if (text.text == "Может где-то есть ненужные ручки? Ну, такие, которыми никто не пользуется...")
            
        {
            text.text = "";
        }
        if (RuchkaSearch && RuchkaComplete)
        {
            RuchkaSearch = false;
            RuchkaSearchBegin = false;
            StartCoroutine(WritingSingleText(0, "Ха, надо же... Сработало! То есть, всё как я и рассчитывал. Открывай скорее!"));
            ozv.NextTrack();
            StartCoroutine(WritingSingleText(5, ""));
        }
        if (DoorOpenComplete && !ImageCreatingBegin)
        {
            ImageCreatingBegin = true;
            StartCoroutine(WritingSingleText(0, "Оу, неожиданно... Ну да ладно. Найди что-нибудь, чтобы сломать эту стену."));
            ozv.NextTrack();
            StartCoroutine(WritingSingleText(4, ""));
            StartCoroutine(WritingSingleText(5, "Займись, так сказать, ШАХТЁРСКИМ РЕМЕСЛОМ."));
            ozv.NextTrack();
            StartCoroutine(WritingSingleText(9, ""));
            timer = 0;
        }
        if (ImageCreatingBegin && timer > 60 && timer < 65 && !ImageCreateComplete && RuchkaComplete)
        {
            text.text = "Насколько я помню, нужно всего две палки и три железных слитка. Ну или рукоять и клюв...";
            ozv.NextTrack();

        }
        else if (text.text == "Насколько я помню, нужно всего две палки и три железных слитка. Ну или рукоять и клюв...")
        {
            text.text = "";
        }
        if (!flagSearhItem && SearchDownItemComplete && SearchUpItemComplete && !ImageCreateComplete && RuchkaComplete)
        {
            timer = 0;
        }
        if (flagSearhItem && timer > 60 && timer < 65 && !ImageCreateComplete && RuchkaComplete)
        {
            text.text = "Попробуй положить запчасти на нерабочий стол \\nВот теперь это - РАБОЧИЙ стол!";
            ozv.NextTrack();
        }
        else if (text.text == "Попробуй положить запчасти на нерабочий стол \\nВот теперь это - РАБОЧИЙ стол!")
        {
            text.text = "";
        }
        if (ImageCreateComplete && !WallDestroyBegin)
        {
            timer = 0;
            StartCoroutine(WritingSingleText(0, "Ах, да, я забыл её нарисовать... А давай ты сам её нарисуешь?"));
            ozv.NextTrack();
            StartCoroutine(WritingSingleText(5, ""));

            WallDestroyBegin = true;
        }
        if (WallDestroyChek && !WallDestroyflag)
        {
            StartCoroutine(WritingSingleText(0, "???, ?? ???? ? ???????? ??????? ???... ????? ????? ??? ???? ??????"));
            StartCoroutine(WritingSingleText(4, ""));
            StartCoroutine(WritingSingleText(5, "?????? ???? ?????? ????? ?!"));
            StartCoroutine(WritingSingleText(9, ""));
            timer = 0;
            WallDestroyflag = true;
        }
        if (WallDestroyChek && !WallDestroyComplete && timer > 30 && timer < 35)
        {
            text.text = "?? ??, ?? ????. ????? ?????!";
        }
        else if (text.text == "?? ??, ?? ????. ????? ?????!")
            text.text = "";
        if (WallDestroyComplete && !WallDestroyflag && timer > 60 && timer < 65)
        {
            text.text = "??? ?? ???????? ?????, ????? ?? ??? ? ??? ??????????? ??????????";
        }
        else if (text.text == "??? ?? ???????? ?????, ????? ?? ??? ? ??? ??????????? ??????????")
        {
            text.text = "";
        }
        if (WallDestroyComplete && !WallDestroyflag && timer > 90 && timer < 95)
        {
            text.text = "???? ????????????? ??? ?????? ?????? ????????";
        }
        else if (text.text == "???? ????????????? ??? ?????? ?????? ????????")
        {
            text.text = "";
        }
        if (!LockComplete && DverRuchka.enabled)
            DverRuchka.enabled = false;
        if (LockComplete && !DverRuchka.enabled)
            DverRuchka.enabled = true;








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