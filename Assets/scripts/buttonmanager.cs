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
        player1Move2.onClick.AddListener(TeamHealrunner);
        player1Move3.onClick.AddListener(FatesGambitrunner);
        player1Move4.onClick.AddListener(ChaosChaosrunner);


        player2Move1.onClick.AddListener(Doitagainrunner);
        player2Move2.onClick.AddListener(FatesGambitrunner);
        player2Move3.onClick.AddListener(FatesGambitrunner);
        player2Move4.onClick.AddListener(FatesGambitrunner);

        player3Move1.onClick.AddListener(blackholerunner);
        player3Move2.onClick.AddListener(ChaosChaosrunner);
        player3Move3.onClick.AddListener(blackholerunner);
        player3Move4.onClick.AddListener(blackholerunner);



    }

    void blackholerunner()
    {
        turns.Blackhole();

       
    }
    void TeamHealrunner()
    {
        turns.TeamHeal();

       
    }
    void FatesGambitrunner()
    {
        turns.FatesGambit();

        ;
    }
    void ChaosChaosrunner()
    {
        turns.ChaosChaos();

       
    }
    void Doitagainrunner()
    {
        turns.Doitagain();

        
    }
    void Fireballrunner()
    {
        turns.FireBall();
    }




    void Update()
    {
        if (turns.currentturn == "Boss")
        {
            Player1Moves.SetActive(false);
            Player2Moves.SetActive(false);
        }
        if (turns.currentturn == "Player1")
        {
            Player1Moves.SetActive(true);
        }
        if (turns.currentturn != "Player1")
        {
            Player1Moves.SetActive(false);
        }
        if(turns.player1dead == true && turns.currentturn == "Player1")
        {
            Player1Moves.SetActive(false);
            turns.currentturn = "Player2";
        }
        if (turns.currentturn == "Player2")
        {
            Player2Moves.SetActive(true);
        }
        if (turns.currentturn != "Player2")
        {
            Player2Moves.SetActive(false);
        }
        if (turns.player2dead == true && turns.currentturn == "Player2")
        {
            Player2Moves.SetActive(false);
            turns.currentturn = "Player3";
        }
        if(turns.currentturn == "Player3")
        {
            Player3Moves.SetActive(true);
        }
        if(turns.currentturn != "Player3")
        {
            Player3Moves.SetActive(false);
        }
        if(turns.player3dead == true && turns.currentturn == "Player3")
        {
            Player3Moves.SetActive(false);
            turns.currentturn = "Boss";
        }




    }

}
