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

    PlantObject selectedPlant;
    FarmManager fm;

    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantcollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        fm = transform.parent.GetComponent<FarmManager>();
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
            if(plantStage == selectedPlant.plantStages.Length - 1)
            {
                Harvest();
            }
            
        }
        else if(fm.isPlanting)
        {
            Plant(fm.selectPlant.plant);
        }
    }

    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    void Plant(PlantObject newPlant)
    {
        selectedPlant = newPlant;
        Debug.Log("Planted");
        isPlanted = true;
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
