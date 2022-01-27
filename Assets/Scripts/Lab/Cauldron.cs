using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour
{
    public List<IngridientsType> IngridientsToConsume;
    public IngridientsType ReadyIngridient;
    public List<IngridientsType> recep1;
    public List<IngridientsType> recep2;
    public List<IngridientsType> recep3;
    public List<IngridientsType> recep4;
    public List<IngridientsType> ActiveRecepy;
    public float CookingTime = 5f;
    public float TimeToNextCookingTime = 5f;
    private const float SpeedUpProcess = 0.25f;
    [HideInInspector]
    public bool IsMouseOver = false;
    public bool IsOccupide = false;
    public static bool IsPoopOccupide = false;
    public int ActiveRecepyCooking = 0; // if  <= 0 then its not cooking anything
    public SoundEffectUpdater soundeffectUpdater;
    private AudioSource audioSource;
    public GameObject CurenRecepyMissingIngredient;


    // this is for Actvie recepy items in culdron
    public GameObject SomthingInCuldron;
    public Dictionary<IngridientsType, Sprite> pairsOfIngredientTypeSpriteName = new Dictionary<IngridientsType, Sprite>();
    public List<Sprite> spritesForDict;
    public List<GameObject> ActiveRecepyCanvasHolderForItems;
    public List<GameObject> ActiveRecepyShowItems;
    public List<TextMeshProUGUI> ActiveRecepyCanvasHolderForItemsTexts;
    [SerializeField] Slider IngrediedtPripering;

    public ParticleSystem effectsSteamCoocking;
    public Animator spoonAnimation;

    public string setting;
    public string settingHower;



    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        IngrediedtPripering.value = 0f;
        IngrediedtPripering.gameObject.SetActive(false);

        effectsSteamCoocking.Stop();
        //spoonAnimation.SetTrigger("off");

        soundeffectUpdater.UpdateEffect(audioSource);
        pairsOfIngredientTypeSpriteName.Add(IngridientsType.Infusion, spritesForDict[3]);
        pairsOfIngredientTypeSpriteName.Add(IngridientsType.Cookie, spritesForDict[0]);
        pairsOfIngredientTypeSpriteName.Add(IngridientsType.Mushroom, spritesForDict[1]);
        pairsOfIngredientTypeSpriteName.Add(IngridientsType.Fruit, spritesForDict[2]);
        
        pairsOfIngredientTypeSpriteName.Add(IngridientsType.Bowl_of_Crushed_Cookies, spritesForDict[4]);
        pairsOfIngredientTypeSpriteName.Add(IngridientsType.Bowl_of_Cuted_Mushrums, spritesForDict[5]);
        pairsOfIngredientTypeSpriteName.Add(IngridientsType.Bowl_of_Cuted_Star_Fruit, spritesForDict[6]);
        pairsOfIngredientTypeSpriteName.Add(IngridientsType.Bowl_of_Steamed_Mushrums, spritesForDict[7]);
        pairsOfIngredientTypeSpriteName.Add(IngridientsType.Bowl_of_Steamed_Star_Fruit, spritesForDict[8]);


    }

    // Update is called once per frame
    void Update()
    {
        if (PauseGame.GameIsPaused)
        {
            audioSource.mute = !AdvacentSetting.GetSetting(setting);
            if (!AdvacentSetting.GetSetting(settingHower))
            {
                SomthingInCuldron.SetActive(false);
                for (int index = 0; index < ActiveRecepyCanvasHolderForItems.Count; index++)
                {
                    ActiveRecepyShowItems[index].SetActive(false);
                }
            }
            else 
            {
                SomthingInCuldron.SetActive(true);
                CertainRecepyFounded();
            }
            soundeffectUpdater.UpdateEffect(audioSource);
            return;
        }
        if (IsOccupide && ActiveRecepyCooking > 0 && !IsPoopOccupide)
        {
            // run animation 
            CookingTime -= Time.deltaTime;
            IngrediedtPripering.value = 1 - (CookingTime / TimeToNextCookingTime);
            if (DataHolder.Wizzard.CurrentLocation == Location.BattleField)
            {
                IngrediedtPripering.gameObject.SetActive(false);
            }
            else if (DataHolder.Game.Wizzard.gameObject.transform.position.x <= -20f)
            {
                IngrediedtPripering.gameObject.SetActive(true);
            }
            if (CookingTime < 0)
            {
                CookingTime = TimeToNextCookingTime;
                GiveReadyIngridient(ActiveRecepyCooking);
                RemoveRecepy();
                audioSource.Stop();
                IsOccupide = false;
                ActiveRecepyCooking = 0;
                spoonAnimation.SetTrigger("off");
                
                IngrediedtPripering.gameObject.SetActive(false);

                effectsSteamCoocking.Stop();
            }
        }
        
    }

    private bool CanBeConsumed(IngridientsType ingridientType)
    {
        foreach(IngridientsType type in IngridientsToConsume )
        {
            if (ingridientType == type && IsOccupide == false) 
            {
                return true;
            }
               
        }
        return false;
    }
    public void TryGetIngridient()
    {
        if (IsPoopOccupide) return;
        if (IsOccupide && CookingTime > 0)
        {
            CookingTime -= SpeedUpProcess;
        }
        if (DataHolder.Wizzard.CurrentIngridient == null) return;
        if (!CanBeConsumed(DataHolder.Wizzard.CurrentIngridient.IngridientType)) return;
        Consume();
    }

    public void GiveReadyIngridient(int RecepyNumber) {
        switch (RecepyNumber)
        {
            case 1:
                for (int i = 0; i < 5; i++)
                {
                    DataHolder.Factory.AddPotion(PotionsType.Potion1);
                }
                
                break;

            case 2:
                for (int i = 0; i < 5; i++)
                {
                    DataHolder.Factory.AddPotion(PotionsType.Potion2);
                }
                break;

            case 3:
                for (int i = 0; i < 5; i++)
                {
                    DataHolder.Factory.AddPotion(PotionsType.Potion3);
                }
                break;

            case 4:
                for (int i = 0; i < 3; i++)
                {
                    DataHolder.Factory.AddPotion(PotionsType.Potion1);
                    DataHolder.Factory.AddPotion(PotionsType.Potion2);
                    DataHolder.Factory.AddPotion(PotionsType.Potion3);
                }
                break;

            default:
                Debug.Log("SOMTHING IS WRONG!?");
                break;
                
        }
        DataHolder.UIHandler.UpdateStorageUI();
    }
    public void GiveReadyIngridientPoop()
    {
        IsPoopOccupide = true;
        Ingridient ingridient = DataHolder.Factory.AddIngridient(ReadyIngridient, transform.position);
        ingridient.gameObject.layer = LayerMask.NameToLayer("Default");

    }
    private void Consume()
    {
        //Destroy(DataHolder.Wizzard.CurrentIngridient.gameObject);
        if (DataHolder.Wizzard.CurrentIngridient != null) // for sure the object still exists
        {
            ActiveRecepy.Add(DataHolder.Wizzard.CurrentIngridient.IngridientType);
            int IsCorectRecepy = CheckCorrectRecepys();
            if (IsCorectRecepy > 0)
            {
                if (CheckCorrectRecepysCount(IsCorectRecepy))
                {
                    // start cooking
                    IsOccupide = true;
                    ActiveRecepyCooking = IsCorectRecepy;
                    IngrediedtPripering.gameObject.SetActive(true);
                    audioSource.Play();
                    effectsSteamCoocking.Play();
                    spoonAnimation.SetTrigger("on");
                    RemoveCanvasRecepy();



                }
                else
                {
                    // missing ingrediets
                    if (AdvacentSetting.GetSetting(settingHower))
                    {
                        SomthingInCuldron.SetActive(true);
                        CertainRecepyFounded();
                    }
                    
                    
                    
                    
                }
            }
            else
            {
                // make poop
                GiveReadyIngridientPoop();
                
                RemoveRecepy();

            }
            DataHolder.Labaratory.RemoveIngridient();
        }
       
    }
    private void CertainRecepyFounded()
    {
        int index = 0;
        foreach (KeyValuePair<IngridientsType, Sprite> kvp in pairsOfIngredientTypeSpriteName)
        {
            int count_of_Ingredient = GetCountOfIngredientsInActiveRecepy(kvp.Key);
            if (count_of_Ingredient > 0)
            {
                Image item = ActiveRecepyCanvasHolderForItems[index].GetComponent<Image>();
                item.sprite = kvp.Value;
                ActiveRecepyCanvasHolderForItemsTexts[index].text = ""+count_of_Ingredient;
                ActiveRecepyShowItems[index].SetActive(true);
                index++;
            }

        }
    }
    private int GetCountOfIngredientsInActiveRecepy(IngridientsType ingridient) 
    {

        int count = 0;
        foreach (IngridientsType item in ActiveRecepy)
        {

            if (item == ingridient)
            {
                count++;
            }
           
        }
        return count;
    
    }



    public bool CheckCorrectRecepysCount(int RecepyNumber) {
        switch (RecepyNumber)
        {
            case 1:
                foreach (IngridientsType item in recep1)
                {

                    if (CountIngredientsInRecepyIsOK(item, ActiveRecepy, recep1) == 0)
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
                break;

            case 2:

                foreach (IngridientsType item in recep2)
                {
                    if (CountIngredientsInRecepyIsOK(item, recep2, ActiveRecepy) == 0)
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
                break;

            case 3:

                foreach (IngridientsType item in recep3)
                {
                    if (CountIngredientsInRecepyIsOK(item, recep3, ActiveRecepy) == 0)
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
                break;

            case 4:
                foreach (IngridientsType item in recep4)
                {
                    if (CountIngredientsInRecepyIsOK(item, recep4, ActiveRecepy) == 0)
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
                break;

            default:
                Debug.Log("SOMTHING IS WRONG!?");
                return false;
        }
        
       
       
       
        
        return true;
    }
    public int CheckCorrectRecepys() {
        int foundedrecepy = -1;
        foreach (IngridientsType item in ActiveRecepy)
        {
            if (CountIngredientsInRecepyIsOK(item,recep1, ActiveRecepy) >= 0)
            {
                foundedrecepy = 1;
                continue;
            }
            else
            {
                foundedrecepy = -1;
                break;
            }
        }
        if (foundedrecepy > 0)
        {
            return foundedrecepy;
        }


        foreach (IngridientsType item in ActiveRecepy)
        {
            if (CountIngredientsInRecepyIsOK(item, recep2, ActiveRecepy) >= 0)
            {
                foundedrecepy = 2;
                continue;
            }
            else
            {
                foundedrecepy = -1;
                break;
            }
        }
        if (foundedrecepy > 0)
        {
            return foundedrecepy;
        }

        foreach (IngridientsType item in ActiveRecepy)
        {
            if (CountIngredientsInRecepyIsOK(item, recep3, ActiveRecepy) >= 0)
            {
                foundedrecepy = 3;
                continue;
            }
            else
            {
                foundedrecepy = -1;
                break;
            }
        }
        if (foundedrecepy > 0)
        {
            return foundedrecepy;
        }

        foreach (IngridientsType item in ActiveRecepy)
        {
            if (CountIngredientsInRecepyIsOK(item, recep4, ActiveRecepy) >= 0)
            {
                foundedrecepy = 4;
                continue;
            }
            else
            {
                foundedrecepy = -1;
                break;
            }
        }

        return foundedrecepy;
    }
    public int CountIngredientsInRecepyIsOK(IngridientsType Ingredient, List<IngridientsType> Recep, List<IngridientsType> ActiveRecep) {
        int count = 0;
        foreach (IngridientsType item in Recep)
        {
            if (item == Ingredient)
            {
                count++;
            }
        }
        foreach (IngridientsType item in ActiveRecep)
        {
            if (item == Ingredient)
            {
                count--;
            }
        }
        return count ;
    }
    public void RemoveRecepy() {

        ActiveRecepy.Clear();
        RemoveCanvasRecepy();
    }

    public void RemoveCanvasRecepy()
    {
        SomthingInCuldron.SetActive(false);
        for (int index = 0; index < ActiveRecepyCanvasHolderForItems.Count; index++)
        {
            Image item = ActiveRecepyCanvasHolderForItems[index].GetComponent<Image>();
            item.sprite = null;
            ActiveRecepyCanvasHolderForItemsTexts[index].text = "" ;
            ActiveRecepyShowItems[index].SetActive(false);
        }
    }
    private void OnMouseEnter()
    {
        IsMouseOver = true;
        DataHolder.Labaratory.EnableLabCursor();
        
    }

    private void OnMouseExit()
    {
        IsMouseOver = false;
    }


}
