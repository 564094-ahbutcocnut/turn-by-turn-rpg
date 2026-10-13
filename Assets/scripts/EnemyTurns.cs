using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTurns : MonoBehaviour
{

    [Header("Other Scripts")]
    [SerializeField] Turns turns;
    [SerializeField] RandonEncounters randomencounters;
    [SerializeField] enemies Enemy;
    [SerializeField] MineSweeperAttack minesweeperattack;

    [Header("sprites")]

    public SpriteRenderer Slimespriterender;
    [SerializeField] public Sprite slimebeforeexplosion;
    [SerializeField] public Sprite slimeafterexplosion;
    [SerializeField] public Sprite MachoSlime;
    public SpriteRenderer Rockyspriterender;
    [SerializeField] public Sprite norockslost;
    [SerializeField] public Sprite onerocklost;
    [SerializeField] public Sprite tworockslost;
    [SerializeField] public Sprite threerockslost;
    [SerializeField] public Sprite fourrockslost;
    [SerializeField] public Sprite fiverockslost;
    [SerializeField] public Sprite sixrockslost;
    [SerializeField] public Sprite sevenrockslost;
    [SerializeField] public Sprite eightrockslost;


    [Header("battle variables")]

    [SerializeField] GameObject MinesweeperManagerEasy;
    //[SerializeField] GameObject MinesweeperManagerMedium;
    //[SerializeField] GameObject MinesweeperManagerHard;

    [SerializeField] GameObject enenyusedmoveholder;
    [SerializeField] TextMeshProUGUI enemymoveused;

    int Enemydamagemodifier = 1;
    int Enemyarmourmodifier = 1;


    bool hasslimegonecrazy = false;
    int ultamateSlimeAttack = 1;

    string targetedplayer = ""; 

    public bool hasenemyusedattack = false;

    public int rockslost = 0;

    public bool usingminesweeper;


    Transform Managers;

    private void Start()
    {
        Managers = GameObject.Find("MinesweeperManagerHolder-easy").transform;
    }

    private void Update()
    {
        if(minesweeperattack.haslost == true)
        {
            Debug.Log(minesweeperattack.haslost);
            StartCoroutine(failedMinecsweeper());
            minesweeperattack.haslost = false;
        }

        if (minesweeperattack.haswon == true)
        {
            StartCoroutine(Sucseededminesweeper());
            minesweeperattack.haswon = false;
        }




        if (Rockyspriterender != null)
        {


            if (rockslost == 0)
            {
                Rockyspriterender.sprite = norockslost;

                turns.enemymaxhealth = 50;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            }
            if (rockslost == 1)
            {
                Rockyspriterender.sprite = onerocklost;

                turns.enemymaxhealth = 45;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            }
            if (rockslost == 2)
            {
                Rockyspriterender.sprite = tworockslost;

                turns.enemymaxhealth = 40;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            }
            if (rockslost == 3)
            {
                Rockyspriterender.sprite = threerockslost;

                turns.enemymaxhealth = 35;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            }
            if (rockslost == 4)
            {
                Rockyspriterender.sprite = fourrockslost;

                turns.enemymaxhealth = 30;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            }
            if (rockslost == 5)
            {
                Rockyspriterender.sprite = fiverockslost;

                turns.enemymaxhealth = 25;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            }
            if (rockslost == 6)
            {
                Rockyspriterender.sprite = sixrockslost;

                turns.enemymaxhealth = 20;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            }
            if (rockslost == 7)
            {
                Rockyspriterender.sprite = sevenrockslost;

                turns.enemymaxhealth = 15;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            }
            if (rockslost == 8)
            {
                Rockyspriterender.sprite = eightrockslost;

                turns.enemymaxhealth = 10;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            }
            if(rockslost > 8)
            {
                rockslost = 8;
            }
            if(rockslost <0)
            {
                rockslost = 0;
            }
            
        }



        if (turns.inbattle == false)
        {
            Enemydamagemodifier = 1;
            Enemyarmourmodifier = 1;
        }

        if(randomencounters.currentenemy == "lavamonster")
        {
            Enemydamagemodifier = 3;
        }
        if (randomencounters.currentenemy == "lavasnail")
        {
            Enemydamagemodifier = 2; 
            Enemyarmourmodifier = 2;
        }
        if(randomencounters.currentenemy == "ArmouredScorpion")
        {
            Enemydamagemodifier = 2;
            Enemyarmourmodifier = 3;
        }
        if(randomencounters.currentenemy == "GiantHydra")
        {
            Enemydamagemodifier = 4;
        }


        if (turns.barrieractive == true && hasslimegonecrazy == true)
        {
            ultamateSlimeAttack = 6;
        }
        else if(turns.barrieractive == false && hasslimegonecrazy == true)
        {
            ultamateSlimeAttack = 3;
        }
        else
        {
            ultamateSlimeAttack = 1;
        }


        if (turns.currentturn == "Enemy")
        {
            if (hasenemyusedattack == false)
            {
                if (randomencounters.currentenemy == "Goblin")
                {
                    int enemymoveselector = Random.Range(1, 11);

                    if (enemymoveselector >= 1 && enemymoveselector <= 11)
                    {
                        StartCoroutine(Lunge());
                        hasenemyusedattack = true;
                    }
                    else if (enemymoveselector >= 5 && enemymoveselector <= 8)
                    {
                        StartCoroutine(SpearStab());
                        hasenemyusedattack = true;
                    }
                    else
                    {
                        StartCoroutine(WingGust());
                        hasenemyusedattack = true;
                    }
                }
                if (randomencounters.currentenemy == "Rocky")
                {
                    int enemymoveselector = Random.Range(1, 11);

                    if(rockslost == 0 || rockslost == 1)
                    {
                        if (enemymoveselector >= 1 && enemymoveselector <= 8)
                        {
                            StartCoroutine(rockswing());
                            hasenemyusedattack = true;
                        }
                        else
                        {
                            StartCoroutine(RockCrush());
                            hasenemyusedattack = true;
                        }
                    }

                    if (rockslost == 2 || rockslost == 3 || rockslost == 4)
                    {
                        if (enemymoveselector >= 1 && enemymoveselector <= 6)
                        {
                            StartCoroutine(rockswing());
                            hasenemyusedattack = true;
                        }
                        else if (enemymoveselector >= 7 && enemymoveselector <= 9)
                        {
                            StartCoroutine(RockCrush());
                            hasenemyusedattack = true;
                        }
                        else
                        {
                            StartCoroutine(PebbleHealing());
                            hasenemyusedattack = true;
                        }
                    }
                    if(rockslost == 5 || rockslost == 6)
                    {

                        if (enemymoveselector >= 1 && enemymoveselector <= 2)
                        {
                            StartCoroutine(rockswing());
                            hasenemyusedattack = true;
                        }
                        else if (enemymoveselector >= 3 && enemymoveselector <= 6)
                        {
                            StartCoroutine(RockCrush());
                            hasenemyusedattack = true;
                        }
                        else
                        {
                            StartCoroutine(PebbleHealing());
                            hasenemyusedattack = true;
                        }
                    }
                    if(rockslost == 7 || rockslost == 8)
                    {

                        if (enemymoveselector >= 1 && enemymoveselector <= 5)
                        {
                            StartCoroutine(RockCrush());
                            hasenemyusedattack = true;
                        }
                        else
                        {
                            StartCoroutine(PebbleHealing());
                            hasenemyusedattack = true;
                        }
                    }


                }
                if (randomencounters.currentenemy == "Slime")
                {
                    Sprite slimeafterexplosion = slimebeforeexplosion;

                    int enemymoveselector = Random.Range(1, 11);

                    if (enemymoveselector >= 1 && enemymoveselector <= 4)
                    {
                        StartCoroutine(Slimebonk());
                        hasenemyusedattack = true;
                    }
                    else if (enemymoveselector >= 5 && enemymoveselector <= 8)
                    {
                        StartCoroutine(Slimejab());
                        hasenemyusedattack = true;
                    }
                    else
                    {
                        StartCoroutine(Slimeexplosion());
                        hasenemyusedattack = true;
                    }
                }

                if(randomencounters.currentenemy == "")
                {
                    int enemymoveselector = Random.Range(1, 11);

                    if(turns.enemycurrenthealth == turns.enemymaxhealth)
                    {
                        StartCoroutine(SpewLava());
                    }
                }
            }
        }





    }

    public void Enemytarget()
    {
        int playertarget = Random.Range(1, 4);

        if (targetedplayer == "player1istargetted" && turns.player1dead == false)
        {
            targetedplayer = "player1istargetted";
        }
        if(targetedplayer == "player1istargetted" && turns.player1dead == true)
        {
            targetedplayer = "player2istargetted";
        }
        if(targetedplayer == "player1istargetted" && turns.player1dead == true && turns.player2dead == true)
        {
            targetedplayer = "player3istargetted";
        }
        if (targetedplayer == "player2istargetted" && turns.player1dead == false)
        {
            targetedplayer = "player2istargetted";
        }
        if (targetedplayer == "player2istargetted" && turns.player1dead == true)
        {
            targetedplayer = "player3istargetted";
        }
        if (targetedplayer == "player2istargetted" && turns.player2dead == true && turns.player3dead == true)
        {
            targetedplayer = "player1istargetted";
        }
        if (playertarget == 3 && turns.player1dead == false)
        {
            targetedplayer = "player3istargetted";
        }
        if (playertarget == 3 && turns.player1dead == true)
        {
            targetedplayer = "player1istargetted";
        }
        if(playertarget == 3 && turns.player3dead == true && turns.player1dead == true)
        {
            targetedplayer = "player2istargetted";
        }


    }

    IEnumerator Lunge()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Goblin used Lunge";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        if (rollEnemynumber >=1 && rollEnemynumber <= 3)
        {
            turns.enemycurrenthealth -= 3;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();

        }
        if(rollEnemynumber >=4 && rollEnemynumber <= 5)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 2 / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.turnsleftofbarrier--;
            }
            else if(targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 2 / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.turnsleftofbarrier--;
            }
            else
            {
                turns.player3currenthealth -= 2 / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.turnsleftofbarrier--;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 3 / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.turnsleftofbarrier--;
            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 3 / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.turnsleftofbarrier--;
            }
            else
            {
                turns.player3currenthealth -= 3 / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.turnsleftofbarrier--;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 4 / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.turnsleftofbarrier--;
            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 4 / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.turnsleftofbarrier--;
            }
            else
            {
                turns.player3currenthealth -= 4 / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.turnsleftofbarrier--;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 5 / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.turnsleftofbarrier--;
            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 5 / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.turnsleftofbarrier--;
            }
            else
            {
                turns.player3currenthealth -= 5 / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.turnsleftofbarrier--;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber == 20)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 7 / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

                turns.player2currenthealth -= 7;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.turnsleftofbarrier--;
            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 7 / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

                turns.player3currenthealth -= 7;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.turnsleftofbarrier--;
            }
            else
            {
                turns.player3currenthealth -= 7 / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;

                turns.player1currenthealth -= 7;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.turnsleftofbarrier--;
            }
            turns.switchPlayer();
        }
        yield return new WaitForSeconds(.5F);
        enenyusedmoveholder.SetActive(false);

    }

    IEnumerator SpearStab()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Goblin used SpearStab";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        if (rollEnemynumber >= 1 && rollEnemynumber <= 5)
        {
            turns.enemycurrenthealth -= 4;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 4 / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.turnsleftofbarrier--;
            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 4 / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.turnsleftofbarrier--;
            }
            else
            {
                turns.player3currenthealth -= 4 / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.turnsleftofbarrier--;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 4 / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.turnsleftofbarrier--;
            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 4 / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.turnsleftofbarrier--;
            }
            else
            {
                turns.player3currenthealth -= 4 / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.turnsleftofbarrier--;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 6 / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.turnsleftofbarrier--;
            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 6 / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.turnsleftofbarrier--;
            }
            else
            {
                turns.player3currenthealth -= 6 / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.turnsleftofbarrier--;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber == 20)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 8 / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.turnsleftofbarrier--;

            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 8 / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.turnsleftofbarrier--;

            }
            else
            {
                turns.player3currenthealth -= 8 / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.turnsleftofbarrier--;

            }
            turns.switchPlayer();
        }
        yield return new WaitForSeconds(.5F);
        enenyusedmoveholder.SetActive(false);


    }

    IEnumerator WingGust()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Goblin used Lunge";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        if (rollEnemynumber >= 1 && rollEnemynumber <= 2)
        {
            turns.enemycurrenthealth -= 7;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();

        }
        if (rollEnemynumber >= 3 && rollEnemynumber <= 5)
        {           

            turns.player1currenthealth -= 1 / turns.barrierreducer;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;            
            
            turns.player2currenthealth -= 1 / turns.barrierreducer;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            
            turns.player3currenthealth -= 1 / turns.barrierreducer;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            turns.turnsleftofbarrier--;

            turns.switchPlayer();
        }
        if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
        {

            turns.player1currenthealth -= 2 / turns.barrierreducer;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

            turns.player2currenthealth -= 2 / turns.barrierreducer;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

            turns.player3currenthealth -= 2 / turns.barrierreducer;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            turns.turnsleftofbarrier--;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
        {
            turns.player1currenthealth -= 3 / turns.barrierreducer;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

            turns.player2currenthealth -= 3 / turns.barrierreducer;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

            turns.player3currenthealth -= 3 / turns.barrierreducer;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            turns.turnsleftofbarrier--;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
        {
            turns.player1currenthealth -= 3 / turns.barrierreducer;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

            turns.player2currenthealth -= 4 / turns.barrierreducer;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

            turns.player3currenthealth -= 3 / turns.barrierreducer;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            turns.turnsleftofbarrier--;
            turns.switchPlayer();
        }
        if (rollEnemynumber == 20)
        {
            turns.player1currenthealth -= 5 / turns.barrierreducer;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

            turns.player2currenthealth -= 5 / turns.barrierreducer;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

            turns.player3currenthealth -= 5 / turns.barrierreducer;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            turns.turnsleftofbarrier--;
            turns.switchPlayer();
        }
        yield return new WaitForSeconds(.5F);
        enenyusedmoveholder.SetActive(false);

    }

    IEnumerator rockswing()
    {

        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Rocky used Rock Swing";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        if (rockslost >= 5 && rockslost <= 6)
        {
            if (rollEnemynumber >= 1 && rollEnemynumber <= 3)
            {
                rockslost += 2;
                turns.switchPlayer();

            }
            if (rollEnemynumber >= 4 && rollEnemynumber <= 5)
            {
                Enemytarget();

                rockslost++;

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 0 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 0 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 0 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 1 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 1 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 1 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 2 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 2 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 2 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 3 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 3 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 3 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber == 20)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 5 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 5 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 5 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
        }

        if (rockslost >=2 && rockslost <= 4)
        {
            if (rollEnemynumber >= 1 && rollEnemynumber <= 3)
            {
                rockslost += 2;
                turns.switchPlayer();

            }
            if (rollEnemynumber >= 4 && rollEnemynumber <= 5)
            {
                Enemytarget();

                rockslost++;

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 1 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 1 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 1 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 2 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 2 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 2 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 3 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 3 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 3 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 4 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 4 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 4 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber == 20)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 5 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

                    turns.player2currenthealth -= 5;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 5 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

                    turns.player3currenthealth -= 5;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 5 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;

                    turns.player1currenthealth -= 5;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
        }

        if(rockslost >= 0 && rockslost <=1)
        {
            if (rollEnemynumber >= 1 && rollEnemynumber <= 3)
            {
                rockslost += 2;
                turns.switchPlayer();

            }
            if (rollEnemynumber >= 4 && rollEnemynumber <= 5)
            {
                Enemytarget();

                rockslost++;

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 2 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 2 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 2 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 3 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 3 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 3 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 4 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 4 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 4 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 5 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 5 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 5 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber == 20)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 6 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

                    turns.player2currenthealth -= 6;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 6 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

                    turns.player3currenthealth -= 6;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 6 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;

                    turns.player1currenthealth -= 6;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
        }




        yield return new WaitForSeconds(.5F);
        enenyusedmoveholder.SetActive(false);

    }
    
    IEnumerator RockCrush()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Rocky used Rock Crush";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        if (rockslost >= 5 && rockslost <= 6)
        {
            if (rollEnemynumber >= 1 && rollEnemynumber <= 3)
            {
                rockslost += 1;
                turns.switchPlayer();

            }
            if (rollEnemynumber >= 4 && rollEnemynumber <= 5)
            {
                Enemytarget();

                rockslost++;

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 2 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 2 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 2 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 4 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 4 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 4 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 5 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 5 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 5 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 6 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 6 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 6 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber == 20)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 8 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 8 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 8 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
        }

        if (rockslost >= 2 && rockslost <= 4)
        {
            if (rollEnemynumber >= 1 && rollEnemynumber <= 3)
            {
                rockslost += 1;
                turns.switchPlayer();

            }
            if (rollEnemynumber >= 4 && rollEnemynumber <= 5)
            {
                Enemytarget();

                rockslost++;

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 3 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 3 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 3 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 4 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 4 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 4 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 6 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 6 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 6 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 7 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 7 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 7 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber == 20)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 10 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 10 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 10 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
        }

        if (rockslost >= 0 && rockslost <= 1)
        {
            if (rollEnemynumber >= 1 && rollEnemynumber <= 3)
            {
                rockslost += 2;
                turns.switchPlayer();

            }
            if (rollEnemynumber >= 4 && rollEnemynumber <= 5)
            {
                Enemytarget();

                rockslost++;

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 2 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 2 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 2 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 3 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 3 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 3 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 4 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 4 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 4 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 5 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 5 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 5 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber == 20)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 6 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

                    turns.player2currenthealth -= 6;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 6 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

                    turns.player3currenthealth -= 6;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 6 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;

                    turns.player1currenthealth -= 6;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
        }




        yield return new WaitForSeconds(.5F);
        enenyusedmoveholder.SetActive(false);
    }

    IEnumerator PebbleHealing()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Rocky used Pebble Healing";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        if(rollEnemynumber == 1)
        {
            rockslost += 2;
            turns.switchPlayer();
        }
        if(rollEnemynumber >= 2 && rollEnemynumber <= 3)
        {
            rockslost++;
            turns.switchPlayer();
        }
        if(rollEnemynumber >=4 && rollEnemynumber <= 5)
        {
            turns.enemycurrenthealth += 3;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if(rollEnemynumber >=5 && rollEnemynumber <=10)
        {
            rockslost--;

            turns.enemycurrenthealth += 3;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
        {
            rockslost-=2;

            turns.enemycurrenthealth += 5;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
        {
            rockslost-=3;

            turns.enemycurrenthealth += 10;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if (rollEnemynumber == 20)
        {
            rockslost = 0;

            turns.enemycurrenthealth = turns.enemymaxhealth;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();

        }
    }

    IEnumerator Slimebonk()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Slime used Slime bonk";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);


        if (rollEnemynumber >= 1 && rollEnemynumber <= 5)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 0;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.turnsleftofbarrier--;
            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 0;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.turnsleftofbarrier--;
            }
            else
            {
                turns.player3currenthealth -= 0;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.turnsleftofbarrier--;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 2 * ultamateSlimeAttack / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.turnsleftofbarrier--;
            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 2 * ultamateSlimeAttack / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.turnsleftofbarrier--;
            }
            else
            {
                turns.player3currenthealth -= 2 * ultamateSlimeAttack / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.turnsleftofbarrier--;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 3 * ultamateSlimeAttack / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.turnsleftofbarrier--;
            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 3 * ultamateSlimeAttack / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.turnsleftofbarrier--;
            }
            else
            {
                turns.player3currenthealth -= 3 * ultamateSlimeAttack / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.turnsleftofbarrier--;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 4 * ultamateSlimeAttack / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.turnsleftofbarrier--;
            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 4 * ultamateSlimeAttack / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.turnsleftofbarrier--;
            }
            else
            {
                turns.player3currenthealth -= 4 * ultamateSlimeAttack / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.turnsleftofbarrier--;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber == 20)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 5 * ultamateSlimeAttack / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

                turns.player2currenthealth -= 5 * ultamateSlimeAttack / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.turnsleftofbarrier = 0;
            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 5 * ultamateSlimeAttack / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

                turns.player3currenthealth -= 15 * ultamateSlimeAttack / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.turnsleftofbarrier = 0;
            }
            else
            {
                turns.player3currenthealth -= 15 * ultamateSlimeAttack / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;

                turns.player1currenthealth -= 5 * ultamateSlimeAttack / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.turnsleftofbarrier= 0;
            }
            turns.switchPlayer();
        }
        yield return new WaitForSeconds(.5F);
        enenyusedmoveholder.SetActive(false);

    }

    IEnumerator Slimejab()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Slime used Slime jab";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        if(hasslimegonecrazy == true)
        {
            if (rollEnemynumber >= 1 && rollEnemynumber <= 5)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 0;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 0;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 0;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 1 * ultamateSlimeAttack / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 1 * ultamateSlimeAttack / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 1 * ultamateSlimeAttack / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 2 * ultamateSlimeAttack / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 2 * ultamateSlimeAttack / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 2 * ultamateSlimeAttack / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 3 * ultamateSlimeAttack / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 3 * ultamateSlimeAttack / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 3 * ultamateSlimeAttack / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber == 20)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 4 * ultamateSlimeAttack / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

                    turns.player2currenthealth -= 20 * ultamateSlimeAttack / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 20 * ultamateSlimeAttack / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

                    turns.player3currenthealth -= 4 * ultamateSlimeAttack / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 5 * ultamateSlimeAttack / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;

                    turns.player1currenthealth -= 5 * ultamateSlimeAttack / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
        }
        else
        {
            if (rollEnemynumber >= 1 && rollEnemynumber <= 5)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 0;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 0;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 0;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 1 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 1 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 1 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 2 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 2 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 2 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 3 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 3 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;
                }
                else
                {
                    turns.player3currenthealth -= 3 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber == 20)
            {
                Enemytarget();

                if (targetedplayer == "player1istargetted")
                {

                    turns.player1currenthealth -= 4 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                    turns.turnsleftofbarrier--;

                    turns.player2currenthealth -= 20 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                }
                else if (targetedplayer == "player2istargetted")
                {
                    turns.player2currenthealth -= 20 / turns.barrierreducer;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                    turns.turnsleftofbarrier--;

                    turns.player3currenthealth -= 4 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                }
                else
                {
                    turns.player3currenthealth -= 5 / turns.barrierreducer;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                    turns.turnsleftofbarrier--;

                    turns.player1currenthealth -= 5 / turns.barrierreducer;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                }
                turns.switchPlayer();
            }
        }

            yield return new WaitForSeconds(.5F);
        enenyusedmoveholder.SetActive(false);

    }

    IEnumerator Slimeexplosion()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Slime exploded";

        Slimespriterender.sprite = slimeafterexplosion;

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);


        
        if (rollEnemynumber >= 1 && rollEnemynumber <=19)
        {              

            turns.player1currenthealth -= 14 / turns.barrierreducer;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            turns.turnsleftofbarrier--;

            turns.player2currenthealth -= 29 / turns.barrierreducer;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            
            turns.player3currenthealth -= 19 / turns.barrierreducer;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;

            yield return new WaitForSeconds(.5F);

            enenyusedmoveholder.SetActive(false);


            turns.enemycurrenthealth = 0;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;

            turns.switchPlayer();
        }
        if (rollEnemynumber == 20)
        {

            turns.player1currenthealth -= 2147483647 / turns.barrierreducer;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            turns.turnsleftofbarrier = 0;

            turns.player2currenthealth -= 20 / turns.barrierreducer;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            turns.turnsleftofbarrier = 0;

            turns.player3currenthealth -= 10 / turns.barrierreducer;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            turns.turnsleftofbarrier = 0;


            turns.enemycurrenthealth = 1;


            yield return new WaitForSeconds(.5F);
            enemymoveused.text = ".";

            yield return new WaitForSeconds(.5F);
            enemymoveused.text = "..";

            yield return new WaitForSeconds(.5F);
            enemymoveused.text = "...";

            yield return new WaitForSeconds(.5F);
            enemymoveused.text = "....";

            yield return new WaitForSeconds(.5F);
            enemymoveused.text = ".....";

            yield return new WaitForSeconds(.5F);
            enemymoveused.text = "BUT IT REFUSED!!!";


            Slimespriterender.sprite = MachoSlime;

            turns.enemymaxhealth = 100;

            turns.enemycurrenthealth = turns.enemymaxhealth;


            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;

            rollEnemynumber = turns.enemyroll();

            if(rollEnemynumber == 1)
            {
                yield return new WaitForSeconds(1.5F);
                enemymoveused.text = "but not for long";

                Slimespriterender.sprite = slimeafterexplosion;

                turns.enemymaxhealth = 1;
                turns.enemycurrenthealth = 0;
            }
            else
            {
                hasslimegonecrazy = true;
            }

                turns.switchPlayer();
        }
        yield return new WaitForSeconds(.5F);
        enenyusedmoveholder.SetActive(false);

    }

    IEnumerator TougherArmour()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The " + turns.currentturn + " used Tougher Armour";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        if(rollEnemynumber >=1 && rollEnemynumber <= 3)
        {
            turns.armourtoughnessscale = -2 * Enemyarmourmodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 4 && rollEnemynumber <= 5)
        {
            turns.armourtoughnessscale = -1 * Enemyarmourmodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
        {
            turns.armourtoughnessscale = 1 * Enemyarmourmodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
        {
            turns.armourtoughnessscale = 2 * Enemyarmourmodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
        {
            turns.armourtoughnessscale = 3 * Enemyarmourmodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if(rollEnemynumber == 20)
        {
            turns.armourtoughnessscale = 4 * Enemyarmourmodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
    }

    IEnumerator SpewLava()
    {

        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The " + turns.currentturn + " used Spew lava";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);


        if(rollEnemynumber >=1 && rollEnemynumber <= 3)
        {
            turns.enemycurrenthealth -= 10 * Enemydamagemodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();

        }
        if(rollEnemynumber >= 4 && rollEnemynumber <= 5)
        {

            turns.enemycurrenthealth -= 8 * Enemydamagemodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if(rollEnemynumber >=6 && rollEnemynumber <=10)
        {
            turns.player1currenthealth -= 2 * Enemydamagemodifier / turns.barrierreducer;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

            turns.player2currenthealth -= 2 * Enemydamagemodifier / turns.barrierreducer;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

            turns.player3currenthealth -= 2*Enemydamagemodifier / turns.barrierreducer;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;

            turns.enemycurrenthealth -= 6 * Enemydamagemodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.turnsleftofbarrier--;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
        {
            turns.player1currenthealth -= 5 * Enemydamagemodifier / turns.barrierreducer;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

            turns.player2currenthealth -= 5 * Enemydamagemodifier / turns.barrierreducer;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

            turns.player3currenthealth -= 5 * Enemydamagemodifier / turns.barrierreducer;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;

            turns.enemycurrenthealth -= 4 * Enemydamagemodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;

            turns.turnsleftofbarrier--;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
        {
            turns.player1currenthealth -= 7 * Enemydamagemodifier / turns.barrierreducer;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

            turns.player2currenthealth -= 7 * Enemydamagemodifier / turns.barrierreducer;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

            turns.player3currenthealth -= 7 * Enemydamagemodifier / turns.barrierreducer;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;

            turns.enemycurrenthealth -= 2 * Enemydamagemodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;

            turns.turnsleftofbarrier--;
            turns.switchPlayer();
        }
        if(rollEnemynumber == 20)
        {

            turns.player1currenthealth -= 10 * Enemydamagemodifier / turns.barrierreducer;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

            turns.player2currenthealth -= 10 * Enemydamagemodifier / turns.barrierreducer;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

            turns.player3currenthealth -= 10 * Enemydamagemodifier / turns.barrierreducer;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            turns.turnsleftofbarrier--;
            turns.switchPlayer();
        }
    }

    IEnumerator LavaBackhand()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Lava Monster used Lava Backhand";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        if (rollEnemynumber >= 1 && rollEnemynumber <= 5)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 4 / turns.barrierreducer; 
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.player2currenthealth -= 4 / turns.barrierreducer;
                turns.enemycurrenthealth -= 10;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
                turns.turnsleftofbarrier--;
                
            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 4 / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.player3currenthealth -= 4 / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.enemycurrenthealth -= 10;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
                turns.turnsleftofbarrier--;
            }
            else
            {
                turns.player3currenthealth -= 4 / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.player1currenthealth -= 4 / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.enemycurrenthealth -= 10;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
                turns.turnsleftofbarrier--;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 4 / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.player2currenthealth -= 4 / turns.barrierreducer;
                turns.turnsleftofbarrier--;

            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 4 / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.player3currenthealth -= 4 / turns.barrierreducer;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
                turns.turnsleftofbarrier--;
            }
            else
            {
                turns.player3currenthealth -= 4 / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.player1currenthealth -= 4 / turns.barrierreducer;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
                turns.turnsleftofbarrier--;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 6 / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.player2currenthealth -= 6 / turns.barrierreducer;
                turns.turnsleftofbarrier--;

            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 6 / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.player3currenthealth -= 6 / turns.barrierreducer;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
                turns.turnsleftofbarrier--;
            }
            else
            {
                turns.player3currenthealth -= 6 / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.player1currenthealth -= 6 / turns.barrierreducer;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
                turns.turnsleftofbarrier--;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
        {
            Enemytarget();

            if (targetedplayer == "player1istargetted")
            {

                turns.player1currenthealth -= 7 / turns.barrierreducer;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                turns.player2currenthealth -= 7 / turns.barrierreducer;
                turns.turnsleftofbarrier--;

            }
            else if (targetedplayer == "player2istargetted")
            {
                turns.player2currenthealth -= 7 / turns.barrierreducer;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                turns.player3currenthealth -= 7 / turns.barrierreducer;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
                turns.turnsleftofbarrier--;
            }
            else
            {
                turns.player3currenthealth -= 7 / turns.barrierreducer;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                turns.player1currenthealth -= 7 / turns.barrierreducer;
                turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
                turns.turnsleftofbarrier--;
            }
            turns.switchPlayer();
        }
        if(rollEnemynumber == 20)
        {
            turns.player1currenthealth -= 10 / turns.barrierreducer;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            turns.player2currenthealth -= 10 / turns.barrierreducer;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            turns.player3currenthealth -= 10 / turns.barrierreducer;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            turns.turnsleftofbarrier--;
        }
    }

    IEnumerator magmaregeneration()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The " + turns.currentturn + " used Magma regeneration";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        if (rollEnemynumber >= 1 && rollEnemynumber <= 3)
        {
            turns.enemycurrenthealth -= 5 * Enemydamagemodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 4 && rollEnemynumber <= 5)
        {
            turns.enemycurrenthealth -= 3 * Enemydamagemodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
        {
            turns.enemycurrenthealth += 5 * Enemydamagemodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
        {
            turns.enemycurrenthealth += 7 * Enemydamagemodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
        {
            turns.enemycurrenthealth += 10 * Enemydamagemodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if(rollEnemynumber ==20)
        {

            turns.enemycurrenthealth += 15 * Enemydamagemodifier;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }

    }

    public void MinesweeperAttack()
    {
        


        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Enemy summoned minesweeper";

        usingminesweeper = true;
    }

    IEnumerator failedMinecsweeper()
    {
            enemymoveused.text = "You failed";

            yield return new WaitForSeconds(2F);


            turns.player1currenthealth /= 2;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

            turns.player2currenthealth /= 2;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

            turns.player3currenthealth /= 2;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;            
            
            yield return new WaitForSeconds(2F);
            enenyusedmoveholder.SetActive(false);
            Destroyminesweeper();
            turns.switchPlayer();        
    }

    IEnumerator Sucseededminesweeper()
    {

        enemymoveused.text = "You Win";

        turns.enemycurrenthealth /= 2;
        turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;

        yield return new WaitForSeconds(2F);

        enenyusedmoveholder.SetActive(false);
        Destroyminesweeper();
        turns.switchPlayer();
    }

    


    Vector2 CenterPosition()
    {
        Vector2 Centreposition = new Vector2(Random.Range(0, 0), Random.Range(3, 3));
        return Centreposition;
    }

    public void Destroyminesweeper()
    {
        foreach (Transform e in Managers)
            Destroy(e.gameObject);
    }
}
