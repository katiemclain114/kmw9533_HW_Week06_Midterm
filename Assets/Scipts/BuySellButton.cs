using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySellButton : MonoBehaviour
{
    //change inventory bases on what enum you select 
    public enum PlantType
    {
        Carrot,
        Potato,
        Bean
    };
    public PlantType plant;
    
    // subtract money but add seed
    public void BuyPlant()
    {
        switch (plant)
        {
            case PlantType.Carrot:
                if (GameManager.instance.Money > 0)
                {
                    Inventory.instance.CarrotSeedsInv++;
                    GameManager.instance.Money--;
                }
                break;
            case PlantType.Potato:
                if (GameManager.instance.Money > 0)
                {
                    Inventory.instance.PotatoSeedsInv++;
                    GameManager.instance.Money--;
                }
                break;
            case PlantType.Bean:
                if (GameManager.instance.Money > 0)
                {
                    Inventory.instance.BeanSeedsInv++;
                    GameManager.instance.Money--;
                }
                break;
        }
    }

    //add money but subtract plant
    public void SellPlant()
    {
        switch (plant)
        {
            case PlantType.Carrot:
                if (Inventory.instance.CarrotsInv > 0)
                {
                    Inventory.instance.CarrotsInv--;
                    GameManager.instance.Money++;
                }
                break;
            case PlantType.Potato:
                if (Inventory.instance.PotatoesInv > 0)
                {
                    Inventory.instance.PotatoesInv--;
                    GameManager.instance.Money++;
                }
                break;
            case PlantType.Bean:
                if (Inventory.instance.BeansInv > 0)
                {
                    Inventory.instance.BeansInv--;
                    GameManager.instance.Money++;
                }
                break;
        }
    }
}
