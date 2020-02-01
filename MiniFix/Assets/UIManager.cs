using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    int health = 4;
    public GameObject heart;
    public GameObject hitPrefabs;
    public GameObject missPrefabs;
    public Vector3 parcticlePos;
    public RectTransform PlayerButtons;
    Animator heartAnimator;
    Vector3 startingPos;


    private void OnEnable() 
    {
        startingPos = PlayerButtons.anchoredPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        heartAnimator = heart.GetComponent<Animator>();
    }

    public void CorrectButton()
    {
        PlayerButtons.localPosition -= new Vector3(0, 95, 0);
        GameObject hitPrefab = Instantiate(hitPrefabs, parcticlePos, Quaternion.identity);
        Destroy(hitPrefab, 2f);
    }

    public void WrongButton()
    {
        PlayerButtons.localPosition += new Vector3(0, 95, 0);
        GameObject missPrefab = Instantiate(missPrefabs, parcticlePos, Quaternion.identity);
        Destroy(missPrefab, 2f);
        health--;
        if(health == 3)
        {
            heartAnimator.SetTrigger("h1IsBroken");
        }
        if(health == 2)
        {
            heartAnimator.SetTrigger("h2IsBroken");
        }
        if(health == 1)
        {
            heartAnimator.SetTrigger("h3IsBroken");
        }
        if(health == 0)
        {
            heartAnimator.SetTrigger("h4IsBroken");
        }
    }

    public void ResetPosition()
    {
        PlayerButtons.anchoredPosition = new Vector3 (startingPos.x, startingPos.y, startingPos.z);
    }
}
