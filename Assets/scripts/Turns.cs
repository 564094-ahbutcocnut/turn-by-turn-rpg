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

    int differenceinroll = 0;
    int damagetoboss = 0;

    int bossdamagetransitionvalue = 0;

    int bossmoveslot = 0;

    



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
        Debug.Log("Team Heal");
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

    void bossturn()
    {
        if(currentturn == "Boss")
        {
            var bossmoverandomiser = Random.Range(1, 11);
            bossmoveslot = bossmoverandomiser;

            if(bossmoverandomiser == 1)
            {
                Debug.Log("move 1");
                currentturn = "notboss";
            }
            if (bossmoverandomiser >= 2  && bossmoverandomiser <6)
            {
                Debug.Log("move 2");
                currentturn = "notboss";
            }
            if (bossmoverandomiser >=6 && bossmoverandomiser <8)
            {
                Debug.Log("move 3");
                currentturn = "notboss";
            }
            if (bossmoverandomiser >=8 && bossmoverandomiser <11)
            {
                Debug.Log("move 4");
                currentturn = "notboss";
            }
        }
    }

}