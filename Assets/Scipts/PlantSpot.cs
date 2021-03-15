using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpot : MonoBehaviour
{
    private bool onDirt = false;
    private SpriteRenderer plantSprite;
    public Color dirtColor;
    public Color carrotColor;
    public Color potatoColor;
    public Color beanColor;
    public enum PlantType
    {
        Carrot,
        Potato,
        Bean,
        Nothing
    };

    public string PREF_KEY_PLANT;
    private PlantType plant = PlantType.Nothing;

    private string prefString = "empty";
    public PlantType Plant
    {
        get
        {
            if (prefString == "empty")
            {
                prefString = PlayerPrefs.GetString(PREF_KEY_PLANT, "nothing");
                switch (prefString)
                {
                    case "carrot":
                        plant = PlantType.Carrot;
                        break;
                    case "potato":
                        plant = PlantType.Potato;
                        break;
                    case "bean":
                        plant = PlantType.Bean;
                        break;
                    case "nothing":
                        plant = PlantType.Nothing;
                        break;
                }
            }
            return plant;
        }
        set
        {
            plant = value;
            switch (plant)
            {
                case PlantType.Carrot:
                    prefString = "carrot";
                    break;
                case PlantType.Potato:
                    prefString = "potato";
                    break;
                case PlantType.Bean:
                    prefString = "bean";
                    break;
                case PlantType.Nothing:
                    prefString = "nothing";
                    break;
            }
            PlayerPrefs.SetString(PREF_KEY_PLANT, prefString);
        }
    }

    private void Start()
    {
        plantSprite = GetComponent<SpriteRenderer>();
        switch (Plant)
        {
            case PlantType.Carrot:
                plantSprite.color = carrotColor;
                break;
            case PlantType.Potato:
                plantSprite.color = potatoColor;
                break;
            case PlantType.Bean:
                plantSprite.color = beanColor;
                break;
            case PlantType.Nothing:
                plantSprite.color = dirtColor;
                break;
        }
    }

    private void Update()
    {
        if (onDirt)
        {
            switch (Plant)
            {
                case PlantType.Carrot:
                    plantSprite.color = carrotColor;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Inventory.instance.CarrotsInv++;
                        Plant = PlantType.Nothing;
                    }
                    break;
                case PlantType.Potato:
                    plantSprite.color = potatoColor;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Inventory.instance.PotatoesInv++;
                        Plant = PlantType.Nothing;
                    }
                    break;
                case PlantType.Bean:
                    plantSprite.color = beanColor;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Inventory.instance.BeansInv++;
                        Plant = PlantType.Nothing;
                    }
                    break;
                case PlantType.Nothing:
                    plantSprite.color = dirtColor;
                    if (Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        if (Inventory.instance.CarrotSeedsInv > 0)
                        {
                            
                            Inventory.instance.CarrotSeedsInv--;
                            Plant = PlantType.Carrot;
                        }
                    }
                    
                    if (Input.GetKeyDown(KeyCode.Alpha2))
                    {
                        if (Inventory.instance.PotatoSeedsInv > 0)
                        {
                            Inventory.instance.PotatoSeedsInv--;
                            Plant = PlantType.Potato; 
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha3))
                    {
                        if (Inventory.instance.BeanSeedsInv > 0)
                        {
                            Inventory.instance.BeanSeedsInv--;
                            Plant = PlantType.Bean;
                        }
                    }
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        onDirt = true;
        Debug.Log(onDirt);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onDirt = false;
        Debug.Log(onDirt);
    }
}
