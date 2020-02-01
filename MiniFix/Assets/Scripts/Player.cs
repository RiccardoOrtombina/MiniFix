﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AssignImages))]
public class Player : MonoBehaviour
{
    public bool gooooooooooo = false;
    public string numeraccioGiocatore;
    bool axisPressed;

    public float currentTime;
    public float timeReset;
    int rounds = 0;

    AssignImages ImagesList;
    UIManager UIManager;
    
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

    private void OnEnable()
    {
        ImagesList = GetComponent<AssignImages>();
        UIManager = GetComponent<UIManager>();
        currentTime = timeReset;
    }

    public void SetListoneBruttone(List<InputStorage> iBottoniFannoMale)
    {
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
        ImagesList.RefreshButtonList(listinaBruttina);
        rounds += 1;
        if(rounds > 5)
        {
            timeReset -= 1;
        }
        gooooooooooo = true;
    }

    // Update is called once per frame
    void Update()
    {
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

            currentTime -= Time.deltaTime;
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
        if(indexListinaBruttina < 19)
        {
            indexListinaBruttina += 1;
            UIManager.CorrectButton();
            gooooooooooo = true;
        }

        else if(indexListinaBruttina == 19)
        {
            indexListoneBruttone += 1;
            SetCurrentListina();
        }
    }

    void InputtoneSbagliatone()
    {
        Debug.Log("Sbagliatino");
        gooooooooooo = false;
        currentTime = timeReset;
        axisPressed = true;
        if(indexListinaBruttina == 0)
        {
            gooooooooooo = true;
        }

        else if(indexListinaBruttina > 0)
        {
            UIManager.WrongButton();
            indexListinaBruttina -= 1;
            gooooooooooo = true;
        }
    }
}
