using System.Collections;
using TMPro;
using UnityEngine;

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

    int wheelrollsPlayers = 0;
    int wheelrollsBoss = 0;

    public int player1currenthealth = 15;
    int player2currenthealth = 30;
    int player3currenthealth = 20;
    int bosscurrenthealth = 100;

    int differenceinroll = 0;
    int damagetoboss = 0;

    int bossdamagetransitionvalue = 0;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRoll.text = wheelrollsPlayers.ToString();
        BossRoll.text = wheelrollsBoss.ToString();
        Player1health.text = player1currenthealth.ToString() + "/15";
        Player2health.text = player2currenthealth.ToString() + "/30";
        Player3health.text = player3currenthealth.ToString() + "/20";
        Bosshealth.text = bosscurrenthealth.ToString() + "/100";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            playerroll();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            bossroll();
        }

        if (damagetoboss > 0)
        {
            bossdamagetransitionvalue = bosscurrenthealth;
            bosscurrenthealth = bossdamagetransitionvalue - damagetoboss;
            Bosshealth.text = bosscurrenthealth.ToString() + "/100";
            damagetoboss = 0;

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Blackhole();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            player1currenthealth--;
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

    int Blackhole()
    {
        playerroll();
        bossroll();

        differenceinroll = wheelrollsPlayers - wheelrollsBoss;

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
        return damagetoboss;


    }


}