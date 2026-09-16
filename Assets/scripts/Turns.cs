using TMPro;
using UnityEngine;
using System.Collections;

public class Turns : MonoBehaviour
{
    [Header("Rolls")]
    [SerializeField] TextMeshProUGUI PlayerRoll;
    [SerializeField] TextMeshProUGUI BossRoll;

    [Header("Health")]
    [SerializeField] TextMeshProUGUI Player1health;
    [SerializeField] TextMeshProUGUI Player2health;
    [SerializeField] TextMeshProUGUI Player3health;
    [SerializeField] TextMeshProUGUI Bosshealth;

    [Header("who's turn")]
    [SerializeField] public string currentturn;
    [SerializeField] TextMeshProUGUI whosTurnText;

    [Header("status")]
    [SerializeField] GameObject bossconfusion;

    int wheelrollsPlayers = 0;
    int wheelrollsBoss = 0;

    public int player1maxhealth = 15;
    int player2maxthealth = 30;
    int player3maxhealth = 20;
    int bossmaxhealth = 100;

    public int player1currenthealth = 0;
    int player2currenthealth = 0;
    int player3currenthealth = 0;
    int bosscurrenthealth = 0;

    int halvingcurrenthealth = 0;

    int differenceinroll = 0;
    int damagetoboss = 0;

    int bossdamagetransitionvalue = 0;

    int bossmoveslot = 0;


    public bool player1dead = false;
    public bool player2dead = false;
    public bool player3dead = false;

    bool isbossconfused = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player1currenthealth = player1maxhealth;
        player2currenthealth = player2maxthealth;
        player3currenthealth = player3maxhealth;
        bosscurrenthealth = bossmaxhealth;

        PlayerRoll.text = wheelrollsPlayers.ToString();
        BossRoll.text = wheelrollsBoss.ToString();
        Player1health.text = player1currenthealth.ToString() + "/15";
        Player2health.text = player2currenthealth.ToString() + "/30";
        Player3health.text = player3currenthealth.ToString() + "/20";
        Bosshealth.text = bosscurrenthealth.ToString() + "/100";
        whosTurnText.text = currentturn + "'s turn";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

                //Start the coroutine we define below named ExampleCoroutine.
               // StartCoroutine(ExampleCoroutine());
                
         
          

        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            bossroll();
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            player1currenthealth++;
            Player3health.text = player3currenthealth.ToString() + "/20";



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

        if(player1currenthealth > player1maxhealth)
        {
            player1currenthealth = player1maxhealth;
            Player1health.text = player1currenthealth.ToString() + "/15";
            Debug.Log("health reset ");
        }
        if (player2currenthealth > player2maxthealth)
        {
            player2currenthealth = player2maxthealth;
            Player2health.text = player2currenthealth.ToString() + "/30";
        }
        if (player3currenthealth > player3maxhealth)
        {
            player3currenthealth = player3maxhealth;
            Player3health.text = player3currenthealth.ToString() + "/20";
        }
        if (bosscurrenthealth > bossmaxhealth)
        {
            bosscurrenthealth = bossmaxhealth;
            Bosshealth.text = bosscurrenthealth.ToString() + "/100";
        }

        if(player1currenthealth <= 0)
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

        if(isbossconfused == true)
        {
            bossconfusion.SetActive(true);
        }
        if (isbossconfused == false)
        {
            bossconfusion.SetActive(false);
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
        BossRoll.text = wheelrollsBoss.ToString();

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

    public  IEnumerator BlackHoleeCoroutine()
    {


            int rollNumber = playerroll();
            int rollBossnumber = bossroll();
            

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(.2F);

             rollNumber = playerroll();
             rollBossnumber = bossroll();
            

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(.2F);

            rollNumber = playerroll();
            rollBossnumber = bossroll();
            

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(.2F);

            rollNumber = playerroll();
            rollBossnumber = bossroll();
            
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(.2F);

            rollNumber = playerroll();
            rollBossnumber = bossroll();
            


        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(.2F);

            differenceinroll = rollNumber - rollBossnumber;


                if (differenceinroll == 0)
                {
                    damagetoboss = 0;
                }
                if (differenceinroll >= 1 && differenceinroll <= 5)
                {
                    damagetoboss = 1;
                }
                if (differenceinroll >= 6 && differenceinroll <= 10)
                {
                    damagetoboss = 3;
                }
                if (differenceinroll >= 11 && differenceinroll <= 14)
                {
                    damagetoboss = 5;
                }
                if (differenceinroll >= 15 && differenceinroll <= 19)
                {
                    damagetoboss = 7;
                }
                if (differenceinroll == 20)
                {
                    damagetoboss = 10;
                }

                if (damagetoboss > 0)
                {
                    bossdamagetransitionvalue = bosscurrenthealth;
                    bosscurrenthealth = bossdamagetransitionvalue - damagetoboss;
                    Bosshealth.text = bosscurrenthealth.ToString() + "/100";
                    damagetoboss = 0;

                }

    }

    public IEnumerator TeamHealCoroutine()
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

        
        if(rollNumber == 1)
        {
            player1currenthealth--;
            Player1health.text = player1currenthealth.ToString() + "/15";
            player2currenthealth--;
            Player2health.text = player2currenthealth.ToString() + "/30";
            player3currenthealth--;
            Player3health.text = player3currenthealth.ToString() + "/20";
        }
        if (rollNumber >= 2 && rollNumber <= 5)
        {
            player1currenthealth++;
            Player1health.text = player1currenthealth.ToString() + "/15";
            player2currenthealth++;
            Player2health.text = player2currenthealth.ToString() + "/30";
            player3currenthealth++;
            Player3health.text = player3currenthealth.ToString() + "/20";
        }
        if(rollNumber >= 6 && rollNumber <= 10)
        {
            player1currenthealth += 3;
            Player1health.text = player1currenthealth.ToString() + "/15";
            player2currenthealth += 5;
            Player2health.text = player2currenthealth.ToString() + "/30";
            player3currenthealth += 4;
            Player3health.text = player3currenthealth.ToString() + "/20";
        }
        if (rollNumber >= 11 && rollNumber <= 15)
        {
            player1currenthealth += 5;
            Player1health.text = player1currenthealth.ToString() + "/15";
            player2currenthealth += 7;
            Player2health.text = player2currenthealth.ToString() + "/30";
            player3currenthealth += 6;
            Player3health.text = player3currenthealth.ToString() + "/20";
        }
        if (rollNumber >= 16 && rollNumber <= 19)
        {
            player1currenthealth += 8;
            Player1health.text = player1currenthealth.ToString() + "/15";
            player2currenthealth += 10;
            Player2health.text = player2currenthealth.ToString() + "/30";
            player3currenthealth += 9;
            Player3health.text = player3currenthealth.ToString() + "/20";
        }
        if (rollNumber ==20)
        {
            player1currenthealth += 10;
            Player1health.text = player1currenthealth.ToString() + "/15";
            player2currenthealth += 15;
            Player2health.text = player2currenthealth.ToString() + "/30";
            player3currenthealth += 13;
            Player3health.text = player3currenthealth.ToString() + "/20";
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

        if(rollNumber>= 1 && rollNumber <= 10)
        {
            int partymemeberdies = Random.Range(1, 4);
            if(partymemeberdies == 1)
            {
                player1currenthealth = 0;
                Player1health.text = player1currenthealth.ToString() + "/15";
            }
            if (partymemeberdies == 2)
            {
                player2currenthealth = 0;
                Player2health.text = player2currenthealth.ToString() + "/30";
            }
            if (partymemeberdies == 3)
            {
                player3currenthealth = 0;
                Player3health.text = player3currenthealth.ToString() + "/20";
            }
            int partymeamberhalfhealth = Random.Range(1, 3);
            if(partymeamberhalfhealth == 1)
            {
                if(partymemeberdies == 1)
                {
                    halvingcurrenthealth = player2currenthealth / 2;
                    player2currenthealth = halvingcurrenthealth;
                    Player2health.text = player2currenthealth.ToString() + "/30";
                }
                else
                {
                    halvingcurrenthealth = player1currenthealth / 2;
                    player1currenthealth = halvingcurrenthealth;
                    Player1health.text = player1currenthealth.ToString() + "/15";
                }
            }
            if(partymeamberhalfhealth == 2)
            {
                if(partymemeberdies == 2)
                {
                    halvingcurrenthealth = player3currenthealth / 2;
                    player3currenthealth = halvingcurrenthealth;
                    Player3health.text = player3currenthealth.ToString() + "/20";
                }
                else
                {
                    halvingcurrenthealth = player2currenthealth / 2;
                    player2currenthealth = halvingcurrenthealth;
                    Player2health.text = player2currenthealth.ToString() + "/30";
                }   
            }
        } 
        if(rollNumber >=11 && rollNumber <=20)
        {
            halvingcurrenthealth = bosscurrenthealth / 2;
            bosscurrenthealth = halvingcurrenthealth;
            Bosshealth.text = bosscurrenthealth.ToString() + "/100";
        }
    }

    public IEnumerator ChaosChaosCoroutine()
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

        if(rollNumber >= 1 && rollNumber <= 5)
        {
            FatesGambit();
        }
        if(rollNumber >= 6 && rollNumber <= 20)
        {
            isbossconfused = true;
            bossconfusion.SetActive(true);
        }
    }

    void bossturn()
    {
        if(currentturn == "Boss")
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