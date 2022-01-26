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
       
        setDefoultBegin();
        //PlayerPrefs.Save();

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
        Debug.Log("LOADING NEW SETTINGS " + setting);
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
    public void setDefoultBegin()
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
        bool is_ON_OFF = PlayerPrefs.GetInt(setting) == 1;
        switch (setting)
        {
            case "AlarmSoundONOFF": AlarmSound = !AlarmSound; SaveSetting("AlarmSoundONOFF", GenerateValueIntPreferece(AlarmSound));  break;
            case "CuttingBoardSoundONOFF": CuttingBoardSound = !CuttingBoardSound; SaveSetting("CuttingBoardSoundONOFF", GenerateValueIntPreferece(CuttingBoardSound)); break;
            case "SteemerSoundONOFF": SteemerSound = !SteemerSound; SaveSetting("SteemerSoundONOFF", GenerateValueIntPreferece(SteemerSound)); break;
            case "GrinderSoundONOFF": GrinderSound = !GrinderSound; SaveSetting("GrinderSoundONOFF", GenerateValueIntPreferece(GrinderSound)); break;
            case "CuldronSoundONOFF": CuldronSound = !CuldronSound; SaveSetting("CuldronSoundONOFF", GenerateValueIntPreferece(CuldronSound)); break;
            case "CuttingBoardHowerONOFF": CuttingBoardHower = !CuttingBoardHower; SaveSetting("CuttingBoardHowerONOFF", GenerateValueIntPreferece(CuttingBoardHower)); break;
            case "SteemerHowerONOFF": SteemerHower = !SteemerHower; SaveSetting("SteemerHowerONOFF", GenerateValueIntPreferece(SteemerHower)); break;
            case "GrinderHowerONOFF": GrinderHower = !GrinderHower; SaveSetting("GrinderHowerONOFF", GenerateValueIntPreferece(GrinderHower)); break;
            case "CuldronHowerONOFF": CuldronHower = !CuldronHower; SaveSetting("CuldronHowerONOFF", GenerateValueIntPreferece(CuldronHower)); break;
            default:
                break;
        }
    }
    public int GenerateValueIntPreferece(bool value)
    {
        return value ? 1 : 0;
    }
}
