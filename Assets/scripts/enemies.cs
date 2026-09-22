using System.Collections;
using System.Collections.Generic;
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    Vector2 CenterPosition()
    {
        Vector2 Centreposition = new Vector2(Random.Range(0, 0), Random.Range(0, 0));
        return Centreposition;
    }
}
