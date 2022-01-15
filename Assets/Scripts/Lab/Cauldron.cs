using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [HideInInspector]
    public bool IsMouseOver = false;
    public bool IsOccupide = false;
    public static bool IsPoopOccupide = false;
    public int ActiveRecepyCooking = 0; // if  <= 0 then its not cooking anything
    public SoundEffectUpdater soundeffectUpdater;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        soundeffectUpdater.UpdateEffect(audioSource);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseGame.GameIsPoused)
        {
            soundeffectUpdater.UpdateEffect(audioSource);
            return;
        }
        if (IsOccupide && ActiveRecepyCooking > 0 && !IsPoopOccupide)
        {
            // run animation 
            CookingTime -= Time.deltaTime;
            if (CookingTime < 0)
            {
                CookingTime = TimeToNextCookingTime;
                GiveReadyIngridient(ActiveRecepyCooking);
                RemoveRecepy();
                audioSource.Stop();
                IsOccupide = false;
                ActiveRecepyCooking = 0;
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
        //Debug.Log("CULDRON SOM TUNA");
        if (DataHolder.Wizzard.CurrentIngridient == null) return;
        if (!CanBeConsumed(DataHolder.Wizzard.CurrentIngridient.IngridientType)) return;
        //Debug.Log("CULDRON " + DataHolder.Wizzard.CurrentIngridient.IngridientType);
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
                    audioSource.Play();
                    Debug.Log("COOOKIIING");
                    
                    
                }
                else
                {
                    // missing ingrediets
                    Debug.Log("Missing ingredient");
                }
            }
            else
            {
                // make poop
                Debug.Log("Wrong recepy");
                GiveReadyIngridientPoop();
                
                RemoveRecepy();

            }
            DataHolder.Labaratory.RemoveIngridient();
        }
       
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
        bool IsOkCount = false;
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
    }


    private void OnMouseEnter()
    {
        IsMouseOver = true;
    }

    private void OnMouseExit()
    {
        IsMouseOver = false;
    }
}
