using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AdvacentSetting : MonoBehaviour
{
    
    public static bool AlarmSound = true;
    public static bool CuttingBoardSound = true;
    public static bool SteemerSound = true;
    public static bool GrinderSound = true;
    public static bool CuldronSound = true;

    // hower ower
    public static bool CuttingBoardHower = true;
    public static bool SteemerHower = true;
    public static bool GrinderHower = true;
    public static bool CuldronHower = true;

    public List<Toggle> TugleButtons;


    private List<string> ListOfAdvacetSettings = new List<string>()
    {   "AlarmSoundONOFF", "CuttingBoardSoundONOFF",
        "SteemerSoundONOFF", "GrinderSoundONOFF",
        "CuldronSoundONOFF", "CuttingBoardHowerONOFF",
        "SteemerHowerONOFF", "GrinderHowerONOFF","CuldronHowerONOFF", };


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ListOfAdvacetSettings.Count; i++)
        {
            if (!PlayerPrefs.HasKey(ListOfAdvacetSettings[i]))
            {
                SaveSetting(ListOfAdvacetSettings[i], 1);
            }
            else
            {
                LoadSetting(ListOfAdvacetSettings[i]);
            }
        }
       
        SetDefoultBegin();
    }

    public void SaveSetting(string setting, int On_OFF) 
    {
        switch (setting)
        {
            case "AlarmSoundONOFF": PlayerPrefs.SetInt(setting, On_OFF);  break;
            case "CuttingBoardSoundONOFF": PlayerPrefs.SetInt(setting, On_OFF);  break;
            case "SteemerSoundONOFF": PlayerPrefs.SetInt(setting, On_OFF);  break;
            case "GrinderSoundONOFF": PlayerPrefs.SetInt(setting, On_OFF);  break;
            case "CuldronSoundONOFF": PlayerPrefs.SetInt(setting, On_OFF);  break;
            case "CuttingBoardHowerONOFF": PlayerPrefs.SetInt(setting, On_OFF); break;
            case "SteemerHowerONOFF": PlayerPrefs.SetInt(setting, On_OFF);  break;
            case "GrinderHowerONOFF": PlayerPrefs.SetInt(setting, On_OFF);  break;
            case "CuldronHowerONOFF": PlayerPrefs.SetInt(setting, On_OFF);  break;
            default:
            break;
                
        }
    }
    public void LoadSetting(string setting)
    {
        bool is_ON_OFF = PlayerPrefs.GetInt(setting) == 1 ? true : false;
        switch (setting)
        {
            case "AlarmSoundONOFF": AlarmSound = is_ON_OFF; break;
            case "CuttingBoardSoundONOFF": CuttingBoardSound = is_ON_OFF; break;
            case "SteemerSoundONOFF": SteemerSound = is_ON_OFF; break;
            case "GrinderSoundONOFF": GrinderSound = is_ON_OFF; break;
            case "CuldronSoundONOFF": CuldronSound = is_ON_OFF; break;
            case "CuttingBoardHowerONOFF": CuttingBoardHower = is_ON_OFF; break;
            case "SteemerHowerONOFF": SteemerHower = is_ON_OFF; break;
            case "GrinderHowerONOFF": GrinderHower = is_ON_OFF; break;
            case "CuldronHowerONOFF": CuldronHower = is_ON_OFF; break;
            default:
                break;
        }

    }
    public void SetDefoultBegin()
    {
        TugleButtons[0].isOn = AlarmSound;
        TugleButtons[1].isOn = CuttingBoardSound;
        TugleButtons[2].isOn = SteemerSound;
        TugleButtons[3].isOn = GrinderSound;
        TugleButtons[4].isOn = CuldronSound;
        TugleButtons[5].isOn = CuttingBoardHower;
        TugleButtons[6].isOn = SteemerHower;
        TugleButtons[7].isOn = GrinderHower;
        TugleButtons[8].isOn = CuldronHower;
    }
    
    public void UpdatePrefecis(string setting) 
    {
        if (setting == null) return;
        bool is_ON_OFF = PlayerPrefs.GetInt(setting) == 1;
        switch (setting)
        {
            case "AlarmSoundONOFF": AlarmSound = TugleButtons[0].isOn; SaveSetting("AlarmSoundONOFF", GenerateValueIntPreferece(AlarmSound));  break;
            case "CuttingBoardSoundONOFF": CuttingBoardSound = TugleButtons[1].isOn; SaveSetting("CuttingBoardSoundONOFF", GenerateValueIntPreferece(CuttingBoardSound)); break;
            case "SteemerSoundONOFF": SteemerSound = TugleButtons[2].isOn; SaveSetting("SteemerSoundONOFF", GenerateValueIntPreferece(SteemerSound)); break;
            case "GrinderSoundONOFF": GrinderSound = TugleButtons[3].isOn; SaveSetting("GrinderSoundONOFF", GenerateValueIntPreferece(GrinderSound)); break;
            case "CuldronSoundONOFF": CuldronSound = TugleButtons[4].isOn; SaveSetting("CuldronSoundONOFF", GenerateValueIntPreferece(CuldronSound)); break;
            case "CuttingBoardHowerONOFF": CuttingBoardHower = TugleButtons[5].isOn; SaveSetting("CuttingBoardHowerONOFF", GenerateValueIntPreferece(CuttingBoardHower)); break;
            case "SteemerHowerONOFF": SteemerHower = TugleButtons[6].isOn; SaveSetting("SteemerHowerONOFF", GenerateValueIntPreferece(SteemerHower)); break;
            case "GrinderHowerONOFF": GrinderHower = TugleButtons[7].isOn; SaveSetting("GrinderHowerONOFF", GenerateValueIntPreferece(GrinderHower)); break;
            case "CuldronHowerONOFF": CuldronHower = TugleButtons[8].isOn; SaveSetting("CuldronHowerONOFF", GenerateValueIntPreferece(CuldronHower)); break;
            default:
                break;
        }
    }
    public int GenerateValueIntPreferece(bool value)
    {
        return value ? 1 : 0;
    }

    public static bool GetSetting(string setting)
    {
        bool is_ON_OFF_ReturnValue = false;
        switch (setting)
        {
            case "AlarmSoundONOFF": is_ON_OFF_ReturnValue = AlarmSound; break;
            case "CuttingBoardSoundONOFF": is_ON_OFF_ReturnValue = CuttingBoardSound; break;
            case "SteemerSoundONOFF": is_ON_OFF_ReturnValue = SteemerSound; break;
            case "GrinderSoundONOFF": is_ON_OFF_ReturnValue = GrinderSound; break;
            case "CuldronSoundONOFF": is_ON_OFF_ReturnValue = CuldronSound; break;
            case "CuttingBoardHowerONOFF": is_ON_OFF_ReturnValue = CuttingBoardHower; break;
            case "SteemerHowerONOFF": is_ON_OFF_ReturnValue = SteemerHower; break;
            case "GrinderHowerONOFF": is_ON_OFF_ReturnValue = GrinderHower; break;
            case "CuldronHowerONOFF": is_ON_OFF_ReturnValue = CuldronHower; break;
            default:
                break;
        }
        return is_ON_OFF_ReturnValue;

    }
}
