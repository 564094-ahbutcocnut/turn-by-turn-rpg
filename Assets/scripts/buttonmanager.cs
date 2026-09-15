using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buttonmanager : MonoBehaviour
{
    [Header("Player1")]
    [SerializeField] GameObject Player1Moves;
    [SerializeField] Button player1Move1;
    [SerializeField] Button player1Move2;
    [SerializeField] Button player1Move3;
    [SerializeField] Button player1Move4;

    [Header("Player2")]
    [SerializeField] GameObject Player2Moves;
    [SerializeField] Button player2Move1;
    [SerializeField] Button player2Move2;
    [SerializeField] Button player2Move3;
    [SerializeField] Button player2Move4;

    [Header("Player3")]
    [SerializeField] GameObject Player3Moves;
    [SerializeField] Button player3Move1;
    [SerializeField] Button player3Move2;
    [SerializeField] Button player3Move3;
    [SerializeField] Button player3Move4;




    [SerializeField] Turns turns;



    void Start()
    {
        player1Move1.onClick.AddListener(blackholerunner);
        player1Move2.onClick.AddListener(blackholerunner);
        player1Move3.onClick.AddListener(blackholerunner);
        player1Move4.onClick.AddListener(blackholerunner);


        player2Move1.onClick.AddListener(blackholerunner);
        player2Move2.onClick.AddListener(blackholerunner);
        player2Move3.onClick.AddListener(blackholerunner);
        player2Move4.onClick.AddListener(blackholerunner);



    }

    void blackholerunner()
    {
        turns.Blackhole();        
    }

    void Update()
    {
        if (turns.currentturn == "Player1")
        {
            Player1Moves.SetActive(true);
        }
        if (turns.currentturn != "Player1")
        {
            Player1Moves.SetActive(false);
        }
        if (turns.currentturn == "Player2")
        {
            Player2Moves.SetActive(true);
        }
        if (turns.currentturn != "Player2")
        {
            Player2Moves.SetActive(false);
        }



    }

}
