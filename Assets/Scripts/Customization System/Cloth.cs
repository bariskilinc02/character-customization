using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth : MonoBehaviour
{
    public enum ClothType
    {
        Torso,
        Leg,
        Shoe,
        TopHead,
        Glass,
        Arm,
        Glove
    }
    public string clothId;
    public ClothType clothType;
}
