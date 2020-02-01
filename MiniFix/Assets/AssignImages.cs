using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignImages : MonoBehaviour
{
    public List<InputStorage> inputStorages;
    public List<Sprite> buttonImages = new List<Sprite>();
    public Image[] buttons;
    UIManager uIManager;

    private void OnEnable() 
    {
        
    }
    public void RefreshButtonList(List<InputStorage> buttonImagesList)
    {
        buttonImages.Clear();
        foreach (InputStorage buttonImagesL in buttonImagesList)
        {
            buttonImages.Add(buttonImagesL.inputImage);
        }

        AssignImagesToButton();
        
        GetComponent<UIManager>().ResetPosition();

    }

    public void AssignImagesToButton()
    {
        foreach (InputStorage inputStorage in inputStorages)
        {
            buttonImages.Add(inputStorage.inputImage);
        }

        int index = 0;

        foreach (Image button in buttons)
        {
            button.sprite = buttonImages[index];
            index++;
        }
    }
}
