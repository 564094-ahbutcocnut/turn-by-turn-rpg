using TMPro;
using UnityEngine;
using System.Collections;

public class Turns : MonoBehaviour
{

    [SerializeField] EnemyTurns enemyturns;

    [Header("Game states")]
    [SerializeField] GameObject BattleUI;
    [SerializeField] GameObject Overworld;

    [Header("Rolls")]
    [SerializeField] TextMeshProUGUI PlayerRoll;
    [SerializeField] TextMeshProUGUI EnemyRoll;

    [Header("Health")]
    [SerializeField] public TextMeshProUGUI Player1health;
    [SerializeField] public TextMeshProUGUI Player2health;
    [SerializeField] public TextMeshProUGUI Player3health;
    [SerializeField] public TextMeshProUGUI Enemyhealth;

    [Header("Mana")]
    [SerializeField] public TextMeshProUGUI Player1mana;
    [SerializeField] public TextMeshProUGUI Player2mana;
    [SerializeField] public TextMeshProUGUI Player3mana;
    [SerializeField] GameObject NOMANA;

    [Header("who's turn")]
    [SerializeField] public string currentturn;
    public bool isbossfight = false;
    [SerializeField] public TextMeshProUGUI whosTurnText;

    [Header("status")]
    [SerializeField] GameObject bossconfusion;
    [SerializeField] GameObject bossparalysed;
    [SerializeField] GameObject enraged;
    [SerializeField] GameObject barrier;

    [Header("battlestuff")]

    public bool inbattle = false;
    bool hasnotbeensetyet = false;

    int wheelrollsPlayers = 0;
    int wheelrollsEnemy = 0;

    public int player1maxhealth = 15;
    public int player2maxthealth = 30;
    public int player3maxhealth = 20;
    public int enemymaxhealth = 100;

    public int player1currenthealth = 0;
    public int player2currenthealth = 0;
    public int player3currenthealth = 0;
    public int enemycurrenthealth = 1;

    public int player1maxmana = 100;
    public int player2maxmana = 50;
    public int player3maxmana = 75;

    public int player1currentmana = 0;
    public int player2currentmana = 0;
    public int player3currentmana = 0;

    int halvingcurrenthealth = 0;

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

    public bool rageactive = false;
    int ragemultiplier = 1;

    public bool barrieractive = false;
    public int barrierreducer = 1;
    public int turnsleftofbarrier = 0;

    bool haschangedturns = false;

    public bool hasusedmove = false;

    public string lastusedmove = "";

    //public int turnstillyoucanuseTeratonhammeragain = 0;

    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (player1currenthealth < 0 && player1currenthealth > -100)
        {
            player1currenthealth = 0;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
        }
        if (player2currenthealth < 0)
        {
            player2currenthealth = 0;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
        }
        if (player3currenthealth < 0)
        {
            player3currenthealth = 0;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
        }



        if (player1dead == true && player2dead == true && player3dead == true)
        {
            StopAllCoroutines();
        }


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

        if (inbattle == true)
        {
            BattleUI.SetActive(true);
            Overworld.SetActive(false);


            if(hasnotbeensetyet == false)
            {
                player1currenthealth = player1maxhealth;
                player2currenthealth = player2maxthealth;
                player3currenthealth = player3maxhealth;
                enemycurrenthealth = enemymaxhealth;

                player1currentmana = player1maxmana;
                player2currentmana = player2maxmana;
                player3currentmana = player3maxmana;

                PlayerRoll.text = wheelrollsPlayers.ToString();
                EnemyRoll.text = wheelrollsEnemy.ToString();
                Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
                Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
                Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
                Player2mana.text = player2currentmana.ToString() + "/" + player2maxmana;
                Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
                Player3mana.text = player3currentmana.ToString() + "/" + player3maxmana;
                Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
                whosTurnText.text = currentturn + "'s turn";
                hasnotbeensetyet = true;
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
                currentturn = "Enemy";
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
            if (enemycurrenthealth > enemymaxhealth)
            {
                enemycurrenthealth = enemymaxhealth;
                Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
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
    public int enemyroll()
    {
        var enemyroll = Random.Range(1, 21);
        wheelrollsEnemy = enemyroll;
        EnemyRoll.text = wheelrollsEnemy.ToString();

        return wheelrollsEnemy;
    }



    public void Blackhole()
    {
        StartCoroutine(BlackHoleeCoroutine());
        hasusedmove = true;
    }

    public void TeamHeal()
    {
        StartCoroutine(TeamHealCoroutine());
        hasusedmove = true;
    }


    public void FatesGambit()
    {
        StartCoroutine(FatesGambitCoroutine());
        hasusedmove = true;
    }

    public void ChaosChaos()
    {
        StartCoroutine(ChaosChaosCoroutine());
        hasusedmove = true;
    }

    public void FireBall()
    {
        StartCoroutine(FireballCoroutine());
        hasusedmove = true;
    }

    public void bounterfulbonk()
    {
        StartCoroutine(bounterfulbonkCoroutine());
        hasusedmove = true;
    }

    public void UltimateRage()
    {
        StartCoroutine(UltimateRageCoroutine());
        hasusedmove = true;
    }

    public void TeamBarrier()
    {
        StartCoroutine(TeamBarrierCoroutine());
        hasusedmove = true;
    }

    public void Thunderbolt()
    {
        StartCoroutine(ThunderboltCoroutine());
        hasusedmove = true;
    }

    public void Nucruel()
    {
        StartCoroutine(NucruelCorcoutine());
        hasusedmove = true;
    }

    public void Staffpoke()
    {
        StartCoroutine(StaffpokeCoroutine());
        hasusedmove = true;
    }

    public void BasicBonk()
    {
        StartCoroutine(basicbonkCoroutine());
        hasusedmove = true;
    }

    public void energyblast()
    {
        StartCoroutine(energyblastCoroutine());
        hasusedmove = true;
    }

    public void teammanaregen()
    {
        StartCoroutine(teammanaregenCoroutine());
        hasusedmove = true;
    }

    public void TeratonHammer()
    {
        StartCoroutine(Teratonhammercoroutine());
    }
    IEnumerator Fallingdebree()
    {

        
        int rollEnemynumber = enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = enemyroll();
        yield return new WaitForSeconds(.2F);

        if(rollEnemynumber >= 1 && rollEnemynumber <= 5)
        {
            player1currenthealth = player1currenthealth - 2 / barrierreducer;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth = player2currenthealth - 2 / barrierreducer;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth = player3currenthealth - 2 / barrierreducer;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
        }
        if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
        {
            player1currenthealth = player1currenthealth - 4 / barrierreducer;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth = player2currenthealth - 4 / barrierreducer;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth = player3currenthealth - 4 / barrierreducer;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
        }
        if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
        {
            player1currenthealth = player1currenthealth - 7 / barrierreducer;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth = player2currenthealth - 7 / barrierreducer;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth = player3currenthealth - 7 / barrierreducer;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
        }
        if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
        {
            player1currenthealth = player1currenthealth - 10 / barrierreducer;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth = player2currenthealth - 10 / barrierreducer;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth = player3currenthealth - 10 / barrierreducer;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
        }
        if(rollEnemynumber == 20)
        {

            player1currenthealth = player1currenthealth - 15 / barrierreducer;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth = player2currenthealth - 15 / barrierreducer;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth = player3currenthealth - 15 / barrierreducer;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;

            if(barrieractive == true)
            {
                turnsleftofbarrier = 0;
            }
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
            yield return new WaitForSeconds(.2F);
            rollNumber = playerroll();
            yield return new WaitForSeconds(.2F);
            rollNumber = playerroll();
            yield return new WaitForSeconds(.2F);

            rollNumber = playerroll();
            yield return new WaitForSeconds(.2F);

            rollNumber = playerroll();
            yield return new WaitForSeconds(.2F);


            if (rollNumber >= 1 && rollNumber <= 5)
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
            if (rollNumber >= 6 && rollNumber <= 10)
            {
                damagetoboss = 3;
                lastusedmove = "Blackhole";
                switchPlayer();
            }
            if (rollNumber >= 11 && rollNumber <= 14)
            {
                damagetoboss = 5;
                lastusedmove = "Blackhole";
                switchPlayer();
            }
            if (rollNumber >= 15 && rollNumber <= 19)
            {
                damagetoboss = 7;
                lastusedmove = "Blackhole";
                switchPlayer();
            }
            if (rollNumber == 20)
            {
                damagetoboss = 10;
                lastusedmove = "Blackhole";
                switchPlayer();
            }

            if (damagetoboss > 0)
            {
                bossdamagetransitionvalue = enemycurrenthealth;
                enemycurrenthealth = bossdamagetransitionvalue - damagetoboss;
                Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
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

        if(currentturn == "Player2")
        {
            player2currentmana = player2currentmana - 5;
            Player2mana.text = player2currentmana.ToString() + "/" + player2maxmana;
        }
        if(currentturn == "Player3")
        {
            player3currentmana = player3currentmana - 5;
            Player3mana.text = player3currentmana.ToString() + "/" + player3maxmana;
        }

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
                halvingcurrenthealth = enemycurrenthealth / 2;
                enemycurrenthealth = halvingcurrenthealth;
                Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
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
                halvingcurrenthealth = enemycurrenthealth / 2;
                enemycurrenthealth = halvingcurrenthealth;
                Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
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
            switchPlayer(); ;
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
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);
        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);

        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);

        rollNumber = playerroll();
        yield return new WaitForSeconds(.2F);

        if (rollNumber > 0 && rollNumber <= 5)
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
        if(rollNumber > 5 && rollNumber <= 10)
        {
            damagetoboss = 1;
            lastusedmove = "Fireball";
            switchPlayer();
        }
        if (rollNumber > 10 && rollNumber <= 15)
        {
            damagetoboss = 3;
            lastusedmove = "Fireball";
            switchPlayer();
        }
        if (rollNumber > 15 && rollNumber <= 19)
        {
            damagetoboss = 5;
            lastusedmove = "Fireball";
            switchPlayer();
        }
        if(rollNumber == 20)
        {
            damagetoboss = 7;
            switchPlayer();
        }

        if (damagetoboss > 0)
        {
            bossdamagetransitionvalue = enemycurrenthealth;
            enemycurrenthealth = bossdamagetransitionvalue - damagetoboss;
            Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
            damagetoboss = 0;

        }
    }

    public IEnumerator bounterfulbonkCoroutine()
    {
        player2currentmana = player2currentmana - 15;
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

        if(rollNumber >= 1 && rollNumber <= 5)
        {
            damagetoboss = 4 * ragemultiplier;
            Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
            lifestealamount = damagetoboss / 4;
            player2currenthealth = player2currenthealth + lifestealamount;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            rageactive = false;
            switchPlayer();
        }
        if (rollNumber >= 6 && rollNumber <= 10)
        {
            damagetoboss = 6 * ragemultiplier;
            Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
            lifestealamount = damagetoboss / 4;
            player2currenthealth = player2currenthealth + lifestealamount;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            rageactive = false;
            switchPlayer();
        }
        if (rollNumber >= 11 && rollNumber <= 15)
        {
            damagetoboss = 8 * ragemultiplier;
            Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
            lifestealamount = damagetoboss / 4;
            player2currenthealth = player2currenthealth + lifestealamount;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            rageactive = false;
            switchPlayer();
        }
        if (rollNumber >= 16 && rollNumber <= 19)
        {
            damagetoboss = 10 * ragemultiplier;
            Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
            lifestealamount = damagetoboss / 4;
            player2currenthealth = player2currenthealth + lifestealamount;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            rageactive = false;
            switchPlayer();
        }
        if(rollNumber == 20)
        {
            damagetoboss = 15 * ragemultiplier;
            Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
            lifestealamount = damagetoboss / 4;
            player2currenthealth = player2currenthealth + lifestealamount;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
        }

        if (damagetoboss != 0)
        {
            bossdamagetransitionvalue = enemycurrenthealth;
            enemycurrenthealth = bossdamagetransitionvalue - damagetoboss;
            Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
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
        if (rollNumber >= 8 && rollNumber <= 19)
        {
            Debug.Log("barrier active");
            turnsleftofbarrier = 3;
            barrieractive = true;
            switchPlayer();
        }
        if(rollNumber == 20)
        {
            turnsleftofbarrier = 5;
            barrieractive = true;
            switchPlayer();
        }
    }

    public IEnumerator ThunderboltCoroutine()
    {

        player1currentmana = player1currentmana - 20;
        Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
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

        if (rollNumber >= 1 && rollNumber <= 5)
        {
            player2currenthealth = player2currenthealth - 1;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth = player3currenthealth - 2;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
            switchPlayer();
        }
        if (rollNumber >= 6 && rollNumber <= 10)
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
        if (rollNumber >= 11 && rollNumber <= 14)
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
        if (rollNumber >= 15 && rollNumber <= 19)
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
        if (rollNumber == 20)
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
            bossdamagetransitionvalue = enemycurrenthealth;
            enemycurrenthealth = bossdamagetransitionvalue - damagetoboss;
            Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
            damagetoboss = 0;

        }
    }

    public IEnumerator NucruelCorcoutine()
    {
        player1currentmana = player1currentmana - 25;
        Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
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
            player1currenthealth = player1currenthealth - 2;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            player2currenthealth = player2currenthealth - 2;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            player3currenthealth = player3currenthealth - 2;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
            switchPlayer();
        }
        if (rollNumber >= 6 && rollNumber <= 10)
        {
            damagetoboss = 2;
            switchPlayer();
        }
        if (rollNumber >= 11 && rollNumber <= 15)
        {
            damagetoboss = 4;
            switchPlayer();
        }
        if (rollNumber >= 16 && rollNumber <= 19)
        {
            damagetoboss = 6;
            switchPlayer();
        }
        if (rollNumber == 20)
        {
            damagetoboss = 8;
            switchPlayer();
        }

        if (damagetoboss > 0)
        {
            bossdamagetransitionvalue = enemycurrenthealth;
            enemycurrenthealth = bossdamagetransitionvalue - damagetoboss;
            Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
            damagetoboss = 0;

        }

    }

    public IEnumerator StaffpokeCoroutine()
    {
        player1currentmana = player1currentmana + 10;
        Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
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
            player1currenthealth = player1currenthealth - 1;
            Player1health.text = player1currenthealth.ToString() + "/" + player1maxhealth;
            switchPlayer();
        }
        if (rollNumber >= 6 && rollNumber <= 10)
        {
            player1currentmana = player1currentmana + 5;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            switchPlayer();
        }
        if (rollNumber >= 6 && rollNumber <= 10)
        {
            player1currentmana = player1currentmana + 10;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            damagetoboss = 1;
            switchPlayer();
        }
        if (rollNumber >= 11 && rollNumber <= 15)
        {
            player1currentmana = player1currentmana + 15;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            damagetoboss = 2;
            switchPlayer();
        }
        if (rollNumber >= 16 && rollNumber <= 19)
        {
            player1currentmana = player1currentmana + 20;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            damagetoboss = 3;
            switchPlayer();
        }  
        if (rollNumber == 20)
        {
            player1currentmana = player1currentmana + 50;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            damagetoboss = 3;
            switchPlayer();
        }

        if (damagetoboss > 0)
        {
            bossdamagetransitionvalue = enemycurrenthealth;
            enemycurrenthealth = bossdamagetransitionvalue - damagetoboss;
            Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
            damagetoboss = 0;
        }
    }

    public IEnumerator basicbonkCoroutine()
    {
        player2currentmana = player2currentmana + 5;
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

        if(rollNumber >= 1 && rollNumber <= 3)
        {
            player2currenthealth = player2currenthealth - 1;
            Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
            switchPlayer();
        }
        if (rollNumber >= 4 && rollNumber <= 10)
        {
            
            damagetoboss = 1;
            switchPlayer();
        }
        if (rollNumber >= 11 && rollNumber <= 15)
        {
            player1currentmana = player1currentmana + 5;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            damagetoboss = 2;
            switchPlayer();
        }
        if (rollNumber >= 16 && rollNumber <= 19)
        {
            player1currentmana = player1currentmana + 10;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            damagetoboss = 3;
            switchPlayer();
        }
        if (rollNumber == 20)
        {
            player1currentmana = player1currentmana + 15;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            damagetoboss = 4;
            switchPlayer();
        }
        if (damagetoboss > 0)
        {
            bossdamagetransitionvalue = enemycurrenthealth;
            enemycurrenthealth = bossdamagetransitionvalue - damagetoboss;
            Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
            damagetoboss = 0;

        }
    }

    public IEnumerator energyblastCoroutine()
    {
        player3currentmana = player3currentmana + 5;
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

        if(rollNumber >= 1 && rollNumber <= 2)
        {
            player3currenthealth = player3currenthealth - 1;
            Player3health.text = player3currenthealth.ToString() + "/" + player3maxhealth;
            switchPlayer();
        }
        if (rollNumber >= 3 && rollNumber <= 5)
        {
            player1currentmana = player1currentmana + 5;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            switchPlayer();
        }
        if (rollNumber >= 6 && rollNumber <= 10)
        {
            player1currentmana = player1currentmana + 5;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            damagetoboss = 1;
            switchPlayer();
        }
        if (rollNumber >= 11 && rollNumber <= 15)
        {
            player1currentmana = player1currentmana + 10;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            damagetoboss = 2;
            switchPlayer();
        }
        if (rollNumber >= 16 && rollNumber <= 19)
        {
            player1currentmana = player1currentmana + 10;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            damagetoboss = 3;
            switchPlayer();
        }
        if (rollNumber == 20)
        {
            player1currentmana = player1currentmana + 20;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            damagetoboss = 4;
            switchPlayer();
        }
        if (damagetoboss > 0)
        {
            bossdamagetransitionvalue = enemycurrenthealth;
            enemycurrenthealth = bossdamagetransitionvalue - damagetoboss;
            Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
            damagetoboss = 0;

        }
    }

    public IEnumerator teammanaregenCoroutine()
    {
        player3currentmana = player3currentmana - 40;
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

        if(rollNumber >= 1 && rollNumber <= 2)
        {
            player1currentmana = player1currentmana --;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            player2currentmana = player2currentmana --;
            Player2mana.text = player2currentmana.ToString() + "/" + player2maxmana;
            player3currentmana = player3currentmana --; 
            Player3mana.text = player3currentmana.ToString() + "/" + player3maxmana;
            switchPlayer();
        }
        if (rollNumber >= 3 && rollNumber <= 5)
        {
            player1currentmana = player1currentmana ++;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            player2currentmana = player2currentmana ++;
            Player2mana.text = player2currentmana.ToString() + "/" + player2maxmana;
            player3currentmana = player3currentmana ++;
            Player3mana.text = player3currentmana.ToString() + "/" + player3maxmana;
            switchPlayer();
        }
        if (rollNumber >= 6 && rollNumber <= 10)
        {
            player1currentmana = player1currentmana + 5;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            player2currentmana = player2currentmana + 5;
            Player2mana.text = player2currentmana.ToString() + "/" + player2maxmana;
            player3currentmana = player3currentmana + 5;
            Player3mana.text = player3currentmana.ToString() + "/" + player3maxmana;
            switchPlayer();
        }
        if (rollNumber >= 11 && rollNumber <= 15)
        {
            player1currentmana = player1currentmana + 10;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            player2currentmana = player2currentmana + 10;
            Player2mana.text = player2currentmana.ToString() + "/" + player2maxmana;
            player3currentmana = player3currentmana + 10;
            Player3mana.text = player3currentmana.ToString() + "/" + player3maxmana;
            switchPlayer();
        }
        if (rollNumber >= 16 && rollNumber <= 19)
        {
            player1currentmana = player1currentmana + 15;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            player2currentmana = player2currentmana + 15;
            Player2mana.text = player2currentmana.ToString() + "/" + player2maxmana;
            player3currentmana = player3currentmana + 15;
            Player3mana.text = player3currentmana.ToString() + "/" + player3maxmana;
            switchPlayer();
        }
        if (rollNumber == 20)
        {
            player1currentmana = player1currentmana + 25;
            Player1mana.text = player1currentmana.ToString() + "/" + player1maxmana;
            player2currentmana = player2currentmana + 25;
            Player2mana.text = player2currentmana.ToString() + "/" + player2maxmana;
            player3currentmana = player3currentmana + 25;
            Player3mana.text = player3currentmana.ToString() + "/" + player3maxmana;
            switchPlayer();
        }
    }

    public IEnumerator Teratonhammercoroutine()
    {
        //turnstillyoucanuseTeratonhammeragain = 2;
        player2currentmana = player2currentmana - 25;
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


        if(rageactive == false)
        {
            if (rollNumber >= 1 && rollNumber <= 3)
            {
                player2currenthealth = player2currenthealth - 5;
                Player2health.text = player2currenthealth.ToString() + "/" + player2maxthealth;
                switchPlayer();
            }
            if (rollNumber >= 4 && rollNumber <= 5)
            {
                damagetoboss = 3;
                switchPlayer();
            }
            if (rollNumber >= 6 && rollNumber <= 10)
            {
                damagetoboss = 5;
                switchPlayer();
            }
            if (rollNumber >= 11 && rollNumber <= 15)
            {
                damagetoboss = 7;
                switchPlayer();
            }
            if (rollNumber >= 16 && rollNumber <= 19)
            {
                damagetoboss = 10;
                switchPlayer();
            }
            if (rollNumber == 20)
            {
                damagetoboss = 15;
                switchPlayer();
            }
        }
        if (rageactive == true)
        {
            if (rollNumber >= 1 && rollNumber <= 5)
            {
                damagetoboss = 3;
                rageactive = false;
                switchPlayer();
            }
            if (rollNumber >= 6 && rollNumber <= 10)
            {
                damagetoboss = 5/2 * ragemultiplier;
                rageactive = false;
                switchPlayer();
            }
            if (rollNumber >= 11 && rollNumber <= 15)
            {
                damagetoboss = 7/2 * ragemultiplier;
                rageactive = false;
                switchPlayer();
            }
            if (rollNumber >= 16 && rollNumber <= 19)
            {
                damagetoboss = 10 * ragemultiplier;
                rageactive = false;
                switchPlayer();
            }
            if (rollNumber == 20)
            {
                damagetoboss = 15 * ragemultiplier;
                rageactive = false;
                switchPlayer();
            }
        }

        if (damagetoboss > 0)
        {
            bossdamagetransitionvalue = enemycurrenthealth;
            enemycurrenthealth = bossdamagetransitionvalue - damagetoboss;
            Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
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
                            enemycurrenthealth = enemycurrenthealth - 5;
                            Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
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

            if (isbossparalysed == false)
            {
                if (isbossconfused == true)
                {
                    int confusionroll = Random.Range(1, 3);
                    if (confusionroll == 1)
                    {
                        enemycurrenthealth = enemycurrenthealth - 5;
                        Enemyhealth.text = enemycurrenthealth.ToString() + "/" + enemymaxhealth;
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

    public void switchPlayer()
    {
        hasusedmove = false;
        haschangedturns = false;

        NOMANA.SetActive(false);

        if(enemycurrenthealth <=0)
        {
            currentturn = "NUH UH";
        }



        if(haschangedturns == false)
        {
            if (currentturn == "Player1")
            {
                currentturn = "Player2";
                whosTurnText.text = currentturn + "'s turn";
                haschangedturns = true;
            }
        }
        if(haschangedturns == false)
        {
            if (currentturn == "Player2")
            {
                currentturn = "Player3";
                whosTurnText.text = currentturn + "'s turn";
                haschangedturns = true;


                /*if(turnstillyoucanuseTeratonhammeragain > 0)
                {
                    turnstillyoucanuseTeratonhammeragain--;
                }*/
            }
        }
        if(haschangedturns == false)
        {
            if (currentturn == "Player3")
            {
                if (isbossfight == false)
                {
                    currentturn = "Enemy";
                    whosTurnText.text = currentturn + "'s turn";
                    haschangedturns = true;
                }
                if (isbossfight == true)
                {
                    currentturn = "Enemy";
                    whosTurnText.text = currentturn + "'s turn";
                    haschangedturns = true;
                }
            }
        }
        if (haschangedturns == false)
        {
            if (currentturn == "Boss")
            {
                currentturn = "Player1";
                whosTurnText.text = currentturn + "'s turn";
                haschangedturns = true;
            }
        }
        if(haschangedturns == false)
        {
            if (currentturn == "Enemy")
            {
                currentturn = "Player1";
                whosTurnText.text = currentturn + "'s turn";
                enemyturns.hasenemyusedattack = false;
                haschangedturns = true;
            }
        }
                          

    }

}