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


    int numbertillencounter = 10000000;
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
                    var area1randomiser = Random.Range(1, 11);

                    if(area1randomiser >= 1 && area1randomiser <= 4)
                    {
                        currentenemy = "Goblin";
                        Enemies.summoningnewenemy = true;
                    }
                    else if (area1randomiser == 5 || area1randomiser == 6)
                    {
                        currentenemy = "Rocky";
                        Enemies.summoningnewenemy = true;
                    }
                    else
                    {
                        currentenemy = "Slime";
                        Enemies.summoningnewenemy = true;
                    }
                }
               if (currentarea == "Area2")
               {
                    desertbattlebackground.SetActive(true);
                    var area2randomiser = Random.Range(1, 101);

                    if (area2randomiser >= 1 && area2randomiser <= 30)
                    {
                        currentenemy = "Cactus";
                        Enemies.summoningnewenemy = true;
                    }
                    else if (area2randomiser >=31 && area2randomiser <= 80)
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
                    var area3randomiser = Random.Range(1, 101);

                    if (area3randomiser >= 1 && area3randomiser <= 50)
                    {
                        currentenemy = "GiantHydra";
                        Enemies.summoningnewenemy = true;
                    }
                    else if (area3randomiser >= 51 && area3randomiser < 70)
                    {
                        currentenemy = "lavamonster";
                        Enemies.summoningnewenemy = true;
                    }
                    else
                    {
                        currentenemy = "lavasnail";
                        Enemies.summoningnewenemy = true;
                    }
               }
            }
        }
    }
}
