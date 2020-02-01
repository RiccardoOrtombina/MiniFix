using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public RectTransform PlayerButtons;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void CorrectButton()
    {
        PlayerButtons.localPosition -= new Vector3(0, 95, 0);
    }

    public void WrongButton()
    {
        PlayerButtons.localPosition += new Vector3(0, 95, 0);
    }
}
