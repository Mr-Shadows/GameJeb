using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class ItemImageController : MonoBehaviour
{
    public string imageName;
    public string filePath; // Путь к файлу .png внутри папки проекта
    public bool createImage = false;
    public DateTime lastWriteTime;
    public DateTime postWriteTime;
    string projectPath;
    public string projectPath1;
    public string fullPath;
    public string fullPathMain;
    public string relativeImagePath;
    public string imagePathTrue;
    public string fileClearPatch;
    public bool CreateImageFlag = false;
    public bool flagClear = false;
    public string imagePath = Application.dataPath + "/Image/ItemImage.png";
    public bool imageComplete = false;
    void Start()
    {
        
        fullPath = imagePath;
        lastWriteTime = File.GetLastWriteTime(fullPath);
       
    }
    void Update()
    {
        postWriteTime = File.GetLastWriteTime(fullPath);
        UnityEngine.Debug.Log(lastWriteTime != File.GetLastWriteTime(fullPath));
        if (lastWriteTime != postWriteTime && flagClear == false) 
        {
            
                

                ClearImageFon(fullPath);
                flagClear = true;
                GameObject.Find("Scenary").GetComponent<ScenaryController>().ImageCreateComplete = true;
            
        }
        if(CreateImageFlag == true)
        {
            CreateImage();
            CreateImageFlag = false;
        }
    }
    public void CreateImage()
    {

        OpenImageInPaint(relativeImagePath);
    }
    void ClearImageFon(string imagePath)
    {
        
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
    string FindImageInProject(string imageName)
    {
        string[] imageFiles = Directory.GetFiles(Application.dataPath, imageName, SearchOption.AllDirectories);
        if (imageFiles.Length > 0)
        {
            return imageFiles[0];
        }
        return null;
    }
    void OpenImageInPaint(string relativeImagePath)
    {
        string absoluteImagePath = Path.Combine(Application.dataPath, relativeImagePath); // Склеиваем путь к проекту и относительный путь к изображению
        if (File.Exists(absoluteImagePath))
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "mspaint"; // Просто указываем название исполняемого файла программы, так как Paint обычно находится в системном пути
            startInfo.Arguments = "\"" + absoluteImagePath + "\"";
            Process.Start(startInfo);
            UnityEngine.Debug.Log("PAINT");
        }
        else
        {
            UnityEngine.Debug.Log("Файл изображения не найден.");
        }
    }



}
