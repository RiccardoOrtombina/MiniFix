using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter : MonoBehaviour
{
    RectTransform rectTransform;
    int counter;

    public void RotateMeter(string numerodelplayerfinbulante)
    {
        if(numerodelplayerfinbulante == "1" && counter > -90)
        {
            rectTransform = this.gameObject.GetComponent<RectTransform>();
            rectTransform.localEulerAngles -= new Vector3(0, 0, 1);
            counter -= 1;
        }
        else if(numerodelplayerfinbulante == "2" && counter < 90)
        {
            rectTransform = this.gameObject.GetComponent<RectTransform>();
            rectTransform.localEulerAngles += new Vector3(0, 0, 1);
            counter += 1;
        }
    }
}
