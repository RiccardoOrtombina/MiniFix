using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    int health = 4;
    public GameObject[] heart;
    public GameObject hitPrefabs;
    public GameObject missPrefabs;
    public Vector3 parcticlePos;
    public RectTransform PlayerButtons;
    Animator[] heartAnimator;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            heartAnimator[i] = heart[i].GetComponent<Animator>();
        }
    }

    public void CorrectButton()
    {
        PlayerButtons.localPosition -= new Vector3(0, 95, 0);
        GameObject hitPrefab = Instantiate(hitPrefabs, parcticlePos, Quaternion.identity);
        Destroy(hitPrefab, 2f);
    }

    public void WrongButton()
    {
        health--;
        heartAnimator[health+1].SetBool("isBroken", true);
        PlayerButtons.localPosition += new Vector3(0, 95, 0);
        GameObject missPrefab = Instantiate(missPrefabs, parcticlePos, Quaternion.identity);
        Destroy(missPrefab, 2f);
    }
}
