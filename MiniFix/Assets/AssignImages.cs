using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignImages : MonoBehaviour
{
    public List<InputStorage> inputStorages;
    List<Sprite> buttonImages;

    public Image[] buttons;

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
