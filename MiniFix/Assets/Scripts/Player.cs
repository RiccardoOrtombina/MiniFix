using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerNumber;
    public bool gooooooooooo = false;

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

    List<List<InputStorage>> listoneBruttone = new List<List<InputStorage>>();

    int indexListoneBruttone = 0;
    int indexListinaBruttina = 0;

    List<InputStorage> bottonozzi;
    List<InputStorage> listinaBruttina = new List<InputStorage>();
    List<InputStorage> inputtiniSbagliatini = new List<InputStorage>();

    public void SetListoneBruttone(List<InputStorage> iBottoniFannoMale)
    {
        bottonozzi = iBottoniFannoMale;

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

        string numeraccioGiocatore = playerNumber.ToString();

        foreach(List<InputStorage> listina in listoneBruttone)
        {
            foreach(InputStorage tastoneDaPremerone in listina)
            {
                tastoneDaPremerone.inputName += numeraccioGiocatore;
            }
        }

        SetCurrentListina();
    }

    void SetCurrentListina()
    {
        listinaBruttina = listoneBruttone[indexListoneBruttone];
        indexListinaBruttina = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gooooooooooo == true)
        {
            if(listinaBruttina[indexListinaBruttina].inputType == 0)
            {
                if (Input.GetButtonDown(listinaBruttina[indexListinaBruttina].inputName))
                {

                }

                else if (Input.)
            }
        }
    }
}
