using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObjLocationChanger : MonoBehaviour {

    public void OnLeftClick()
    {
        for (int i = 0; i < 9; i++)
        {
            transform.GetChild(i).GetComponent<GoogleMap>().centerLocation.longitude -= 0.0005f;
            transform.GetChild(i).GetComponent<GoogleMap>().Refresh();
        }       
    }

    public void OnRightClick()
    {
        for (int i = 0; i < 9; i++)
        {
            transform.GetChild(i).GetComponent<GoogleMap>().centerLocation.longitude += 0.0005f;
            transform.GetChild(i).GetComponent<GoogleMap>().Refresh();
        }
    }

    public void OnUpClick()
    {
        for (int i = 0; i < 9; i++)
        {
            transform.GetChild(i).GetComponent<GoogleMap>().centerLocation.latitude += 0.0005f;
            transform.GetChild(i).GetComponent<GoogleMap>().Refresh();
        }
    }

    public void OnDownClick()
    {
        for (int i = 0; i < 9; i++)
        {
            transform.GetChild(i).GetComponent<GoogleMap>().centerLocation.latitude -= 0.0005f;
            transform.GetChild(i).GetComponent<GoogleMap>().Refresh();
        }
    }
}
