using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class enemies : MonoBehaviour
{

    [SerializeField] Turns turns;
    [SerializeField] RandonEncounters randomencounters;

    [Header("Enemyencounters")]

    [Header("Area 1")]
    [SerializeField] GameObject Goblin;
    [SerializeField] GameObject Rocky;
    [SerializeField] GameObject Slime;
    [SerializeField] GameObject AreaBoss1;

    [Header("Area 2")]
    [SerializeField] GameObject Cactus;
    [SerializeField] GameObject minihydra;
    [SerializeField] GameObject ArmouredScorpion;
    [SerializeField] GameObject AreaBoss2;

    [Header("Area 3")]
    [SerializeField] GameObject GiantHydra;
    [SerializeField] GameObject lavamonster;
    [SerializeField] GameObject lavabeatle;
    [SerializeField] GameObject AreaBoss3;

    [Header("Area final")]
    [SerializeField] GameObject Bossminion1;
    [SerializeField] GameObject Bossminion2;
    [SerializeField] GameObject Bossminion3;
    [SerializeField] GameObject AreaBossFinal;

    public bool summoningnewenemy = false;

    Transform currentenemy;
    // Start is called before the first frame update
    void Start()
    {
        
        currentenemy = GameObject.Find("currentenemies").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Startingnewbattle()
    {
        var determineenemy = Random.Range(1, 100);

        if(randomencounters.currentenemy == "Goblin")
        {
            var enemyType = determineenemy < 90 ? Goblin : Goblin;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemy);
            turns.Bosshealth = enemy.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        }
        if (randomencounters.currentenemy == "Rocky")
        {
            var enemyType = determineenemy < 90 ? Rocky : Rocky;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemy);
        }
        if (randomencounters.currentenemy == "Slime")
        {
            var enemyType = determineenemy < 90 ? Slime : Slime;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemy);
        }
        if (randomencounters.currentenemy == "Cactus")
        {
            var enemyType = determineenemy < 90 ? Cactus : Cactus;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemy);
        }
        if (randomencounters.currentenemy == "minihydra")
        {
            var enemyType = determineenemy < 90 ? minihydra : minihydra;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemy);
        }
        if (randomencounters.currentenemy == "ArmouredScorpion")
        {
            var enemyType = determineenemy < 90 ? ArmouredScorpion : ArmouredScorpion;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemy);
        }
        if (randomencounters.currentenemy == "GiantHydra")
        {
            var enemyType = determineenemy < 90 ? GiantHydra : GiantHydra;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemy);
        }
        if (randomencounters.currentenemy == "lavamonster")
        {
            var enemyType = determineenemy < 90 ? lavamonster : lavamonster;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemy);
        }
        if (randomencounters.currentenemy == "lavabeatle")
        {
            var enemyType = determineenemy < 90 ? lavabeatle : lavabeatle;
            var enemy = Instantiate(enemyType, CenterPosition(), Quaternion.identity);
            enemy.transform.SetParent(currentenemy);
        }
    }




    Vector2 CenterPosition()
    {
        Vector2 Centreposition = new Vector2(Random.Range(0, 0), Random.Range(0, 0));
        return Centreposition;
    }
}
