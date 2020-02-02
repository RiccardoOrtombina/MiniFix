using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class GManager : MonoBehaviour
{

    public GameObject winScreen;
    public GameObject firstSelectedObj;
    public TextMeshProUGUI winText;
    public InputStorage[] inputs;
    List<InputStorage> bottonissimi = new List<InputStorage>();
    public Player[] players;

    List<InputStorage> playerInputs1 = new List<InputStorage>();
    List<InputStorage> playerInputs2 = new List<InputStorage>();
    List<InputStorage> playerInputs3 = new List<InputStorage>();
    List<InputStorage> playerInputs4 = new List<InputStorage>();
    List<InputStorage> playerInputs5 = new List<InputStorage>();

    List<InputStorage> playerInputs1R2 = new List<InputStorage>();
    List<InputStorage> playerInputs2R2 = new List<InputStorage>();
    List<InputStorage> playerInputs3R2 = new List<InputStorage>();
    List<InputStorage> playerInputs4R2 = new List<InputStorage>();
    List<InputStorage> playerInputs5R2 = new List<InputStorage>();

    List<InputStorage> playerInputs1R3 = new List<InputStorage>();
    List<InputStorage> playerInputs2R3 = new List<InputStorage>();
    List<InputStorage> playerInputs3R3 = new List<InputStorage>();
    List<InputStorage> playerInputs4R3 = new List<InputStorage>();
    List<InputStorage> playerInputs5R3 = new List<InputStorage>();

    void OnEnable()
    {
        GenerateRound1Lists();
        GenerateOtherLists();
        SetPlayersLists();

        foreach(InputStorage input in inputs)
        {
            bottonissimi.Add(input);
        }

        foreach(Player amico in players)
        {
            amico.SetListoneBruttone(bottonissimi, this);
        }
    }

    void GenerateRound1Lists()
    {
        for(int i = 0; i < 20; i++)
        {
            int rng = Random.Range(0, 4);
            playerInputs1.Add(inputs[rng]);
        }

        for (int i = 0; i < 20; i++)
        {
            int rng = Random.Range(0, 8);
            playerInputs2.Add(inputs[rng]);
        }

        for (int i = 0; i < 20; i++)
        {
            int rng = Random.Range(0, 10);
            playerInputs3.Add(inputs[rng]);
        }

        for (int i = 0; i < 20; i++)
        {
            int rng = Random.Range(0, 12);
            playerInputs4.Add(inputs[rng]);
        }

        for (int i = 0; i < 20; i++)
        {
            int rng = Random.Range(0, 14);
            playerInputs5.Add(inputs[rng]);
        }
    }

    void GenerateOtherLists()
    {
        for (int i = 0; i < 20; i++)
        {
            int rng = Random.Range(0, 14);
            playerInputs1R2.Add(inputs[rng]);
            rng = Random.Range(0, 14);
            playerInputs2R2.Add(inputs[rng]);
            rng = Random.Range(0, 14);
            playerInputs3R2.Add(inputs[rng]);
            rng = Random.Range(0, 14);
            playerInputs4R2.Add(inputs[rng]);
            rng = Random.Range(0, 14);
            playerInputs5R2.Add(inputs[rng]);
            rng = Random.Range(0, 14);
            playerInputs1R3.Add(inputs[rng]);
            rng = Random.Range(0, 14);
            playerInputs2R3.Add(inputs[rng]);
            rng = Random.Range(0, 14);
            playerInputs3R3.Add(inputs[rng]);
            rng = Random.Range(0, 14);
            playerInputs4R3.Add(inputs[rng]);
            rng = Random.Range(0, 14);
            playerInputs5R3.Add(inputs[rng]);
        }
    }

    void SetPlayersLists()
    {
        foreach(Player player in players)
        {
            foreach(InputStorage input in playerInputs1)
            {
                player.playerInputs1.Add(input);
            }
            player.playerInputs2 = playerInputs2;
            player.playerInputs3 = playerInputs3;
            player.playerInputs4 = playerInputs4;
            player.playerInputs5 = playerInputs5;

            player.playerInputs1R2 = playerInputs1R2;
            player.playerInputs2R2 = playerInputs2R2;
            player.playerInputs3R2 = playerInputs3R2;
            player.playerInputs4R2 = playerInputs4R2;
            player.playerInputs5R2 = playerInputs5R2;

            player.playerInputs1R3 = playerInputs1R3;
            player.playerInputs2R3 = playerInputs2R3;
            player.playerInputs3R3 = playerInputs3R3;
            player.playerInputs4R3 = playerInputs4R3;
            player.playerInputs5R3 = playerInputs5R3;
        }
    }

    public void Win(string numerottoPersonaGiocante)
    {
        foreach(Player player in players)
        {
            player.gooooooooooo = false;
        }
    
        if (numerottoPersonaGiocante == "1")
        {
            winText.text = "TEAM ORANGE ARE THE BEST FIXERS";
        }
        else
        {
            winText.text = "TEAM BLUE ARE THE BEST FIXERS";
        }
        winScreen.SetActive(true);
        GameObject.Find ("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstSelectedObj, null);
        Debug.Log("Player " + numerottoPersonaGiocante + " vince");
    }

    public void PlayerSuspended(Player callingPlayer)
    {
        if(players[0].isSuspended == true && players[0].points < players[1].points)
        {
            Win(players[1].numeraccioGiocatore);
        }

        else if(players[1].isSuspended == true && players[1].points < players[0].points)
        {
            Win(players[0].numeraccioGiocatore);
        }

        foreach(Player plplpl in players)
        {
            if(plplpl.isSuspended == false)
            {
                return;
            }
        }

        if (players[0].points > players[1].points)
        {
            Win(players[0].numeraccioGiocatore);
        }

        else if (players[1].points > players[0].points)
        {
            Win(players[1].numeraccioGiocatore);
        }

        else
        {
            foreach(Player player in players)
            {
                if(player != callingPlayer)
                {
                    Win(player.numeraccioGiocatore);
                    return;
                }
            }
        }
    }
}
