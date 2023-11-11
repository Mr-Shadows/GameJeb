using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LockControl : MonoBehaviour
{
    public TextMeshPro Password;
   [SerializeField] private string truePass;
    public string pass;
    public bool complete = false;
    public ScenaryController sc;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Password.text = "Введите код";
    }

    // Update is called once per frame
    void Update()
    {
        if (truePass != sc.pass)
            truePass = sc.pass;
        if (pass.Length == 5)
            if (pass == truePass)
                complete = true;
            else
            {
                pass = "";
                audioSource.Play();
            }
        if (complete)
        {
            sc.LockComplete = true;
            Password.text = "Разрешено";
        }
        else
        {
            if (pass != "")
                Password.text = pass;
            else
                Password.text = "Введите код";
        }

    }
}
