using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    public bool WebcamRun = false;
    bool WebCamFlag = false;
    public GameObject imageDisplayObject; // ������ �� ������ �������, �� ������� ����� ���������� ����������� � ���������
    private WebCamTexture webcamTexture;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length > 0)
        {
            Debug.Log("���-������ �������: " + devices[0].name);
            // ����������� devices[0].name ��� ������� � ����� ������ ��������� ���-������
            // ����� �� ������ ���������� � �������������� ���-������ ��� ������� �����������
        }
        else
        {
            Debug.Log("���-������ �� �������");
            // ����������� ��������, ���� ���-������ �� ����������
        }
    }
    // Update is called once per frame
    void Update()
    {

        if(!WebCamFlag && WebcamRun)
        {
            WebCamFlag = true;
            // �������� ������ � ���-������
            webcamTexture = new WebCamTexture();
            imageDisplayObject.GetComponent<Renderer>().material.mainTexture = webcamTexture; // ����������� �������� ���-������ ����� �� �������� �������
            webcamTexture.Play(); // ��������� ������ ����������� � ���-������ 
        }
        if (WebcamRun)
        {
            imageDisplayObject.GetComponent<Renderer>().material.mainTexture = webcamTexture; // ����������� �������� ���-������ ����� �� �������� �������
        }
    }
}
