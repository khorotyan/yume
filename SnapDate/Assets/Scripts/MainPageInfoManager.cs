using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPageInfoManager : MonoBehaviour
{
    [SerializeField]
    public List<ItemInfo> items = new List<ItemInfo>();

    public GameObject mainPageObj;

    private void InfoContainer()
    {
        

        
    }

    public void OnMapsOpen()
    {
        mainPageObj.SetActive(false);
    }

    public void OnMapsClose()
    {
        mainPageObj.SetActive(true);
    }

}

[System.Serializable]
public class ItemInfo
{
    public string name;
    public Sprite mainImage;
    public float[] ratings;
    public int price;
    public string[] features;
    public string location;
    public Sprite locationImage;
    public string openHours;
    public string email;
    public string website;
    public string phoneNumber;
    public string menuLink;
    public string[] reviews;
    public int[][] reviewRatings;
    public int[] reviewLikes;

    public ItemInfo(string name, Sprite mainImage, float[] ratings, int price, string[] features, string location, Sprite locationImage, 
        string openHours, string email, string website, string phoneNumber, string menuLink, string[] reviews, int[][] reviewRatings, int[] reviewLikes)
    {
        this.name = name;
        this.mainImage = mainImage;
        this.ratings = ratings;
        this.price = price;
        this.features = features;
        this.location = location;
        this.locationImage = locationImage;
        this.openHours = openHours;
        this.email = email;
        this.website = website;
        this.phoneNumber = phoneNumber;
        this.menuLink = menuLink;
        this.reviews = reviews;
        this.reviewRatings = reviewRatings;
        this.reviewLikes = reviewLikes;
    }
}
