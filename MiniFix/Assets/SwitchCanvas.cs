using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchCanvas : MonoBehaviour
{
    public GameObject canvasON;
    public GameObject canvasOFF;
    public GameObject firstSelectedObj;

    public void SwitchCanvasTupuz()
    {
        canvasOFF.SetActive(false);
        canvasON.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstSelectedObj, null);
    }
}
