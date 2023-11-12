using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    public bool WebcamRun = false;
    bool WebCamFlag = false;
    public GameObject imageDisplayObject; // Ссылка на объект спрайта, на который будет выводиться изображение с вебкамеры
    private WebCamTexture webcamTexture;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length > 0)
        {
            Debug.Log("Веб-камера найдена: " + devices[0].name);
            // Используйте devices[0].name для доступа к имени первой найденной веб-камеры
            // Затем вы можете продолжить с использованием веб-камеры для захвата изображений
        }
        else
        {
            Debug.Log("Веб-камера не найдена");
            // Обработайте ситуацию, если веб-камера не обнаружена
        }
    }
    // Update is called once per frame
    void Update()
    {

        if(!WebCamFlag && WebcamRun)
        {
            WebCamFlag = true;
            // Получаем доступ к веб-камере
            webcamTexture = new WebCamTexture();
            imageDisplayObject.GetComponent<Renderer>().material.mainTexture = webcamTexture; // Присваиваем текстуру веб-камеры прямо на материал объекта
            webcamTexture.Play(); // Запускаем захват изображения с веб-камеры 
        }
        if (WebcamRun)
        {
            imageDisplayObject.GetComponent<Renderer>().material.mainTexture = webcamTexture; // Присваиваем текстуру веб-камеры прямо на материал объекта
        }
    }
}
