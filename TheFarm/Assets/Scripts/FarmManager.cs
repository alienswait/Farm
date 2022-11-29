using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{

    public PlantItem selectPlant;
    public bool isPlanting = false;


    void Start()
    {

    }

    void Update()
    {

    }

    public void SelectPlant(PlantItem newPlant)
    {
        if (selectPlant == newPlant)
        {
            Debug.Log("Deselected " + selectPlant.plant.PlantName);
            selectPlant = null;
            isPlanting = false;
        }
        else
        {
            selectPlant = newPlant;
            Debug.Log("Selected " + selectPlant.plant.PlantName);
            isPlanting = true;
        }
        
    }
}
