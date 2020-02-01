using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image slider;
    Meter meter;
    public AudioClip[] correctButtonSounds;
    public AudioClip[] wrongButtonSounds;

    public AudioSource audioSource;
    int health = 4;
    public GameObject heart;
    public GameObject hitPrefabs;
    public GameObject missPrefabs;
    public Vector3 parcticlePos;
    public RectTransform PlayerButtons;
    Animator heartAnimator;
    public Vector3 startingPos;
    Player player;

    private void Update() 
    {
        slider.fillAmount = player.currentTime/player.timeReset;
    }
    private void OnEnable() 
    {
        //startingPos = PlayerButtons.anchoredPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        meter = FindObjectOfType<Meter>();
        heartAnimator = heart.GetComponent<Animator>();
    }

    public void CorrectButton()
    {
        PlayerButtons.localPosition -= new Vector3(0, 95, 0);
        GameObject hitPrefab = Instantiate(hitPrefabs, parcticlePos, Quaternion.identity);
        Destroy(hitPrefab, 2f);
        audioSource.clip = correctButtonSounds[Random.Range(0, correctButtonSounds.Length)];
        audioSource.PlayOneShot(audioSource.clip);
        meter.RotateMeter();
    }

    public void WrongButton(int index)
    {
        if (index != 0)
        {
            PlayerButtons.localPosition += new Vector3(0, 95, 0);
        }

        GameObject missPrefabInd = Instantiate(missPrefabs, parcticlePos, Quaternion.identity);
        Destroy(missPrefabInd, 2f);
        audioSource.clip = wrongButtonSounds[Random.Range(0, wrongButtonSounds.Length)];
        audioSource.PlayOneShot(audioSource.clip);
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
        PlayerButtons.anchoredPosition = startingPos;
    }
}
