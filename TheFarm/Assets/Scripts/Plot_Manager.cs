using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot_Manager : MonoBehaviour
{

    bool isPlanted = false;
    SpriteRenderer plant;
    BoxCollider2D plantcollider;

    public Sprite[] plantStages;
    int plantStage = 0;
    float timeStages = 2f;
    float timer;

    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantcollider = transform.GetChild(0).GetComponent<BoxCollider2D>();

    }

    void Update()
    {
       if(isPlanted)
        {
            timer -= Time.deltaTime;
            
            if(timer<0 && plantStage<plantStages.Length-1)
            {
                timer = timeStages;
                plantStage++;
                uptadePlant();
            }
        }
    }


    private void OnMouseDown()
    {
        if(isPlanted)
        {
            if(plantStage == plantStages.Length - 1)
            {
                Harvest();
            }
            
        }
        else
        {
            Plant();
        }
    }

    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    void Plant()
    {
        Debug.Log("Planted");
        isPlanted = true;
        plantStage = 0;
        uptadePlant();
        timer = timeStages;
        plant.gameObject.SetActive(true);
    }

    void uptadePlant()
    {
        plant.sprite = plantStages[plantStage];
        plantcollider.size = plant.sprite.bounds.size;
        plantcollider.offset = new Vector2(0,plant.bounds.size.y/2);
    }




}
