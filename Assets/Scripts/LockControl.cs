using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LockControl : MonoBehaviour
{
    public TextMeshPro Password;
    public string truePass = "80808";
    public string pass;
    public bool complete = false;
    // Start is called before the first frame update
    void Start()
    {
        Password.text = "������� ���";
    }

    // Update is called once per frame
    void Update()
    {

        if (complete)
        {
            Password.text = "���������";
        }
        else
        {
            if (pass != "")
                Password.text = pass;
            else
                Password.text = "������� ���";
        }
        
    }
}
