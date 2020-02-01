using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InputStorage 
{
    public string inputName;
    [Range(-1 , 1)]
    public int inputType;
    public Sprite inputImage;
}
