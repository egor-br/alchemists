using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structs;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class DataCore : MonoBehaviour
{

    public static ItemStruct[] statItems;
    public static string currentCategory;
    public RectTransform Grid;

    private Image sourceImage;

    [Header("Item")]
    [SerializeField] public ItemStruct[] items;

    [Header("SaveInfo")]
    [SerializeField] private string savePath;
    [SerializeField] private string fileName;

    private void Awake() 
    {
        savePath = Path.Combine(Application.dataPath, fileName);
        loadFromFile();
        DataCore.currentCategory = "1";
        showItems();
    }

    private void Update() {
        int count = 32;
        int currentItem = 0;

        for (int i = 0; i < items.Length; i++)
        {
            if(count > 0 && DataCore.currentCategory == statItems[i].category && statItems[i].opened == true)
            {
                Grid.GetChild(currentItem).GetChild(0).GetChild(1).GetComponent<Text>().text = statItems[i].name;
                
                Color newColor = Grid.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().color;
                newColor.a = 1;
                Grid.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().color = newColor;

                try
                {
                    Grid.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(statItems[i].id.ToString());
                }
                catch (System.Exception)
                { 
                    Debug.Log("Ошибка загрузки изображения:\neroor: Resources.Load<Sprite>");
                }

                count--;
                currentItem++;
            }
        }
    }

    private void showItems()
    {
        int count = 32;
        int currentItem = 0;

        for (int i = 0; i < 32; i++)
        {
            Grid.GetChild(i).GetChild(0).GetChild(1).GetComponent<Text>().text = "";
            Color newColor = Grid.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().color;
            newColor.a = 0;
            Grid.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().color = newColor;
        }

        for (int i = 0; i < items.Length; i++)
        {
            if(count > 0 && DataCore.currentCategory == statItems[i].category && statItems[i].opened == true)
            {
                Grid.GetChild(currentItem).GetChild(0).GetChild(1).GetComponent<Text>().text = statItems[i].name;
                
                Color newColor = Grid.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().color;
                newColor.a = 1;
                Grid.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().color = newColor;

                try
                {
                    Grid.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(statItems[i].id.ToString());
                }
                catch (System.Exception)
                { 
                    Debug.Log("Ошибка загрузки изображения:\neroor: Resources.Load<Sprite>");
                }

                count--;
                currentItem++;
            }
        }
        
        
    }

    private void saveToFile()
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
            DataCore.statItems = dataStructJson.items;
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
