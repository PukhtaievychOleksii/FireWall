using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoweroverShower : MonoBehaviour
{
    public GameObject howerBowlObject;
    public string setting;
    // Start is called before the first frame update
    void Start()
    {
        howerBowlObject.SetActive(false);
    }
    void OnMouseEnter()
    {
        howerBowlObject.SetActive(AdvacentSetting.GetSetting(setting));
        /*if (setting == "CuttingBoardHowerONOFF" && AdvacentSetting.CuttingBoardHower)
        {
            howerBowlObject.SetActive(!AdvacentSetting.GetSetting(setting));
        }
        else if (setting == "SteemerHowerONOFF" && AdvacentSetting.SteemerHower)
        {
            howerBowlObject.SetActive(true);
        }
        else if (setting == "GrinderHowerONOFF" && AdvacentSetting.GrinderHower)
        {
            howerBowlObject.SetActive(true);
        }*/

    }
    void OnMouseExit()
    {
       
        howerBowlObject.SetActive(false);
        
       
    }
}
