﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Plant",menuName ="Plant")]
public class PlantObject : ScriptableObject
{

    public string PlantName;
    public Sprite[] plantStages;
    public float timeStages;
    public int price;
    public Sprite icon;
}
