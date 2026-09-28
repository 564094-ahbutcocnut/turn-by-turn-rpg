using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class RandonEncounters : MonoBehaviour
{

    [SerializeField] Turns turns;
    [SerializeField] enemies Enemies;


    public string currentarea = "";


    int numbertillencounter = 2000;
    public int increasingnumber = 0;

    public string currentenemy =  "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(turns.inbattle == false)
        {
            var randomiserforincreaingnumber = Random.Range(1, 3);

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

                Debug.Log("rjfbnfrvjab");
                

               if(currentarea == "Area1")
                {
                    var area1randomiser = Random.Range(1, 4);

                    if(area1randomiser == 1)
                    {
                        currentenemy = "Goblin";
                        Enemies.summoningnewenemy = true;
                    }
                    if (area1randomiser == 2)
                    {
                        currentenemy = "Rocky";
                        Enemies.summoningnewenemy = true;
                    }
                    if(area1randomiser == 3)
                    {
                        currentenemy = "Slime";
                        Enemies.summoningnewenemy = true;
                    }
                }
               if (currentarea == "Area2")
               {
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
