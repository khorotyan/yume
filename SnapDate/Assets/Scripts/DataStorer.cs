using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataStorer : MonoBehaviour
{
    public Transform mainContent;

    public static List<float> distances;
    public static List<int> prices;

    public static List<float> productRatings;
    public static List<float> atmosphereRatings;

    public static int[] restaurants;
    public static int[] pubs;
    public static int[] clubsBars;

    public static int[] anticafes;
    public static int[] beerhouses;
    public static int[] cinemas;

    public static int[] bowlings;
    public static int[] billiards;
    public static int[] theaters;

    void Awake ()
    {
        distanceDataAdd();
        priceDataAdd();
        productRatingDataAdd();
        atmosphereRatingDataAdd();
        placeCategoriesData();

        SetPlaceScore();
    }

    private void SetPlaceScore()
    {
        for (int i = 0; i < 25; i++)
        {
            float sumed = (productRatings[i] + atmosphereRatings[i]);
            float integered = (float) Math.Round(Convert.ToDouble(sumed), MidpointRounding.AwayFromZero);
            float final = integered / 4;

            float sliderValue = 0;

            if (final == 2f)
            {
                sliderValue = 0.4f;
            }
            else if (final == 2.25f)
            {
                sliderValue = 0.469f;
            }
            else if (final == 2.5f)
            {
                sliderValue = 0.5f;
            }
            else if (final == 2.75f)
            {
                sliderValue = 0.529f;
            }
            else if (final == 3f)
            {
                sliderValue = 0.6f;
            }
            else if (final == 3.25f)
            {
                sliderValue = 0.676f;
            }
            else if (final == 3.5f)
            {
                sliderValue = 0.705f;
            }
            else if (final == 3.75f)
            {
                sliderValue = 0.736f;
            }
            else if (final == 4f)
            {
                sliderValue = 0.8f;
            }
            else if (final == 4.25f)
            {
                sliderValue = 0.883f;
            }
            else if (final == 4.5f)
            {
                sliderValue = 0.913f;
            }
            else if (final == 4.75f)
            {
                sliderValue = 0.943f;
            }
            else if (final == 5f)
            {
                sliderValue = 1f;
            }

            mainContent.GetChild(i).GetChild(6).GetComponent<Slider>().value = sliderValue;
        }
    }

    private void distanceDataAdd()
    {
        float[] distArr;

        distArr = new float[] 
        {
            2.2f, 1.0f, 2.1f, 2.7f, 1.9f,
            0.1f, 2.3f, 1.2f, 1.1f, 2.8f,
            2.6f, 2.9f, 2.4f, 2.9f, 2.1f,
            2.1f, 1.9f, 5.7f, 4.3f, 7.7f,
            2.6f, 3.3f, 1.1f, 1.4f, 3.3f
        };

        distances = new List<float>(distArr);
    }

    private void priceDataAdd()
    {
        int[] priceArr;

        priceArr = new int[]
        {
            4, 3, 4, 3, 3,
            3, 2, 3, 3, 3,
            4, 4, 4, 3, 3,
            1, 1, 2, 2, 4,
            3, 4, 4, 1, 1
        };

        prices = new List<int>(priceArr);
    }
    
    private void productRatingDataAdd()
    {
        float[] prodArr;

        prodArr = new float[]
        {
            8.3f, 7.1f, 7.9f, 6.8f, 9.1f,
            6.4f, 7.7f, 6.9f, 6.3f, 9.4f,
            6.6f, 5.0f, 6.1f, 5.3f, 7.0f,
            8.5f, 7.2f, 7.7f, 7.9f, 5.4f,
            5.9f, 7.2f, 8.8f, 8.1f, 7.5f
        };

        productRatings = new List<float>(prodArr);
    }

    private void atmosphereRatingDataAdd()
    {
        float[] atmosArr;

        atmosArr = new float[]
        {
            8.1f, 7.4f, 7.7f, 9.0f, 7.2f,
            7.8f, 5.1f, 6.5f, 5.9f, 8.5f,
            6.3f, 5.9f, 7.2f, 5.1f, 5.6f,
            9.0f, 7.8f, 9.5f, 9.1f, 5.7f,
            7.3f, 8.9f, 6.1f, 9.0f, 8.2f
        };

        atmosphereRatings = new List<float>(atmosArr);
    }

    private void placeCategoriesData()
    {
        restaurants = new int[]
        {
            0, 1, 2, 3, 4, 5, 6, 8, 9, 10, 11, 12, 13, 22
        };
        pubs = new int[]
        {
            7, 14, 21
        };
        clubsBars = new int[]
        {
            7, 14, 21
        };

        anticafes = new int[]
        {
            15, 16
        };
        beerhouses = new int[]
        {
            1, 14, 22
        };
        cinemas = new int[]
        {
            17, 18
        };

        bowlings = new int[]
        {
            18, 19, 20
        };
        billiards = new int[]
        {
            19, 20
        };
        theaters = new int[]
        {
            23, 24
        };
    }
}
