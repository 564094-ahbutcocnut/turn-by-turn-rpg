using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class enemies : MonoBehaviour
{

    [SerializeField] Turns turns;
    [SerializeField] RandonEncounters randomencounters;
    [SerializeField] EnemyTurns enemyturns;
    [SerializeField] GameObject whoyouwinisstored;


    [SerializeField] TextMeshProUGUI battlewintest; 
    string whatwillbeinwintext= "You won the battle";

    [Header("Enemyencounters")]

    [Header("Area 1")]
    [SerializeField] GameObject Goblin;
    int Goblinmaxhealth = 20;
    [SerializeField] GameObject Rocky;
    int Rockymaxhealth = 50;
    [SerializeField] GameObject Slime;
    int Slimemaxhealth = 10;
    [SerializeField] GameObject swordmage;
    int swordmagemaxhealth = 100;

    [Header("Area 2")]
    [SerializeField] GameObject Cactus;
    int Cactusmaxhealth = 75;
    [SerializeField] GameObject minihydra;
    int minihydramaxhealth = 40;
    [SerializeField] GameObject ArmouredScorpion;
    int ArmouredScorpionmaxhealth = 80;
    [SerializeField] GameObject sandworm;
    int sandwormmaxhealth = 150;

    [Header("Area 3")]
    [SerializeField] GameObject GiantHydra;
    int GiantHydramaxhealth = 150;
    [SerializeField] GameObject lavamonster;
    int lavamonstermaxhealth = 200;
    [SerializeField] GameObject lavabeatle;
    int lavabeatlemaxhealth = 175;
    [SerializeField] GameObject AreaBoss3;

    [Header("Area final")]
    [SerializeField] GameObject Bossminion1;
    [SerializeField] GameObject Bossminion2;
    [SerializeField] GameObject Bossminion3;
    [SerializeField] GameObject AreaBossFinal;





    public bool summoningnewenemy = false;

    Transform currentenemies;
    // Start is called before the first frame update
    void Start()
    {
        turns.enemycurrenthealth = 1;
        currentenemies = GameObject.Find("currentenemies").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if(summoningnewenemy == true)
        {
            Startingnewbattle();
        }

        if(turns.enemycurrenthealth < 0)
        {
            turns.enemycurrenthealth = 0;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
        }

        if(turns.enemycurrenthealth == 0)
        {
            turns.enemycurrenthealth = 1;
            StartCoroutine(textforyouwin());
        }
    }


    public void Startingnewbattle()
    {
        var determineenemy = Random.Range(1, 100);

        if(randomencounters.currentenemy == "Goblin")
        {
            turns.inbattle = true;
            turns.enemymaxhealth = Goblinmaxhealth;
            turns.enemycurrenthealth = turns.enemymaxhealth;
            var enemyType = determineenemy < 90 ? Goblin : Goblin;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemies);
            turns.Enemyhealth = enemy.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            summoningnewenemy = false;
            randomencounters.increasingnumber = 0;
            
        }
        if (randomencounters.currentenemy == "Rocky")
        {
            turns.inbattle = true;
            turns.enemymaxhealth = Rockymaxhealth;
            turns.enemycurrenthealth = turns.enemymaxhealth;
            var enemyType = determineenemy < 90 ? Rocky : Rocky;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemies);
            turns.Enemyhealth = enemy.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            summoningnewenemy = false;
        }
        if (randomencounters.currentenemy == "Slime")
        {
            turns.enemymaxhealth = Slimemaxhealth;
            turns.enemycurrenthealth = turns.enemymaxhealth;
            var enemyType = determineenemy < 90 ? Slime : Slime;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemies);
            turns.Enemyhealth = enemy.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            summoningnewenemy = false;
            turns.inbattle = true;
        }
        if (randomencounters.currentenemy == "Cactus")
        {
            turns.inbattle = true;
            turns.enemymaxhealth = Cactusmaxhealth;
            turns.enemycurrenthealth = turns.enemymaxhealth;
            var enemyType = determineenemy < 90 ? Cactus : Cactus;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemies);
            turns.Enemyhealth = enemy.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            summoningnewenemy = false;
        }
        if (randomencounters.currentenemy == "minihydra")
        {
            turns.inbattle = true;
            turns.enemymaxhealth = minihydramaxhealth;
            turns.enemycurrenthealth = turns.enemymaxhealth;
            var enemyType = determineenemy < 90 ? minihydra : minihydra;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemies);
            turns.Enemyhealth = enemy.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            summoningnewenemy = false;
        }
        if (randomencounters.currentenemy == "ArmouredScorpion")
        {
            turns.inbattle = true;
            turns.enemymaxhealth = ArmouredScorpionmaxhealth;
            turns.enemycurrenthealth = turns.enemymaxhealth;
            var enemyType = determineenemy < 90 ? ArmouredScorpion : ArmouredScorpion;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemies);
            turns.Enemyhealth = enemy.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            summoningnewenemy = false;
        }
        if (randomencounters.currentenemy == "GiantHydra")
        {
            turns.inbattle = true;
            turns.enemymaxhealth = GiantHydramaxhealth;
            turns.enemycurrenthealth = turns.enemymaxhealth;
            var enemyType = determineenemy < 90 ? GiantHydra : GiantHydra;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemies);
            turns.Enemyhealth = enemy.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            summoningnewenemy = false;
        }
        if (randomencounters.currentenemy == "lavamonster")
        {
            turns.inbattle = true;
            turns.enemymaxhealth = lavamonstermaxhealth;
            turns.enemycurrenthealth = turns.enemymaxhealth;
            var enemyType = determineenemy < 90 ? lavamonster : lavamonster;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemies);
            turns.Enemyhealth = enemy.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            summoningnewenemy = false;
        }
        if (randomencounters.currentenemy == "lavabeatle")
        {
            turns.inbattle = true;
            turns.enemymaxhealth = lavabeatlemaxhealth;            
            turns.enemycurrenthealth = turns.enemymaxhealth;
            var enemyType = determineenemy < 90 ? lavabeatle : lavabeatle;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemies);
            turns.Enemyhealth = enemy.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            summoningnewenemy = false;
        }
    }




    Vector2 CenterPosition()
    {
        Vector2 Centreposition = new Vector2(Random.Range(5, 5), Random.Range(0, 0));
        return Centreposition;
    }


    public void DestroyAllEnemies()
    {
        foreach (Transform e in currentenemies)
            Destroy(e.gameObject);
    }
    

    public void DisableBattleBackground()
    {
        randomencounters.forrestbattlebackground.SetActive(false);
        randomencounters.desertbattlebackground.SetActive(false);
        randomencounters.lavabattlebackground.SetActive(false);
    }

 
    public  IEnumerator textforyouwin()
    {
        randomencounters.increasingnumber = 0;
        whatwillbeinwintext = "you have won the battle";
        whoyouwinisstored.SetActive(true);
        yield return new WaitForSeconds(2F);
        whatwillbeinwintext = "You have gain exp";
        battlewintest.text = whatwillbeinwintext;
        yield return new WaitForSeconds(2F);
        whoyouwinisstored.SetActive(false);
        turns.enemycurrenthealth = 1;

        turns.isbossconfused = false;
        turns.isbossparalysed = false;
        turns.rageactive = false;
        turns.barrieractive = false;
        //turns.turnstillyoucanuseTeratonhammeragain = 0;
        DisableBattleBackground();

        turns.inbattle = false;
        DestroyAllEnemies();
        turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
        turns.Player1mana.text = turns.player1currentmana.ToString() + "/" + turns.player1maxmana;
        turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
        turns.Player2mana.text = turns.player2currentmana.ToString() + "/" + turns.player2maxmana;
        turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
        turns.player1currentmana = turns.player1maxmana;
        turns.Player1mana.text = turns.player1currentmana.ToString() + "/" + turns.player1maxmana;
        turns.player2currentmana = turns.player2maxmana;
        turns.Player2mana.text = turns.player2currentmana.ToString() + "/" + turns.player2maxmana;
        turns.player3currentmana = turns.player3maxmana;
        turns.Player3mana.text = turns.player3currentmana.ToString() + "/" + turns.player3maxmana;

        turns.currentturn = "Player1";
        turns.whosTurnText.text = turns.currentturn + "'s turn";
    }
    
}
