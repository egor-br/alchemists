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
    public GameObject backImgaeEndGame;
    public GameObject buttonOfEndGame;
    public GameObject TextOfEndGame;

    private bool closedEndGameInfo = false;
    private int openElements = 0;

    public static ItemStruct[] statItems;

    public static string currentCategory;
    public static string oldCategory;

    public RectTransform Grid;
    private Image sourceImage;

    [Header("Item")]
    [SerializeField] public ItemStruct[] items;

    [Header("SaveInfo")]
    [SerializeField] private string savePath;
    [SerializeField] private string fileName;

    private void Start() {
        savePath = Path.Combine(Application.dataPath + "/Resources", fileName);
        loadFromFile();
        DataCore.currentCategory = "0";
        DataCore.oldCategory = "0";
        showItems();
        HideEndGameInfo();
    }

    private void Update() {
        int count = 32;
        int currentItem = 0;

        if(DataCore.currentCategory != DataCore.oldCategory)
        {
            for (int i = 0; i < count; i++)
            {
                Grid.GetChild(i).GetChild(0).GetChild(1).GetComponent<Text>().text = "";
                Color newColor = Grid.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().color;
                newColor.a = 0;
                Grid.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().color = newColor;
            }
            DataCore.oldCategory = DataCore.currentCategory;
        }

        for (int i = 0; i < items.Length; i++)
        {
            if(count > 0 && DataCore.currentCategory == statItems[i].category && statItems[i].opened == true)
            {
                Grid.GetChild(currentItem).GetChild(0).GetChild(1).GetComponent<Text>().text = statItems[i].name;
                
                Color newColor = Grid.GetChild(currentItem).GetChild(0).GetChild(0).GetComponent<Image>().color;
                newColor.a = 1;
                Grid.GetChild(currentItem).GetChild(0).GetChild(0).GetComponent<Image>().color = newColor;

                try
                {
                    Grid.GetChild(currentItem).GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(statItems[i].id.ToString());
                }
                catch (System.Exception)
                { 
                    Debug.Log("Ошибка загрузки изображения:\neroor: Resources.Load<Sprite>");
                }

                count--;
                currentItem++;
            }
        }
        
        saveToFile();
        if (!closedEndGameInfo)
        {
            for (int i = 0; i < DataCore.statItems.Length; i++)
            {
                if (DataCore.statItems[i].opened == true)
                {
                    openElements++;
                }
            }

            if (openElements == 339)
            {
                ShowEndGameInfo();
            }
        }

        openElements = 0;
    }

    public void ButtonCloseInfoEndGame()
    {
        HideEndGameInfo();
        closedEndGameInfo = true;
    }

    private void ShowEndGameInfo()
    {
        int count = 32;
        for (int i = 0; i < count; i++)
        {
            Grid.GetChild(i).GetChild(0).GetChild(2).GetComponent<Button>().enabled = false;
        }
        //rect.GetChild(0).GetComponent<Image>().enabled
        backImgaeEndGame.SetActive(true);
        buttonOfEndGame.SetActive(true);
        TextOfEndGame.SetActive(true);
    }

    private void HideEndGameInfo()
    {
        int count = 32;
        for (int i = 0; i < count; i++)
        {
            Grid.GetChild(i).GetChild(0).GetChild(2).GetComponent<Button>().enabled = true;
        }
        backImgaeEndGame.SetActive(false);
        buttonOfEndGame.SetActive(false);
        TextOfEndGame.SetActive(false);
    }

    private void showItems()
    {
        int count = 32;
        int currentItem = 0;

        for (int i = 0; i < count; i++)
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
                
                Color newColor = Grid.GetChild(currentItem).GetChild(0).GetChild(0).GetComponent<Image>().color;
                newColor.a = 1;
                Grid.GetChild(currentItem).GetChild(0).GetChild(0).GetComponent<Image>().color = newColor;

                try
                {
                    Grid.GetChild(currentItem).GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(statItems[i].id.ToString());
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
