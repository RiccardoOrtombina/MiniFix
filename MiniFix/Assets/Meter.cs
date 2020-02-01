using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter : MonoBehaviour
{
    RectTransform rectTransform;

    public void RotateMeter()
    {
        rectTransform = this.gameObject.GetComponent<RectTransform>();
        rectTransform.localEulerAngles += new Vector3(0, 0, 1);
    }
}
