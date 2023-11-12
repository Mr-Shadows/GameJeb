using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class ItemImageController : MonoBehaviour
{
    public string filePath; // Путь к файлу .png внутри папки проекта
    public bool createImage = false;
    public DateTime lastWriteTime;
    string projectPath;
    public string projectPath1;
    string fullPath;
    public string imagePathTrue;
    public string fileClearPatch;
    public bool flagClear = false;
    public bool imageComplete = false;
    void Start()
    {
        
    }
    void Update()
    {
        if(lastWriteTime!= File.GetLastWriteTime(fullPath)) 
        {
            if(flagClear == false)
            {
                

                ClearImageFon(Path.Combine(projectPath, fileClearPatch));
                flagClear = true;
                GameObject.Find("Scenary").GetComponent<ScenaryController>().ImageCreateComplete = true;
            }
        }
    }
    public void CreateImage()
    {
        
        projectPath = Application.dataPath; // Получаем путь к папке Assets внутри проекта
        
        
        fullPath = Path.Combine(projectPath, filePath); // Получаем полный путь к файлу

        // Открываем файл в Paint
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "mspaint.exe",
            Arguments = fullPath
        };
        Process.Start(startInfo);

        // Получаем время последнего изменения файла
        lastWriteTime = File.GetLastWriteTime(fullPath);

        // Дальнейшая логика для проверки изменения файла
        // Можно сравнить lastWriteTime с новым временем последнего изменения файла в Update() или другом подходящем методе
    }
    void ClearImageFon(string imagePathCur)
    {
        string imagePath = "";
        for (int i = 0; i < imagePathCur.Length; i++)
        {
           
            if (imagePathCur[i] == '\\')
                imagePath+= '/';

            else
            {
                imagePath += imagePathCur[i];
            }


        }
        if (System.IO.File.Exists(imagePath))
        {
            byte[] fileData = System.IO.File.ReadAllBytes(imagePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData); // Загружаем изображение из файла

            for (int x = 0; x < texture.width; x++)
            {
                for (int y = 0; y < texture.height; y++)
                {
                    Color pixelColor = texture.GetPixel(x, y);
                    if (ColorCloseToWhite(pixelColor))
                    {
                        UnityEngine.Debug.Log("clflaflwlf");
                        pixelColor.a = 0; // Устанавливаем альфа-канал в 0
                        texture.SetPixel(x, y, pixelColor);
                    }
                }
            }
            texture.Apply(); // Применяем изменения

            // Сохраняем обработанное изображение обратно в файл
            byte[] bytes = texture.EncodeToPNG();
            System.IO.File.WriteAllBytes(imagePath, bytes);
        }
        else
        {
            UnityEngine.Debug.LogError("Файл не найден: " + imagePath);
        }
    }

    bool ColorCloseToWhite(Color color)
    {
        return (color.r > 0.9f && color.g > 0.9f && color.b > 0.9f);
    }

    
    
}
