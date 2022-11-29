using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot_Manager : MonoBehaviour
{

    bool isPlanted = false;
    SpriteRenderer plant;
    BoxCollider2D plantcollider;

    int plantStage = 0;
    float timer;

    public Color availableColor = Color.green;
    public Color unavaibleColor = Color.red;

    SpriteRenderer plot;

    PlantObject selectedPlant;
    FarmManager fm;

    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantcollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        fm = transform.parent.GetComponent<FarmManager>();
        plot = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
       if(isPlanted)
        {
            timer -= Time.deltaTime;
            
            if(timer<0 && plantStage<selectedPlant.plantStages.Length-1)
            {
                timer = selectedPlant.timeStages;
                plantStage++;
                uptadePlant();
            }
        }
    }


    private void OnMouseDown()
    {
        if(isPlanted)
        {
            if(plantStage == selectedPlant.plantStages.Length - 1 && !fm.isPlanting)
            {
                Harvest();
            }
            
        }
        else if(fm.isPlanting && fm.selectPlant.plant.BuyPrice <= fm.money)
        {
            Plant(fm.selectPlant.plant);
        }
    }

    private void OnMouseOver()
    {
        if(fm.isPlanting)
        {
            if(isPlanted || fm.selectPlant.plant.BuyPrice > fm.money)
            {
                //can't buy
                plot.color = unavaibleColor;
            }
            else
            {
                //can buy
                plot.color = availableColor;
            }
        }
    }

    private void OnMouseExit()
    {
        plot.color = Color.white;
    }

    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
        fm.Transaction(selectedPlant.SellPrice);

    }

    void Plant(PlantObject newPlant)
    {
        selectedPlant = newPlant;
        Debug.Log("Planted");
        isPlanted = true;
        fm.Transaction(-selectedPlant.BuyPrice);
        plantStage = 0;
        uptadePlant();
        timer = selectedPlant.timeStages;
        plant.gameObject.SetActive(true);
    }

    void uptadePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantStage];
        plantcollider.size = plant.sprite.bounds.size;
        plantcollider.offset = new Vector2(0,plant.bounds.size.y/2);
    }




}
