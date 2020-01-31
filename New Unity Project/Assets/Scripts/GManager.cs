using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    InputStorage[] inputs;

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
    }

    void GenerateRound1Lists()
    {
        for(int i = 0; i <= 20; i++)
        {
            int rng = Random.Range(0, 5);
            playerInputs1.Add(inputs[rng]);
        }

        for (int i = 0; i <= 20; i++)
        {
            int rng = Random.Range(0, 9);
            playerInputs2.Add(inputs[rng]);
        }

        for (int i = 0; i <= 20; i++)
        {
            int rng = Random.Range(0, 11);
            playerInputs3.Add(inputs[rng]);
        }

        for (int i = 0; i <= 20; i++)
        {
            int rng = Random.Range(0, 13);
            playerInputs4.Add(inputs[rng]);
        }

        for (int i = 0; i <= 20; i++)
        {
            int rng = Random.Range(0, 15);
            playerInputs5.Add(inputs[rng]);
        }
    }

    void GenerateOtherLists()
    {
        for (int i = 0; i <= 20; i++)
        {
            int rng = Random.Range(0, 15);
            playerInputs1R2.Add(inputs[rng]);
            rng = Random.Range(0, 15);
            playerInputs2R2.Add(inputs[rng]);
            rng = Random.Range(0, 15);
            playerInputs3R2.Add(inputs[rng]);
            rng = Random.Range(0, 15);
            playerInputs4R2.Add(inputs[rng]);
            rng = Random.Range(0, 15);
            playerInputs5R2.Add(inputs[rng]);
            rng = Random.Range(0, 15);
            playerInputs1R3.Add(inputs[rng]);
            rng = Random.Range(0, 15);
            playerInputs2R3.Add(inputs[rng]);
            rng = Random.Range(0, 15);
            playerInputs3R3.Add(inputs[rng]);
            rng = Random.Range(0, 15);
            playerInputs4R3.Add(inputs[rng]);
            rng = Random.Range(0, 15);
            playerInputs5R3.Add(inputs[rng]);
        }
    }

}
