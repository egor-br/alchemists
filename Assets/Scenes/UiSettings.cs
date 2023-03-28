using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structs;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiSettings : MonoBehaviour
{
    public GameObject progressBar;
    public TMP_Text openElements;
    private int openElementsCount;
    
    [Header("Item")]
    [SerializeField] public ItemStruct[] items;

    [Header("SaveInfo")]
    [SerializeField] private string savePath;
    [SerializeField] private string fileName;

    void Start()
    {
        openElementsCount = 0;
        loadFromFile();
    }

    public void resetItems()
    {
        try
        {
            for (int i = 0; i < DataCore.statItems.Length; i++)
            {
                if(i > 3)
                {
                    DataCore.statItems[i].opened = false;
                }
            }
            saveToFile();
        }
        catch (System.Exception)
        {
            
        }
    }

    void Update()
    {
        openElementsCount = 0;
        try
        {
            for (int i = 0; i < DataCore.statItems.Length; i++)
            {
                if(DataCore.statItems[i].opened == true)
                {
                    openElementsCount++;
                }
            }
            openElements.text = openElementsCount.ToString() + "/339";
            progressBar.GetComponent<RectTransform>().anchoredPosition = new Vector2((865f/339f) * (openElementsCount / 2f) - 561.5f, progressBar.GetComponent<RectTransform>().anchoredPosition.y);
            progressBar.GetComponent<SpriteRenderer>().size = new Vector2((865f / 339f) * (openElementsCount), 50);
        }
        catch (System.Exception)
        {
            
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

            DataCore.statItems = dataStructJson.items;
        }
        catch (System.Exception)
        {
            Debug.Log("Ошибка при загрузке из файла");
        }
    }

    public void saveToFile()
    {
        DataCoreStruct dataStruct = new DataCoreStruct
        {
            items = DataCore.statItems
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
}
