using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{

    public PlantObject plant;

    public Text NameTxt;
    public Text PriceText;
    public Image Icon;

    FarmManager fm;

    void Start()
    {
        fm = FindObjectOfType<FarmManager>();
        InitializeUI();
    }

    public void BuyPlant()
    {
        Debug.Log("Bought " + plant.PlantName);
        fm.SelectPlant(this);
    }

    void InitializeUI()
    {
        NameTxt.text = plant.PlantName;
        PriceText.text = "$" + plant.price;
        Icon.sprite = plant.icon;
    }



}
