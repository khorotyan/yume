using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterManager : MonoBehaviour {

    public static string hexAppColor = "C70039";

    private List<int> placesToRemove = new List<int>();

    public Transform filterPage;
    public Transform mainPage;
    public Transform filterContent;
    public Transform mainPageContent;

    [Space(5)]

    public Button mapCloserButton;

    public Transform laPiazza;
    public Transform cafeCentral;
    public Transform specificPages;

    [Space(5)]

    public GameObject scrollPart;
    public GameObject scrollPart1;

    [Space(5)]

    public InputField atmosphereRating;
    public InputField qualityRating;
    public Button defButton;

    private Color32 appColor;
    private ColorBlock appColorBlock;
    private ColorBlock defColorBlock;
    private Color32 defTextColor;
    private Color32 appTextColor;

    void Awake ()
    {
        appColor = HexToColor(hexAppColor);
        defTextColor = HexToColor("454545FF");
        appTextColor = HexToColor("FFFFFFFF");

        appColorBlock = filterPage.GetChild(2).GetComponent<Button>().colors;
        appColorBlock.normalColor = appColor;
        appColorBlock.highlightedColor = new Color32((byte)Mathf.Min(appColor.r + 30, 255), (byte)Mathf.Min(appColor.g + 30, 255), (byte)Mathf.Min(appColor.b, 255), appColor.a);
        appColorBlock.pressedColor = new Color32((byte)Mathf.Min(appColor.r + 60, 255), (byte)Mathf.Min(appColor.g + 60, 255), (byte)Mathf.Min(appColor.b, 255), appColor.a);

        SetFilterPageColors();
        SetMainPageColors();
        SetMapCloserColor();

        defColorBlock = defButton.colors;

        atmosphereRating.characterLimit = 1;
        atmosphereRating.contentType = InputField.ContentType.IntegerNumber;

        qualityRating.characterLimit = 1;
        qualityRating.contentType = InputField.ContentType.IntegerNumber;
    }

    public void OnLaPiazzaClick()
    {
        mainPage.gameObject.SetActive(false);
        specificPages.gameObject.SetActive(true);
        laPiazza.gameObject.SetActive(true);
    }

    public void OnCafeCentralClick()
    {
        mainPage.gameObject.SetActive(false);
        specificPages.gameObject.SetActive(true);
        cafeCentral.gameObject.SetActive(true);
    }

    public void OnCloseLaPiazza()
    {
        mainPage.gameObject.SetActive(true);
        specificPages.gameObject.SetActive(false);
        laPiazza.gameObject.SetActive(false);
    }

    public void OnCloseCafeCentral()
    {
        mainPage.gameObject.SetActive(true);
        specificPages.gameObject.SetActive(false);
        cafeCentral.gameObject.SetActive(false);
    }

    public void OnNearMeClick()
    {
        scrollPart.SetActive(!scrollPart.activeSelf);
        scrollPart1.SetActive(!scrollPart1.activeSelf);
    }

    public void OnFilterNearMeConfig()
    {
        scrollPart.SetActive(true);
        scrollPart1.SetActive(false);
    }

    Color HexToColor(string hex)
    {
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        return new Color32(r, g, b, 255);
    }

    private void SetFilterPageColors()
    {
        filterPage.GetChild(0).GetComponent<Image>().color = appColor;
        
        filterPage.GetChild(2).GetComponent<Button>().colors = appColorBlock;
        filterPage.GetChild(3).GetComponent<Button>().colors = appColorBlock;
        filterPage.GetChild(5).GetComponent<Button>().colors = appColorBlock;
    }

    private void SetMainPageColors()
    {
        mainPage.GetChild(0).GetComponent<Image>().color = appColor;

        for (int i = 0; i < 25; i++)
        {
            mainPageContent.GetChild(i).GetChild(6).GetChild(0).GetChild(0).GetComponent<Image>().color = appColor;
        }
    }

    private void SetMapCloserColor()
    {
        mapCloserButton.GetComponent<Image>().color = appColor;
        mapCloserButton.GetComponent<Button>().colors = appColorBlock;
    }
	
	public void SetPrice(int buttonNumber)
    {
        bool isOn = false;

        if (filterContent.GetChild(1).GetChild(buttonNumber).GetChild(0).GetComponent<Text>().color == appTextColor)
        {
            isOn = true;
        }

        OnClearClick();

        for (int i = 0; i < 4; i++)
        {
            filterContent.GetChild(1).GetChild(i).GetChild(0).GetComponent<Text>().color = defTextColor;
            filterContent.GetChild(1).GetChild(i).GetComponent<Button>().colors = defColorBlock;
        }

        if (isOn == false)
        {
            filterContent.GetChild(1).GetChild(buttonNumber).GetChild(0).GetComponent<Text>().color = appTextColor;
            filterContent.GetChild(1).GetChild(buttonNumber).GetComponent<Button>().colors = appColorBlock;

            placesToRemove = new List<int>();

            if (buttonNumber == 0)
            {
                for (int i = 0; i < 25; i++)
                {
                    if (DataStorer.prices[i] != 1)
                    {
                        if (!placesToRemove.Contains(i))
                        {
                            placesToRemove.Add(i);
                        }
                    }
                }
            }
            else if (buttonNumber == 1)
            {
                for (int i = 0; i < 25; i++)
                {
                    if (DataStorer.prices[i] != 2)
                    {
                        if (!placesToRemove.Contains(i))
                        {
                            placesToRemove.Add(i);
                        }
                    }
                }
            }
            else if (buttonNumber == 2)
            {
                for (int i = 0; i < 25; i++)
                {
                    if (DataStorer.prices[i] != 3)
                    {
                        if (!placesToRemove.Contains(i))
                        {
                            placesToRemove.Add(i);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 25; i++)
                {
                    if (DataStorer.prices[i] != 4)
                    {
                        if (!placesToRemove.Contains(i))
                        {
                            placesToRemove.Add(i);
                        }
                    }
                }
            }
        }
        else
        {
            filterContent.GetChild(1).GetChild(buttonNumber).GetChild(0).GetComponent<Text>().color = defTextColor;
            filterContent.GetChild(1).GetChild(buttonNumber).GetComponent<Button>().colors = defColorBlock;

            placesToRemove = new List<int>();
        }
    }

    public void SetOpenTime(int buttonNumber)
    {
        bool isOn = false;

        if (filterContent.GetChild(6).GetChild(buttonNumber).GetChild(0).GetComponent<Text>().color == appTextColor)
        {
            isOn = true;
        }

        for (int i = 0; i < 2; i++)
        {
            filterContent.GetChild(6).GetChild(i).GetChild(0).GetComponent<Text>().color = defTextColor;
            filterContent.GetChild(6).GetChild(i).GetComponent<Button>().colors = defColorBlock;
        }

        if (isOn == false)
        {
            filterContent.GetChild(6).GetChild(buttonNumber).GetChild(0).GetComponent<Text>().color = appTextColor;
            filterContent.GetChild(6).GetChild(buttonNumber).GetComponent<Button>().colors = appColorBlock;
        }
    }

    public void SetCategoryOfPlace(int buttonNumber)
    {
        bool isOn = false;

        if (buttonNumber <= 2)
        {
            if (filterContent.GetChild(8).GetChild(buttonNumber).GetChild(0).GetComponent<Text>().color == appTextColor)
            {
                isOn = true;
            }
        }
        else if (buttonNumber <= 5)
        {
            if (filterContent.GetChild(9).GetChild(buttonNumber - 3).GetChild(0).GetComponent<Text>().color == appTextColor)
            {
                isOn = true;
            }
        }
        else
        {
            if (filterContent.GetChild(10).GetChild(buttonNumber - 6).GetChild(0).GetComponent<Text>().color == appTextColor)
            {
                isOn = true;
            }
        }

        

        OnClearClick();

        for (int j = 8; j < 11; j++)
        {
            for (int i = 0; i < 3; i++)
            {
                filterContent.GetChild(j).GetChild(i).GetChild(0).GetComponent<Text>().color = defTextColor;
                filterContent.GetChild(j).GetChild(i).GetComponent<Button>().colors = defColorBlock;
            }
        }

        if (isOn == false)
        {
            placesToRemove = new List<int>();

            if (buttonNumber <= 2)
            {
                filterContent.GetChild(8).GetChild(buttonNumber).GetChild(0).GetComponent<Text>().color = appTextColor;
                filterContent.GetChild(8).GetChild(buttonNumber).GetComponent<Button>().colors = appColorBlock;
            }
            else if (buttonNumber <= 5)
            {
                filterContent.GetChild(9).GetChild(buttonNumber - 3).GetChild(0).GetComponent<Text>().color = appTextColor;
                filterContent.GetChild(9).GetChild(buttonNumber - 3).GetComponent<Button>().colors = appColorBlock;
            }
            else
            {
                filterContent.GetChild(10).GetChild(buttonNumber - 6).GetChild(0).GetComponent<Text>().color = appTextColor;
                filterContent.GetChild(10).GetChild(buttonNumber - 6).GetComponent<Button>().colors = appColorBlock;
            }

            if (buttonNumber == 0)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (!Array.Exists(DataStorer.restaurants, item => item == j))
                    {
                        placesToRemove.Add(j);
                    }          
                }        
            }
            else if (buttonNumber == 1)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (!Array.Exists(DataStorer.pubs, item => item == j))
                    {
                        placesToRemove.Add(j);
                    }
                }
            }
            else if (buttonNumber == 2)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (!Array.Exists(DataStorer.clubsBars, item => item == j))
                    {
                        placesToRemove.Add(j);
                    }
                }
            }
        }
        else
        {
            placesToRemove = new List<int>();

            for (int j = 8; j < 11; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    filterContent.GetChild(j).GetChild(i).GetChild(0).GetComponent<Text>().color = defTextColor;
                    filterContent.GetChild(j).GetChild(i).GetComponent<Button>().colors = defColorBlock;
                }
            }
        }
    }

    public void OnAtmosphereRatingSet()
    {
        int minRating = 0;

        OnClearClick();

        int.TryParse(atmosphereRating.text, out minRating);

        for (int i = 0; i < 25; i++)
        {
            if (DataStorer.atmosphereRatings[i] < minRating)
            {
                placesToRemove.Add(i);
            }
        }
    }

    public void OnQualityRatingSet()
    {
        int minRating = 0;

        OnClearClick();

        int.TryParse(qualityRating.text, out minRating);

        for (int i = 0; i < 25; i++)
        {
            if (DataStorer.productRatings[i] < minRating)
            {
                placesToRemove.Add(i);
            }
        }
    }

    public void OnClearClick()
    {
        for (int i = 0; i < 4; i++)
        {
            filterContent.GetChild(1).GetChild(i).GetChild(0).GetComponent<Text>().color = defTextColor;
            filterContent.GetChild(1).GetChild(i).GetComponent<Button>().colors = defColorBlock;
        }

        for (int i = 0; i < 2; i++)
        {
            filterContent.GetChild(6).GetChild(i).GetChild(0).GetComponent<Text>().color = defTextColor;
            filterContent.GetChild(6).GetChild(i).GetComponent<Button>().colors = defColorBlock;
        }

        for (int j = 8; j < 11; j++)
        {
            for (int i = 0; i < 3; i++)
            {
                filterContent.GetChild(j).GetChild(i).GetChild(0).GetComponent<Text>().color = defTextColor;
                filterContent.GetChild(j).GetChild(i).GetComponent<Button>().colors = defColorBlock;
            }
        }

        placesToRemove = new List<int>();
    }

    private void DoFiltering()
    {
        for (int i = 0; i < 25; i++)
        {
            mainPageContent.GetChild(i).gameObject.SetActive(true);
        }

        for (int i = 0; i < placesToRemove.Count; i++)
        {
            mainPageContent.GetChild(placesToRemove[i]).gameObject.SetActive(false);
        }
    }

    public void OnOpenCloseFiltersPage()
    {
        filterPage.gameObject.SetActive(!filterPage.gameObject.activeSelf);
        mainPage.gameObject.SetActive(!filterPage.gameObject.activeSelf);
    }

    public void OnSearchWithFilters()
    {
        filterPage.gameObject.SetActive(!filterPage.gameObject.activeSelf);
        mainPage.gameObject.SetActive(!filterPage.gameObject.activeSelf);

        DoFiltering();
    }
}
