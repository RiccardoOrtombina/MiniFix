using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AssignImages))]
public class Player : MonoBehaviour
{
    public GameObject[] sfondonissimacciucci;
    int sfondinoIndexino = -1;
    GameObject currentSfondissimo;

    public bool gooooooooooo = false;
    public bool isSuspended = false;
    public string numeraccioGiocatore;
    bool axisPressed;

    public float currentTime;
    public float timeReset = 4;
    int rounds = 0;

    public int points = 0;
    public int lives = 4;

    AssignImages ImagesList;
    UIManager UIManager;
    GManager gameManager;
    
    public List<InputStorage> playerInputs1 = new List<InputStorage>();
    public List<InputStorage> playerInputs2 = new List<InputStorage>();
    public List<InputStorage> playerInputs3 = new List<InputStorage>();
    public List<InputStorage> playerInputs4 = new List<InputStorage>();
    public List<InputStorage> playerInputs5 = new List<InputStorage>();

    public List<InputStorage> playerInputs1R2 = new List<InputStorage>();
    public List<InputStorage> playerInputs2R2 = new List<InputStorage>();
    public List<InputStorage> playerInputs3R2 = new List<InputStorage>();
    public List<InputStorage> playerInputs4R2 = new List<InputStorage>();
    public List<InputStorage> playerInputs5R2 = new List<InputStorage>();

    public List<InputStorage> playerInputs1R3 = new List<InputStorage>();
    public List<InputStorage> playerInputs2R3 = new List<InputStorage>();
    public List<InputStorage> playerInputs3R3 = new List<InputStorage>();
    public List<InputStorage> playerInputs4R3 = new List<InputStorage>();
    public List<InputStorage> playerInputs5R3 = new List<InputStorage>();

    public List<List<InputStorage>> listoneBruttone = new List<List<InputStorage>>();

    int indexListoneBruttone = 0;
    int indexListinaBruttina = 0;

    List<InputStorage> bottonozzi = new List<InputStorage>();
    List<InputStorage> listinaBruttina = new List<InputStorage>();

    IEnumerator changeSceneTimer()
    {
        float timer = 1;
        yield return new WaitForSeconds(timer);
        SetCurrentListina();
    }

    private void Start()
    {       
        UIManager = GetComponent<UIManager>();
        currentTime = timeReset;
        ImagesList = GetComponent<AssignImages>();
    }

    public void SetListoneBruttone(List<InputStorage> iBottoniFannoMale, GManager manager)
    {
        gameManager = manager;

        foreach(InputStorage bottone in iBottoniFannoMale)
        {
            bottonozzi.Add(bottone);
        }

        listoneBruttone.Add(playerInputs1);
        listoneBruttone.Add(playerInputs2);
        listoneBruttone.Add(playerInputs3);
        listoneBruttone.Add(playerInputs4);
        listoneBruttone.Add(playerInputs5);

        listoneBruttone.Add(playerInputs1R2);
        listoneBruttone.Add(playerInputs2R2);
        listoneBruttone.Add(playerInputs3R2);
        listoneBruttone.Add(playerInputs4R2);
        listoneBruttone.Add(playerInputs5R2);

        listoneBruttone.Add(playerInputs1R3);
        listoneBruttone.Add(playerInputs2R3);
        listoneBruttone.Add(playerInputs3R3);
        listoneBruttone.Add(playerInputs4R3);
        listoneBruttone.Add(playerInputs5R3);

        SetCurrentListina();
    }

    void SetCurrentListina()
    {
        listinaBruttina = listoneBruttone[indexListoneBruttone];
        indexListinaBruttina = 0;
        GetComponent<AssignImages>().RefreshButtonList(listinaBruttina);

        if (currentSfondissimo != null)
        {
            currentSfondissimo.SetActive(false);
        }

        if (sfondinoIndexino < sfondonissimacciucci.Length - 1)
        {
            sfondinoIndexino += 1;
        }
        else sfondinoIndexino = 0;

        currentSfondissimo = sfondonissimacciucci[sfondinoIndexino];
        currentSfondissimo.SetActive(true);

        //CambiaSfondino();
        rounds += 1;
        if(rounds > 5)
        {
            timeReset = 2f;
        }

        if(rounds > 10)
        {
            timeReset = 1;
        }

        if(rounds > 15)
        {
            gameManager.Win(numeraccioGiocatore);
        }

        gooooooooooo = true;
    }

    void CambiaSfondino()
    {
        if (currentSfondissimo != null)
        {
            currentSfondissimo.SetActive(false);
        }

        if (sfondinoIndexino < sfondonissimacciucci.Length - 1)
        {
            sfondinoIndexino += 1;
        }
        else sfondinoIndexino = 0;

        currentSfondissimo = sfondonissimacciucci[sfondinoIndexino];
        currentSfondissimo.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(isSuspended == true)
        {
            gooooooooooo = false;
        }

        if (gooooooooooo == true)
        {
            if(axisPressed == true)
            {
                if(Input.GetAxisRaw("CrossVertical" + numeraccioGiocatore) == 0 &&
                   Input.GetAxisRaw("CrossHorizontal" + numeraccioGiocatore) == 0 &&
                   Input.GetAxisRaw("Triggers" + numeraccioGiocatore) == 0
                  )
                {
                    axisPressed = false;
                }
            }

            if(currentTime <= 0)
            {
                InputtoneSbagliatone();
                currentTime = timeReset;
            }

            if(listinaBruttina[indexListinaBruttina].inputType == 0)
            {
                if (Input.GetButtonDown(listinaBruttina[indexListinaBruttina].inputName + numeraccioGiocatore))
                {
                    InputtinoGiustino();
                }

                else
                {
                    ControllaInputtozziSbagliati();
                }
                
            }

            else if (listinaBruttina[indexListinaBruttina].inputType != 0 && axisPressed == false)
            {
                if (Input.GetAxisRaw(listinaBruttina[indexListinaBruttina].inputName + numeraccioGiocatore) == listinaBruttina[indexListinaBruttina].inputType)
                {
                    InputtinoGiustino();                   
                }

                else
                {
                    ControllaInputtozziSbagliati();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(gooooooooooo == true)
        {
            currentTime -= 0.02f;
        }
    }

    void ControllaInputtozziSbagliati()
    {
        foreach (InputStorage sp00ky in bottonozzi)
        {
            if (sp00ky.inputName != listinaBruttina[indexListinaBruttina].inputName)
            {
                if (sp00ky.inputType == 0)
                {
                    if (Input.GetButtonDown(sp00ky.inputName + numeraccioGiocatore))
                    {
                        InputtoneSbagliatone();
                    }
                }                
            }

            if (sp00ky.inputType != 0 && axisPressed == false)
            {
                if (Input.GetAxisRaw(sp00ky.inputName + numeraccioGiocatore) != 0)
                {
                    if(Input.GetAxisRaw(sp00ky.inputName + numeraccioGiocatore) != listinaBruttina[indexListinaBruttina].inputType)
                    {
                        InputtoneSbagliatone();
                    }
                    
                }
            }
        }
    }

    void InputtinoGiustino()
    {
        Debug.Log("Giustino");
        gooooooooooo = false;
        currentTime = timeReset;
        axisPressed = true;
        points++;
        if(indexListinaBruttina < 19)
        {
            indexListinaBruttina += 1;
            UIManager.CorrectButton();
            gooooooooooo = true;
        }

        else if(indexListinaBruttina == 19)
        {
            indexListoneBruttone += 1;
            StartCoroutine(changeSceneTimer());
        }
    }

    void InputtoneSbagliatone()
    {
        Debug.Log("Sbagliatino");
        gooooooooooo = false;

        lives -= 1;

        if(lives <= 0)
        {
            UIManager.WrongButton(indexListinaBruttina);
            YouLost();
            return;
        }
        currentTime = timeReset;
        axisPressed = true;
        if(indexListinaBruttina == 0)
        {
            UIManager.WrongButton(indexListinaBruttina);
            gooooooooooo = true;
        }

        else if(indexListinaBruttina > 0)
        {
            UIManager.WrongButton(indexListinaBruttina);
            indexListinaBruttina -= 1;
            gooooooooooo = true;
        }
    }

    void YouLost()
    {
        Debug.Log("Sei stato sospeso");
        isSuspended = true;
        gameManager.PlayerSuspended(this);
    }
}
