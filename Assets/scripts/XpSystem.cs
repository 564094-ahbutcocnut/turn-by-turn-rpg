using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class XpSystem : MonoBehaviour
{
    [Header("Other Scripts")]
    [SerializeField] Turns turns;
    [SerializeField] enemies enemy;
    [SerializeField] RandonEncounters randomencounter;



    [Header("EXP")]

    public int currentxp = 0;
    public int grantedxp;
    public int playerlevel = 1;
    public int PlayerExpToLevelUp = 1;

    public bool hasgivenxp;

    private void Start()
    {
        
    }

    private void Update()
    {
        PlayerExpToLevelUp = 1000 * playerlevel / 10;

        if(PlayerExpToLevelUp <= currentxp)
        {
            playerlevel++;
            
            turns.player1maxhealth = turns.player1maxhealth/10 + turns.player1maxhealth;
            turns.player1currenthealth = turns.player1maxhealth;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            turns.player2maxthealth = turns.player2maxthealth / 10 + turns.player2maxthealth;
            turns.player2currenthealth = turns.player2maxthealth;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            turns.player3maxhealth = turns.player3maxhealth / 10 + turns.player3maxhealth;
            turns.player3currenthealth = turns.player3maxhealth;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;


            turns.player1maxmana = (turns.player1maxmana / 100 * 2) + turns.player1maxmana;
            turns.player1currentmana = turns.player1maxmana;
            turns.Player1mana.text = turns.player1currentmana.ToString() + "/" + turns.player1maxmana;
            turns.player2maxmana = (turns.player2maxmana / 100 * 2) + turns.player2maxmana;
            turns.player2currentmana = turns.player2maxmana;
            turns.Player2mana.text = turns.player2currentmana.ToString() + "/" + turns.player2maxmana;
            turns.player3maxmana = (turns.player3maxmana / 100 * 2) + turns.player3maxmana;
            turns.player3currentmana = turns.player3maxmana;
            turns.Player3mana.text = turns.player3currentmana.ToString() + "/" + turns.player3maxmana;


            currentxp = 0;

        }
    }

    public void XPuponwinning()
    {
        if(hasgivenxp == false)
        {

            if (randomencounter.currentenemy == "Goblin")
            {
                grantedxp = 25;
                currentxp += 25;
                hasgivenxp = true; 
            }
            if (randomencounter.currentenemy == "Rocky")
            {
                grantedxp = 35;
                currentxp += 35;
                hasgivenxp = true;
            }
            if (randomencounter.currentenemy == "Slime")
            {
                grantedxp = 20;
                currentxp += 20;
                hasgivenxp = true;
            }
            if (randomencounter.currentenemy == "Cactus")
            {
                grantedxp = 45;
                currentxp += 45;
                hasgivenxp = true;
            }
            if (randomencounter.currentenemy == "minihydra")
            {
                grantedxp = 50;
                currentxp += 50;
                hasgivenxp = true;
            }
            if (randomencounter.currentenemy == "ArmouredScorpion")
            {
                grantedxp = 55;
                currentxp += 55;
                hasgivenxp = true;
            }
            if (randomencounter.currentenemy == "GiantHydra")
            {
                grantedxp = 150;
                currentxp += 150;
                hasgivenxp = true;
            }
            if (randomencounter.currentenemy == "lavamonster")
            {
                grantedxp = 125;
                currentxp += 125;
                hasgivenxp = true;
            }
            if (randomencounter.currentenemy == "lavasnail")
            {
                grantedxp = 115;
                currentxp += 115;
                hasgivenxp = true;
            }
        }
    }




}
