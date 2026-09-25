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
        player1Move2.onClick.AddListener(Fireballrunner);
        player1Move3.onClick.AddListener(Thunderboltrunner);
        player1Move4.onClick.AddListener(Fireballrunner);


        player2Move1.onClick.AddListener(FatesGambitrunner);
        player2Move2.onClick.AddListener(Bountifulbonkrunner);
        player2Move3.onClick.AddListener(UltimateRagerunner);
        player2Move4.onClick.AddListener(UltimateRagerunner);

        player3Move1.onClick.AddListener(ChaosChaosrunner);
        player3Move2.onClick.AddListener(TeamHealrunner);
        player3Move3.onClick.AddListener(TeamBarrierrunner);
        player3Move4.onClick.AddListener(TeamHealrunner);



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

        
    }
    void ChaosChaosrunner()
    {
        turns.ChaosChaos();

       
    }
    void Fireballrunner()
    {
        turns.FireBall();
    }

    void Bountifulbonkrunner()
    {
        
        turns.bounterfulbonk();
    }

    void UltimateRagerunner()
    {
        turns.UltimateRage();
    }

    void TeamBarrierrunner()
    {
        turns.TeamBarrier();
    }

    void Thunderboltrunner()
    {
        turns.Thunderbolt();
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


        if(turns.player1currentmana < 30)
        {
            player1Move1.interactable = false;
        }
        else
        {
            player1Move1.interactable = true;
        }


        if (turns.player1currentmana < 10)
        {
            player1Move2.interactable = false;
        }
        else
        {
            player1Move2.interactable = true;
        }


        if (turns.player1currentmana < 20)
        {
            player1Move3.interactable = false;
        }
        else
        {
            player1Move3.interactable = true;
        }


        if (turns.player1currentmana < 25)
        {
            player1Move4.interactable = false;
        }
        else
        {
            player1Move4.interactable = true;
        }

        if(turns.isbossparalysed)
        {
            player2Move1.interactable = false;
        }
        else
        {
            if (turns.player2currentmana < -100)
            {
                player2Move1.interactable = false;
            }
            else
            {
                player2Move1.interactable = true;
            }
        }


        if (turns.player2currentmana < 15)
        {
            player2Move2.interactable = false;
        }
        else
        {
            player2Move2.interactable = true;
        }


        if (turns.player2currentmana < 10)
        {
            player2Move3.interactable = false;
        }
        else
        {
            player2Move3.interactable = true;
        }


        if (turns.player2currentmana < 50)
        {
            player2Move4.interactable = false;
        }
        else
        {
            player2Move4.interactable = true;
        }

        if (turns.player2currentmana < 5)
        {
            player3Move1.interactable = false;
        }
        else
        {
            player3Move1.interactable = true;
        }


        if (turns.player2currentmana < 20)
        {
            player3Move2.interactable = false;
        }
        else
        {
            player3Move2.interactable = true;
        }


        if (turns.player2currentmana < 10)
        {
            player3Move3.interactable = false;
        }
        else
        {
            player3Move3.interactable = true;
        }


        if (turns.player2currentmana < 40)
        {
            player3Move4.interactable = false;
        }
        else
        {
            player3Move4.interactable = true;
        }

    }

}
