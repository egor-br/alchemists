using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structs;
using System;
using System.IO;


public class DataCore : MonoBehaviour
{

    [Header("Item")]
    [SerializeField] private ItemStruct[] items;

    [Header("SaveInfo")]
    [SerializeField] private string savePath;
    [SerializeField] private string fileName;

    private void Awake() 
    {
        savePath = Path.Combine(Application.dataPath, fileName);
        loadFromFile();
    }

    private void saveToFile()
    {
        DataCoreStruct dataStruct = new DataCoreStruct
        {
            items = this.items
        };

        string json = JsonUtility.ToJson(dataStruct, true);

        try
        {
            File.WriteAllText(savePath, json);
        }
        catch (System.Exception)
        {
            Debug.Log("Ошибка при загрузке в файл");
        }
    }

    private void loadFromFile() 
    {
        if(File.Exists(savePath) == false)
        {
            return;
        }

        try
        {
            string json = File.ReadAllText(savePath);

            DataCoreStruct dataStructJson = JsonUtility.FromJson<DataCoreStruct>(json);

            this.items = dataStructJson.items;
        }
        catch (System.Exception)
        {
            Debug.Log("Ошибка при загрузке из файла");
        }
    }

    private void OnApplicationQuit() {
        saveToFile();
    }
}
