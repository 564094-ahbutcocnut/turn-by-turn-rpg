using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UnityEngine;

public class RandonEncounters : MonoBehaviour
{

    [SerializeField] Turns turns;
    [SerializeField] enemies Enemies;

    [SerializeField] public GameObject forrestbattlebackground;
    [SerializeField] public GameObject desertbattlebackground;
    [SerializeField] public GameObject lavabattlebackground;

    public string currentarea = "";


    int numbertillencounter = 2;
    public int increasingnumber = 0;

    int randomiserforincreaingnumber = 0;

    public string currentenemy =  "";


    public bool  inbattle = true;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        inbattle = turns.inbattle;

        if (turns.inbattle == false)
        {
            randomiserforincreaingnumber = Random.Range(1, 3);

            if(randomiserforincreaingnumber == 1)
            {
                increasingnumber++;
            }
            else
            {
                increasingnumber = increasingnumber += 0;
            }

            if(numbertillencounter == increasingnumber)
            {

                

               if(currentarea == "Area1")
                {
                    forrestbattlebackground.SetActive(true);
                    var area1randomiser = Random.Range(1, 4);

                    if(area1randomiser == 1)
                    {
                        currentenemy = "Goblin";
                        Enemies.summoningnewenemy = true;
                    }
                    if (area1randomiser == 2)
                    {
                        currentenemy = "Goblin";
                        Enemies.summoningnewenemy = true;
                    }
                    if(area1randomiser == 3)
                    {
                        currentenemy = "Goblin";
                        Enemies.summoningnewenemy = true;
                    }
                }
               if (currentarea == "Area2")
               {
                    desertbattlebackground.SetActive(true);
                    var area1randomiser = Random.Range(1, 4);

                    if (area1randomiser == 1)
                    {
                        currentenemy = "Cactus";
                        Enemies.summoningnewenemy = true;
                    }
                    else if (area1randomiser == 2)
                    {
                        currentenemy = "minihydra";
                        Enemies.summoningnewenemy = true;
                    }
                    else
                    {
                        currentenemy = "ArmouredScorpion";
                        Enemies.summoningnewenemy = true;
                    }
               }
               if (currentarea == "Area3")
               {
                    lavabattlebackground.SetActive(true);
                    var area1randomiser = Random.Range(1, 4);

                    if (area1randomiser == 1)
                    {
                        currentenemy = "GiantHydra";
                        Enemies.summoningnewenemy = true;
                    }
                    else if (area1randomiser == 2)
                    {
                        currentenemy = "lavamonster";
                        Enemies.summoningnewenemy = true;
                    }
                    else
                    {
                        currentenemy = "lavabeatle";
                        Enemies.summoningnewenemy = true;
                    }
               }
            }
        }
    }
}
