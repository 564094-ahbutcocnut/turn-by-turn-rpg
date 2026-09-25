using TMPro;
using UnityEngine;
using System.Collections;

public class Turns : MonoBehaviour
{
    [Header("Game states")]
    [SerializeField] GameObject BattleUI;
    [SerializeField] GameObject Overworld;

    [Header("Rolls")]
    [SerializeField] TextMeshProUGUI PlayerRoll;
    [SerializeField] TextMeshProUGUI EnemyRoll;

    [Header("Health")]
    [SerializeField] TextMeshProUGUI Player1health;
    [SerializeField] TextMeshProUGUI Player2health;
    [SerializeField] TextMeshProUGUI Player3health;
    [SerializeField] public TextMeshProUGUI Bosshealth;

    [Header("Mana")]
    [SerializeField] TextMeshProUGUI Player1mana;
    [SerializeField] TextMeshProUGUI Player2mana;
    [SerializeField] TextMeshProUGUI Player3mana;
    [SerializeField] GameObject NOMANA;

    [Header("who's turn")]
    [SerializeField] public string currentturn;
    [SerializeField] TextMeshProUGUI whosTurnText;

    [Header("status")]
    [SerializeField] GameObject bossconfusion;
    [SerializeField] GameObject bossparalysed;
    [SerializeField] GameObject enraged;
    [SerializeField] GameObject barrier;

    [Header("battlestuff")]

    public bool inbattle = false;
    bool hasnotbeensetyet = false;

    int wheelrollsPlayers = 0;
    int wheelrollsBoss = 0;

    int player1maxhealth = 15;
    int player2maxthealth = 30;
    int player3maxhealth = 20;
    int bossmaxhealth = 100;

    int player1currenthealth = 0;
    int player2currenthealth = 0;
    int player3currenthealth = 0;
    int bosscurrenthealth = 0;

    int player1maxmana = 100;
    int player2maxmana = 50;
    int player3maxmana = 75;

    public int player1currentmana = 0;
    public int player2currentmana = 0;
    public int player3currentmana = 0;

    int halvingcurrenthealth = 0;

    int differenceinroll = 0;
    int damagetoboss = 0;

    int bossdamagetransitionvalue = 0;

    int bossmoveslot = 0;

    int lifestealamount = 0;

    public bool player1dead = false;
    public bool player2dead = false;
    public bool player3dead = false;

    public bool isbossconfused = false;
    public bool isbossparalysed = false;

    int parachancetostatus = 0;
    int parachancehappen = 0;

    bool rageactive = false;
    int ragemultiplier = 1;

    bool barrieractive = false;
    int barrierreducer = 1;
    int turnsleftofbarrier = 0;

    public string lastusedmove = "";

    //when entering a battle setplayer active to false to stop moving during battle

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(turnsleftofbarrier == 0)
        {
            barrieractive = false;
        }
        if (turnsleftofbarrier > 0)
        {
            barrieractive = true;
        }

        if (barrieractive == true)
        {
            barrier.SetActive(true);
            barrierreducer = 2;
        }
        if (barrieractive == false)
        {
            barrier.SetActive(false);
            barrierreducer = 1;
        }

        if (rageactive == true)
        {
            enraged.SetActive(true);
            ragemultiplier = 3;
        }
        if(rageactive == false)
        {
            ragemultiplier = 1;
            enraged.SetActive(false);
        }



        if (Input.GetKeyDown(KeyCode.P))
        {
            if (inbattle == true)
            {
                inbattle = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (inbattle == false)
            {

                inbattle = true;
            }
        }

        if (inbattle == true)
        {
            BattleUI.SetActive(true);
            Overworld.SetActive(false);


            if(hasnotbeensetyet == false)
            {
                player1currenthealth = player1maxhealth;
                player2currenthealth = player2maxthealth;
                player3currenthealth = player3maxhealth;
                bosscurrenthealth = bossmaxhealth;

                player1currentmana = player1maxmana;
                player2currentmana = player2maxmana;
                player3currentmana = player3maxmana;

                PlayerRoll.text = wheelrollsPlayers.ToString();
                EnemyRoll.text = wheelrollsBoss.ToString();
                Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
                Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
                Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
                Player2mana.text = player2currentmana.ToString() + "/" + player2maxmana;
                Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
                Player3mana.text = player3currentmana.ToString() + "/" + player3maxmana;
                Bosshealth.text = bosscurrenthealth.ToString() + "/" + bossmaxhealth;
                whosTurnText.text = currentturn + "'s turn";
                hasnotbeensetyet = true;
            }





            if (Input.GetKeyDown(KeyCode.B))
            {
                bossroll();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                player1currenthealth--;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                currentturn = "Boss";
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentturn = "Player1";
                whosTurnText.text = currentturn + "'s turn";
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentturn = "Player2";
                whosTurnText.text = currentturn + "'s turn";
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentturn = "Player3";
                whosTurnText.text = currentturn + "'s turn";
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                currentturn = "Boss";
                whosTurnText.text = currentturn + "'s turn";
            }

            bossturn();

            if (player1currenthealth > player1maxhealth)
            {
                player1currenthealth = player1maxhealth;
                Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
                Debug.Log("health reset ");
            }
            if (player1currentmana > player1maxmana)
            {
                player1currentmana = player1maxmana;
                Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            }
            if (player2currenthealth > player2maxthealth)
            {
                player2currenthealth = player2maxthealth;
                Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            }
            if (player2currentmana > player2maxmana)
            {
                player2currentmana = player2maxmana;
                Player2mana.text = player2currentmana.ToString() + "/" + player2maxmana;
            }
            if (player3currenthealth > player3maxhealth)
            {
                player3currenthealth = player3maxhealth;
                Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
            }
            if (player3currentmana > player3maxmana)
            {
                player3currentmana = player3maxmana;
                Player3mana.text = player3currentmana.ToString() + "/" + player3maxmana;
            }
            if (bosscurrenthealth > bossmaxhealth)
            {
                bosscurrenthealth = bossmaxhealth;
                Bosshealth.text = bosscurrenthealth.ToString() + "/" + bossmaxhealth;
            }

            if (player1currenthealth <= 0)
            {
                player1dead = true;
            }
            if (player2currenthealth <= 0)
            {
                player2dead = true;
            }
            if (player3currenthealth <= 0)
            {
                player3dead = true;
            }
            if (player1currenthealth > 0)
            {
                player1dead = false;
            }
            if (player2currenthealth > 0)
            {
                player2dead = false;
            }
            if (player3currenthealth > 0)
            {
                player3dead = false;
            }

            if (isbossconfused == true)
            {
                bossconfusion.SetActive(true);
            }
            if (isbossconfused == false)
            {
                bossconfusion.SetActive(false);
            }
            if (isbossparalysed == true)
            {
                bossparalysed.SetActive(true);
            }
            if (isbossparalysed == false)
            {
                bossparalysed.SetActive(false);
            }


        }

        if(inbattle == false)
        {
            BattleUI.SetActive(false);
            Overworld.SetActive(true);
        }


    }

    public int playerroll()
    {
        var playerroll = Random.Range(1, 21);
        wheelrollsPlayers = playerroll;
        PlayerRoll.text = wheelrollsPlayers.ToString();

        return wheelrollsPlayers;
    }
    public int bossroll()
    {
        var bossroll = Random.Range(1, 21);
        wheelrollsBoss = bossroll;
        EnemyRoll.text = wheelrollsBoss.ToString();

        return wheelrollsBoss;
    }



    public void Blackhole()
    {
        StartCoroutine(BlackHoleeCoroutine());

    }

    public void TeamHeal()
    {
        StartCoroutine(TeamHealCoroutine());
        
    }


    public void FatesGambit()
    {
        StartCoroutine(FatesGambitCoroutine());
        
    }

    public void ChaosChaos()
    {
        StartCoroutine(ChaosChaosCoroutine());
    }

    public void FireBall()
    {
        StartCoroutine(FireballCoroutine());
    }

    public void bounterfulbonk()
    {
        StartCoroutine(bounterfulbonkCoroutine());
    }

    public void UltimateRage()
    {
        StartCoroutine(UltimateRageCoroutine());
    }
    public void TeamBarrier()
    {
        StartCoroutine(TeamBarrierCoroutine());
    }

    public void Thunderbolt()
    {
        StartCoroutine(ThunderboltCoroutine());
    }

    IEnumerator Fallingdebree()
    {

        int rollNumber = playerroll();
        int rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);

        rollNumber = playerroll();
        rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);

        rollNumber = playerroll();
        rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);

        differenceinroll = rollBossnumber - rollNumber;

        if(differenceinroll < 0)
        {
            bosscurrenthealth = bosscurrenthealth - 5;
            Bosshealth.text = bosscurrenthealth.ToString() + "/" + bossmaxhealth;
        }
        if(differenceinroll == 0)
        {
            bosscurrenthealth = bosscurrenthealth - 1;
            Bosshealth.text = bosscurrenthealth.ToString() + "/" + bossmaxhealth;
        }
        if(differenceinroll >=1 && differenceinroll <=5)
        {
            player1currenthealth = player1currenthealth - 2 / barrierreducer;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth = player2currenthealth - 2 / barrierreducer;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth = player3currenthealth - 2 / barrierreducer;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
        }
        if (differenceinroll >= 6 && differenceinroll <= 10)
        {
            player1currenthealth = player1currenthealth - 4 / barrierreducer;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth = player2currenthealth - 4 / barrierreducer;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth = player3currenthealth - 4 / barrierreducer;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
        }
        if (differenceinroll >= 11 && differenceinroll <= 15)
        {
            player1currenthealth = player1currenthealth - 7 / barrierreducer;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth = player2currenthealth - 7 / barrierreducer;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth = player3currenthealth - 7 / barrierreducer;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
        }
        if (differenceinroll >= 16 && differenceinroll <= 20)
        {
            player1currenthealth = player1currenthealth - 10 / barrierreducer;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth = player2currenthealth - 10 / barrierreducer;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth = player3currenthealth - 10 / barrierreducer;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
        }

        if(barrieractive == true)
        {
            turnsleftofbarrier--;
        }
    }

    

    public  IEnumerator BlackHoleeCoroutine()
    {
            player1currentmana = player1currentmana - 30;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            int rollNumber = playerroll();
            int rollBossnumber = bossroll();
            yield return new WaitForSeconds(.2F);
            rollNumber = playerroll();
            rollBossnumber = bossroll();
            yield return new WaitForSeconds(.2F);
            rollNumber = playerroll();
            rollBossnumber = bossroll();
            yield return new WaitForSeconds(.2F);

            rollNumber = playerroll();
            rollBossnumber = bossroll();
            yield return new WaitForSeconds(.2F);

            rollNumber = playerroll();
            rollBossnumber = bossroll();
            yield return new WaitForSeconds(.2F);

            differenceinroll = rollNumber - rollBossnumber;


            if (differenceinroll <= 0)
            {
                player1currenthealth = player1currenthealth - 3;
                Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
                player2currenthealth = player2currenthealth - 4;
                Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
                player3currenthealth = player3currenthealth - 5;
                Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
                lastusedmove = "Blackhole";
                switchPlayer();

            }
            if (differenceinroll >= 1 && differenceinroll <= 5)
            {
                player1currenthealth = player1currenthealth - 1;
                Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
                player2currenthealth = player2currenthealth - 2;
                Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
                player3currenthealth = player3currenthealth - 3;
                Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
                lastusedmove = "Blackhole";
                switchPlayer();
            }
            if (differenceinroll >= 6 && differenceinroll <= 10)
            {
                damagetoboss = 3;
                lastusedmove = "Blackhole";
                switchPlayer();
            }
            if (differenceinroll >= 11 && differenceinroll <= 14)
            {
                damagetoboss = 5;
                lastusedmove = "Blackhole";
                switchPlayer();
            }
            if (differenceinroll >= 15 && differenceinroll <= 19)
            {
                damagetoboss = 7;
                lastusedmove = "Blackhole";
                switchPlayer();
            }
            if (differenceinroll == 20)
            {
                damagetoboss = 10;
                lastusedmove = "Blackhole";
                switchPlayer();
            }

            if (damagetoboss > 0)
            {
                bossdamagetransitionvalue = bosscurrenthealth;
                bosscurrenthealth = bossdamagetransitionvalue - damagetoboss;
                Bosshealth.text = bosscurrenthealth.ToString() + "/" + bossmaxhealth;
                damagetoboss = 0;

            }
        


    }

    public IEnumerator TeamHealCoroutine()
    {
        player3currentmana = player3currentmana - 20;
        Player3mana.text = player3currentmana.ToString() + "/" + player3maxmana;
        int rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);

        
        if(rollNumber == 1)
        {
            player1currenthealth--;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth--;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth--;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
            lastusedmove = "TeamHeal";
            switchPlayer();
        }
        if (rollNumber >= 2 && rollNumber <= 5)
        {
            player1currenthealth++;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth++;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth++;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
            lastusedmove = "TeamHeal";
            switchPlayer();
        }
        if(rollNumber >= 6 && rollNumber <= 10)
        {
            player1currenthealth += 3;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth += 5;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth += 4;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
            lastusedmove = "TeamHeal";
            switchPlayer();
        }
        if (rollNumber >= 11 && rollNumber <= 15)
        {
            player1currenthealth += 5;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth += 7;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth += 6;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
            lastusedmove = "TeamHeal";
            switchPlayer();
        }
        if (rollNumber >= 16 && rollNumber <= 19)
        {
            player1currenthealth += 8;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth += 10;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth += 9;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
            lastusedmove = "TeamHeal";
            switchPlayer();
        }
        if (rollNumber ==20)
        {
            player1currenthealth += 10;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth += 15;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth += 13;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
            lastusedmove = "TeamHeal";
            switchPlayer();
        }
    }

    public IEnumerator FatesGambitCoroutine()
    {
        int rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);

        if(rageactive == false)
        {
            if (rollNumber >= 1 && rollNumber <= 10)
            {
                int partymemeberdies = Random.Range(1, 4);
                if (partymemeberdies == 1)
                {
                    player1currenthealth = 0;
                    Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
                    lastusedmove = "FatesGambit";
                    switchPlayer();
                }
                if (partymemeberdies == 2)
                {
                    player2currenthealth = 0;
                    Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
                    lastusedmove = "FatesGambit";
                    switchPlayer();
                }
                if (partymemeberdies == 3)
                {
                    player3currenthealth = 0;
                    Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
                    lastusedmove = "FatesGambit";
                    switchPlayer();
                }
                int partymeamberhalfhealth = Random.Range(1, 3);
                if (partymeamberhalfhealth == 1)
                {
                    if (partymemeberdies == 1)
                    {
                        halvingcurrenthealth = player2currenthealth / 2;
                        player2currenthealth = halvingcurrenthealth;
                        Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
                        lastusedmove = "FatesGambit";
                        switchPlayer();
                    }
                    else
                    {
                        halvingcurrenthealth = player1currenthealth / 2;
                        player1currenthealth = halvingcurrenthealth;
                        Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
                        lastusedmove = "FatesGambit";
                        switchPlayer();
                    }
                }
                if (partymeamberhalfhealth == 2)
                {
                    if (partymemeberdies == 2)
                    {
                        halvingcurrenthealth = player3currenthealth / 2;
                        player3currenthealth = halvingcurrenthealth;
                        Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
                        lastusedmove = "FatesGambit";
                        switchPlayer();
                    }
                    else
                    {
                        halvingcurrenthealth = player2currenthealth / 2;
                        player2currenthealth = halvingcurrenthealth;
                        Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
                        lastusedmove = "FatesGambit";
                        switchPlayer();
                    }
                }
            }
            if (rollNumber >= 11 && rollNumber <= 20)
            {
                halvingcurrenthealth = bosscurrenthealth / 2;
                bosscurrenthealth = halvingcurrenthealth;
                Bosshealth.text = bosscurrenthealth.ToString() + "/" + bossmaxhealth;
                lastusedmove = "FatesGambit";
                switchPlayer();
            }
        }

        if(rageactive == true)
        {
            if (rollNumber >= 1 && rollNumber <= 5)
            {
                int partymemeberdies = Random.Range(1, 4);
                if (partymemeberdies == 1)
                {
                    player1currenthealth = 0;
                    Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
                    lastusedmove = "FatesGambit";
                    switchPlayer();
                }
                if (partymemeberdies == 2)
                {
                    player2currenthealth = 0;
                    Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
                    lastusedmove = "FatesGambit";
                    switchPlayer();
                }
                if (partymemeberdies == 3)
                {
                    player3currenthealth = 0;
                    Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
                    lastusedmove = "FatesGambit";
                    switchPlayer();
                }
                int partymeamberhalfhealth = Random.Range(1, 3);
                if (partymeamberhalfhealth == 1)
                {
                    if (partymemeberdies == 1)
                    {
                        halvingcurrenthealth = player2currenthealth / 2;
                        player2currenthealth = halvingcurrenthealth;
                        Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
                        lastusedmove = "FatesGambit";
                        switchPlayer();
                    }
                    else
                    {
                        halvingcurrenthealth = player1currenthealth / 2;
                        player1currenthealth = halvingcurrenthealth;
                        Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
                        lastusedmove = "FatesGambit";
                        switchPlayer();
                    }
                }
                if (partymeamberhalfhealth == 2)
                {
                    if (partymemeberdies == 2)
                    {
                        halvingcurrenthealth = player3currenthealth / 2;
                        player3currenthealth = halvingcurrenthealth;
                        Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
                        lastusedmove = "FatesGambit";
                        switchPlayer();
                    }
                    else
                    {
                        halvingcurrenthealth = player2currenthealth / 2;
                        player2currenthealth = halvingcurrenthealth;
                        Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
                        lastusedmove = "FatesGambit";
                        switchPlayer();
                    }
                }
            }
            if (rollNumber >= 6 && rollNumber <= 20)
            {
                halvingcurrenthealth = bosscurrenthealth / 2;
                bosscurrenthealth = halvingcurrenthealth;
                Bosshealth.text = bosscurrenthealth.ToString() + "/" + bossmaxhealth;
                lastusedmove = "FatesGambit";
                switchPlayer();
            }
            rageactive = false;
        }
    }

    public IEnumerator ChaosChaosCoroutine()
    {
        player3currentmana = player3currentmana - 5;
        Player3mana.text = player3currentmana.ToString() + "/" + player3maxmana;
        int rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);

        if(rollNumber >= 1 && rollNumber <= 5)
        {
            lastusedmove = "ChaosChaos";
            switchPlayer();
        }
        if(rollNumber >= 6 && rollNumber <= 20)
        {
            isbossconfused = true;
            bossconfusion.SetActive(true);
            lastusedmove = "ChaosChaos";
            switchPlayer();
        }
    }
    
    public IEnumerator FireballCoroutine()
    {
        player1currentmana = player1currentmana - 10;
        Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
        int rollNumber = playerroll();
        int rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);

        rollNumber = playerroll();
        rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);

        rollNumber = playerroll();
        rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);

        differenceinroll = rollNumber - rollBossnumber;

        if(differenceinroll <0)
        {
            player1currenthealth = player1currenthealth - 1;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth = player2currenthealth - 1;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth = player3currenthealth - 1;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
            lastusedmove = "Fireball";
            switchPlayer();
        }
        if (differenceinroll >=1 && differenceinroll >=5)
        {
            player1currenthealth = player1currenthealth - 1;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth = player2currenthealth - 1;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth = player3currenthealth - 1;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
            lastusedmove = "Fireball";
            switchPlayer();
        }
        if(differenceinroll > 6 && differenceinroll >= 10)
        {
            damagetoboss = 1;
            lastusedmove = "Fireball";
            switchPlayer();
        }
        if (differenceinroll > 11 && differenceinroll >= 15)
        {
            damagetoboss = 3;
            lastusedmove = "Fireball";
            switchPlayer();
        }
        if (differenceinroll > 16 && differenceinroll >= 20)
        {
            damagetoboss = 5;
            lastusedmove = "Fireball";
            switchPlayer();
        }

        if (damagetoboss > 0)
        {
            bossdamagetransitionvalue = bosscurrenthealth;
            bosscurrenthealth = bossdamagetransitionvalue - damagetoboss;
            Bosshealth.text = bosscurrenthealth.ToString() + "/" + bossmaxhealth;
            damagetoboss = 0;

        }
    }

    public IEnumerator bounterfulbonkCoroutine()
    {
        player2currentmana = player2currentmana - 15;
        Player2mana.text = player2currentmana.ToString() + "/" + player2maxmana;

        int rollNumber = playerroll();
        int rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);

        rollNumber = playerroll();
        rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);

        rollNumber = playerroll();
        rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);

        differenceinroll = rollNumber - rollBossnumber;

        if(differenceinroll < 0)
        {
            damagetoboss = -5 * ragemultiplier;
            Bosshealth.text = bosscurrenthealth.ToString() + "/" + bossmaxhealth;
            switchPlayer();
        }
        if(differenceinroll == 0)
        {
            damagetoboss = -3 * ragemultiplier;
            Bosshealth.text = bosscurrenthealth.ToString() + "/" + bossmaxhealth;
            switchPlayer();
        }
        if(differenceinroll >= 1 && differenceinroll <= 5)
        {
            damagetoboss = 4 * ragemultiplier;
            Bosshealth.text = bosscurrenthealth.ToString() + "/" + bossmaxhealth;
            lifestealamount = damagetoboss / 4;
            player2currenthealth = player2currenthealth + lifestealamount;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            rageactive = false;
            switchPlayer();
        }
        if (differenceinroll >= 6 && differenceinroll <= 10)
        {
            damagetoboss = 6 * ragemultiplier;
            Bosshealth.text = bosscurrenthealth.ToString() + "/" + bossmaxhealth;
            lifestealamount = damagetoboss / 4;
            player2currenthealth = player2currenthealth + lifestealamount;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            rageactive = false;
            switchPlayer();
        }
        if (differenceinroll >= 11 && differenceinroll <= 15)
        {
            damagetoboss = 8 * ragemultiplier;
            Bosshealth.text = bosscurrenthealth.ToString() + "/" + bossmaxhealth;
            lifestealamount = damagetoboss / 4;
            player2currenthealth = player2currenthealth + lifestealamount;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            rageactive = false;
            switchPlayer();
        }
        if (differenceinroll >= 16 && differenceinroll <= 20)
        {
            damagetoboss = 10 * ragemultiplier;
            Bosshealth.text = bosscurrenthealth.ToString() + "/" + bossmaxhealth;
            lifestealamount = damagetoboss / 4;
            player2currenthealth = player2currenthealth + lifestealamount;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            rageactive = false;
            switchPlayer();
        }

        if (damagetoboss != 0)
        {
            bossdamagetransitionvalue = bosscurrenthealth;
            bosscurrenthealth = bossdamagetransitionvalue - damagetoboss;
            Bosshealth.text = bosscurrenthealth.ToString() + "/" + bossmaxhealth;
            damagetoboss = 0;

        }

    }

    public IEnumerator UltimateRageCoroutine()
    {
        player2currentmana = player2currentmana - 10;
        Player2mana.text = player2currentmana.ToString() + "/" + player2maxmana;
        int rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);

        if(rollNumber == 1)
        {
            player2currenthealth = player2currenthealth - 5;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            switchPlayer();
        }
        if (rollNumber > 1 && rollNumber <=5)
        {
            player2currenthealth = player2currenthealth - 3;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            switchPlayer();
        }
        if (rollNumber > 5)
        {
            rageactive = true;
            switchPlayer();
        }
    }

    public IEnumerator TeamBarrierCoroutine()
    {

        player3currentmana = player3currentmana - 10;
        Player3mana.text = player3currentmana.ToString() + "/" + player3maxmana;
        int rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);

        if(rollNumber == 1)
        {
            Debug.Log("barrier failiure 1");
            player1currenthealth = player1currenthealth - 3;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth = player2currenthealth - 3;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth = player3currenthealth - 3;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
            switchPlayer();

        }
        if (rollNumber >= 2 && rollNumber <=7)
        {
            Debug.Log("barrier faliure 2");
            player1currenthealth--;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth--;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth--;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
            switchPlayer();
        }
        if (rollNumber >= 8 && rollNumber <= 20)
        {
            Debug.Log("barrier active");
            turnsleftofbarrier = 3;
            barrieractive = true;
            switchPlayer();
        }
    }

    public IEnumerator ThunderboltCoroutine()
    {

        player1currentmana = player1currentmana - 20;
        Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
        int rollNumber = playerroll();
        int rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);

        rollNumber = playerroll();
        rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);

        rollNumber = playerroll();
        rollBossnumber = bossroll();
        yield return new WaitForSeconds(.2F);

        differenceinroll = rollNumber - rollBossnumber;

        if (differenceinroll <= 0)
        {
            player1currenthealth = player1currenthealth - 2;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth = player2currenthealth - 3;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth = player3currenthealth - 4;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
            switchPlayer();

        }
        if (differenceinroll >= 1 && differenceinroll <= 5)
        {
            player2currenthealth = player2currenthealth - 1;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth = player3currenthealth - 2;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
            switchPlayer();
        }
        if (differenceinroll >= 6 && differenceinroll <= 10)
        {
            damagetoboss = 2;
            if(isbossconfused == false)
            {
                parachancetostatus = Random.Range(1, 5);
                if(parachancetostatus == 1)
                {
                    isbossparalysed = true;
                }
                else
                {
                    isbossparalysed = false;
                }
            }
            switchPlayer();
        }
        if (differenceinroll >= 11 && differenceinroll <= 14)
        {
            damagetoboss = 3;
            if (isbossconfused == false)
            {
                parachancetostatus = Random.Range(1, 5);
                if (parachancetostatus == 1)
                {
                    isbossparalysed = true;
                }
                else
                {
                    isbossparalysed = false;
                }
            }
            switchPlayer();
        }
        if (differenceinroll >= 15 && differenceinroll <= 19)
        {
            damagetoboss = 5;
            if (isbossconfused == false)
            {
                parachancetostatus = Random.Range(1, 5);
                if (parachancetostatus > 2)
                {
                    isbossparalysed = true;
                }
                else
                {
                    isbossparalysed = false;
                }
            }
            switchPlayer();
        }
        if (differenceinroll == 20)
        {
            damagetoboss = 7;
            if (isbossconfused == false)
            {
                parachancetostatus = Random.Range(1, 5);
                if (parachancetostatus > 3)
                {
                    isbossparalysed = true;
                }
                else
                {
                    isbossparalysed = false;
                }
            }
            switchPlayer();
        }

        if (damagetoboss > 0)
        {
            bossdamagetransitionvalue = bosscurrenthealth;
            bosscurrenthealth = bossdamagetransitionvalue - damagetoboss;
            Bosshealth.text = bosscurrenthealth.ToString() + "/" + bossmaxhealth;
            damagetoboss = 0;

        }
    }

    void bossturn()
    {
        if(currentturn == "Boss")
        {
            if(isbossparalysed == true)
            {
                parachancehappen = Random.Range(1, 5);

                if (parachancehappen == 1)
                {
                    isbossparalysed = false;
                    Debug.Log("Fully paraed");
                    switchPlayer();
                }
                else
                {
                    if (isbossconfused == true)
                    {
                        int confusionroll = Random.Range(1, 3);
                        if (confusionroll == 1)
                        {
                            bosscurrenthealth = bosscurrenthealth - 5;
                            Bosshealth.text = bosscurrenthealth.ToString() + "/100";
                            isbossconfused = false;
                            bossconfusion.SetActive(false);
                            currentturn = "Player1";
                        }
                        if (confusionroll == 2)
                        {
                            if (currentturn == "Boss")
                            {
                                var bossmoverandomiser = Random.Range(1, 11);
                                bossmoveslot = bossmoverandomiser;

                                if (bossmoverandomiser == 1)
                                {
                                    Debug.Log("move 1");
                                    currentturn = "Player1";
                                    whosTurnText.text = currentturn + "'s turn";
                                }
                                if (bossmoverandomiser >= 2 && bossmoverandomiser < 6)
                                {
                                    Debug.Log("move 2");
                                    currentturn = "Player1";
                                    whosTurnText.text = currentturn + "'s turn";
                                }
                                if (bossmoverandomiser >= 6 && bossmoverandomiser < 8)
                                {
                                    Debug.Log("move 3");
                                    currentturn = "Player1";
                                    whosTurnText.text = currentturn + "'s turn";
                                }
                                if (bossmoverandomiser >= 8 && bossmoverandomiser < 11)
                                {
                                    Debug.Log("move 4");
                                    currentturn = "Player1";
                                    whosTurnText.text = currentturn + "'s turn";
                                }
                            }
                        }
                    }
                    if (isbossconfused == false)
                    {
                        if (currentturn == "Boss")
                        {
                            var bossmoverandomiser = Random.Range(1, 11);
                            bossmoveslot = bossmoverandomiser;

                            if (bossmoverandomiser == 1)
                            {
                                StartCoroutine(Fallingdebree());
                                Debug.Log("move 1");
                                currentturn = "Player1";
                                whosTurnText.text = currentturn + "'s turn";
                            }
                            if (bossmoverandomiser >= 2 && bossmoverandomiser < 6)
                            {
                                Debug.Log("move 2");
                                currentturn = "Player1";
                                whosTurnText.text = currentturn + "'s turn";
                            }
                            if (bossmoverandomiser >= 6 && bossmoverandomiser < 8)
                            {
                                Debug.Log("move 3");
                                currentturn = "Player1";
                                whosTurnText.text = currentturn + "'s turn";
                            }
                            if (bossmoverandomiser >= 8 && bossmoverandomiser < 11)
                            {
                                Debug.Log("move 4");
                                currentturn = "Player1";
                                whosTurnText.text = currentturn + "'s turn";
                            }
                        }
                    }
                }
            }
        }
    }

    void switchPlayer()
    {

        NOMANA.SetActive(false);
        if (currentturn == "Player3")
        {
            currentturn = "Boss";
        }
        if (currentturn == "Player2")
        {
            currentturn = "Player3";
        }
        if (currentturn == "Player1")
        {
            currentturn = "Player2";
        }
        if (currentturn == "Boss")
        {
            currentturn = "Player1";
        }


    }

}