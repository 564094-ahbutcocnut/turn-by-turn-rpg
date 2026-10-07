using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyTurns : MonoBehaviour
{

    [Header("Other Scripts")]
    [SerializeField] Turns turns;
    [SerializeField] RandonEncounters randomencounters;
    [SerializeField] enemies Enemy;

    [Header("battle variables")]
    [SerializeField] GameObject enenyusedmoveholder;
    [SerializeField] TextMeshProUGUI enemymoveused;

    [SerializeField] public SpriteRenderer slimebeforeexplosion;
    [SerializeField] public SpriteRenderer slimeafterexplosion;

    int Enemydamagemodifier = 1;


    bool hasslimegonecrazy = false;
    int ultamateSlimeAttack = 3;

    public bool hasenemyusedattack = false;

    private void Update()
    {
        if (turns.inbattle == false)
        {
            Enemydamagemodifier = 1;
        }


        if(turns.currentturn == "Enemy")
        {
            if(hasenemyusedattack == false)
            {
                if (randomencounters.currentenemy == "Goblin")
                {
                    int enemymoveselector = Random.Range(1, 11);

                    if (enemymoveselector >= 1 && enemymoveselector <= 4)
                    {
                        StartCoroutine(Lunge());
                        hasenemyusedattack = true;
                    }
                    else if (enemymoveselector >= 5 && enemymoveselector <= 8)
                    {
                        StartCoroutine(SpearStab());
                        hasenemyusedattack = true;
                    }
                    else
                    {
                        StartCoroutine(WingGust());
                        hasenemyusedattack = true;
                    }
                }
                if (randomencounters.currentenemy == "Rocky")
                {
                    int enemymoveselector = Random.Range(1, 11);

                    if (enemymoveselector >= 1 && enemymoveselector <= 4)
                    {
                        StartCoroutine(Lunge());
                        hasenemyusedattack = true;
                    }
                    else if (enemymoveselector >= 5 && enemymoveselector <= 8)
                    {
                        StartCoroutine(SpearStab());
                        hasenemyusedattack = true;
                    }
                    else
                    {
                        StartCoroutine(WingGust());
                        hasenemyusedattack = true;
                    }
                }
                if (randomencounters.currentenemy == "Slime")
                {
                    SpriteRenderer slimeafterexplosion = slimebeforeexplosion;

                    int enemymoveselector = Random.Range(1, 11);

                    if (enemymoveselector >= 1 && enemymoveselector <= 4)
                    {
                        StartCoroutine(Slimebonk());
                        hasenemyusedattack = true;
                    }
                    else if (enemymoveselector >= 5 && enemymoveselector <= 8)
                    {
                        StartCoroutine(Slimejab());
                        hasenemyusedattack = true;
                    }
                    else
                    {
                        StartCoroutine(Slimeexplosion());
                        hasenemyusedattack = true;
                    }
                }
            }
        }





    }


    IEnumerator Lunge()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Goblin used Lunge";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        if (rollEnemynumber >=1 && rollEnemynumber <= 3)
        {
            turns.enemycurrenthealth -= 3;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();

        }
        if(rollEnemynumber >=4 && rollEnemynumber <= 5)
        {
            int playertarget = Random.Range(1, 4);

            if(playertarget == 1)
            {

                turns.player1currenthealth -= 2;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            }
            else if(playertarget == 2)
            {
                turns.player2currenthealth -= 2;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            }
            else
            {
                turns.player3currenthealth -= 2;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
        {
            int playertarget = Random.Range(1, 4);

            if (playertarget == 1)
            {

                turns.player1currenthealth -= 3;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            }
            else if (playertarget == 2)
            {
                turns.player2currenthealth -= 3;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            }
            else
            {
                turns.player3currenthealth -= 3;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
        {
            int playertarget = Random.Range(1, 4);

            if (playertarget == 1)
            {

                turns.player1currenthealth -= 4;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            }
            else if (playertarget == 2)
            {
                turns.player2currenthealth -= 4;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            }
            else
            {
                turns.player3currenthealth -= 4;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
        {
            int playertarget = Random.Range(1, 4);

            if (playertarget == 1)
            {

                turns.player1currenthealth -= 5;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            }
            else if (playertarget == 2)
            {
                turns.player2currenthealth -= 5;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            }
            else
            {
                turns.player3currenthealth -= 5;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber == 20)
        {
            int playertarget = Random.Range(1, 4);

            if (playertarget == 1)
            {

                turns.player1currenthealth -= 7;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

                turns.player2currenthealth -= 7;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            }
            else if (playertarget == 2)
            {
                turns.player2currenthealth -= 7;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

                turns.player3currenthealth -= 7;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            }
            else
            {
                turns.player3currenthealth -= 7;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;

                turns.player1currenthealth -= 7;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            }
            turns.switchPlayer();
        }
        yield return new WaitForSeconds(.5F);
        enenyusedmoveholder.SetActive(false);

    }

    IEnumerator SpearStab()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Goblin used SpearStab";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        if (rollEnemynumber >= 1 && rollEnemynumber <= 5)
        {
            turns.enemycurrenthealth -= 4;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
        {
            int playertarget = Random.Range(1, 4);

            if (playertarget == 1)
            {

                turns.player1currenthealth -= 4;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            }
            else if (playertarget == 2)
            {
                turns.player2currenthealth -= 4;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            }
            else
            {
                turns.player3currenthealth -= 4;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
        {
            int playertarget = Random.Range(1, 4);

            if (playertarget == 1)
            {

                turns.player1currenthealth -= 4;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            }
            else if (playertarget == 2)
            {
                turns.player2currenthealth -= 4;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            }
            else
            {
                turns.player3currenthealth -= 4;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
        {
            int playertarget = Random.Range(1, 4);

            if (playertarget == 1)
            {

                turns.player1currenthealth -= 6;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            }
            else if (playertarget == 2)
            {
                turns.player2currenthealth -= 6;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            }
            else
            {
                turns.player3currenthealth -= 6;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber == 20)
        {
            int playertarget = Random.Range(1, 4);

            if (playertarget == 1)
            {

                turns.player1currenthealth -= 8;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

            }
            else if (playertarget == 2)
            {
                turns.player2currenthealth -= 8;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

            }
            else
            {
                turns.player3currenthealth -= 8;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;

            }
            turns.switchPlayer();
        }
        yield return new WaitForSeconds(.5F);
        enenyusedmoveholder.SetActive(false);


    }

    IEnumerator WingGust()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Goblin used Lunge";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        if (rollEnemynumber >= 1 && rollEnemynumber <= 2)
        {
            turns.enemycurrenthealth -= 7;
            turns.Enemyhealth.text = turns.enemycurrenthealth.ToString() + "/" + turns.enemymaxhealth;
            turns.switchPlayer();

        }
        if (rollEnemynumber >= 3 && rollEnemynumber <= 5)
        {           

            turns.player1currenthealth -= 1;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;            
            
            turns.player2currenthealth -= 1;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            
            turns.player3currenthealth -= 1;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
        {

            turns.player1currenthealth -= 2;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

            turns.player2currenthealth -= 2;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

            turns.player3currenthealth -= 2;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
        {
            turns.player1currenthealth -= 3;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

            turns.player2currenthealth -= 3;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

            turns.player3currenthealth -= 3;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
        {
            turns.player1currenthealth -= 3;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

            turns.player2currenthealth -= 4;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

            turns.player3currenthealth -= 3;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            turns.switchPlayer();
        }
        if (rollEnemynumber == 20)
        {
            turns.player1currenthealth -= 5;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

            turns.player2currenthealth -= 5;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

            turns.player3currenthealth -= 5;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            turns.switchPlayer();
        }
        yield return new WaitForSeconds(.5F);
        enenyusedmoveholder.SetActive(false);

    }

    IEnumerator Slimebonk()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Slime used Slime bonk";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);


        if (rollEnemynumber >= 1 && rollEnemynumber <= 5)
        {
            int playertarget = Random.Range(1, 4);

            if (playertarget == 1)
            {

                turns.player1currenthealth -= 0;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            }
            else if (playertarget == 2)
            {
                turns.player2currenthealth -= 0;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            }
            else
            {
                turns.player3currenthealth -= 0;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
        {
            int playertarget = Random.Range(1, 4);

            if (playertarget == 1)
            {

                turns.player1currenthealth -= 2 * ultamateSlimeAttack;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            }
            else if (playertarget == 2)
            {
                turns.player2currenthealth -= 2 * ultamateSlimeAttack;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            }
            else
            {
                turns.player3currenthealth -= 2 * ultamateSlimeAttack;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
        {
            int playertarget = Random.Range(1, 4);

            if (playertarget == 1)
            {

                turns.player1currenthealth -= 3 * ultamateSlimeAttack;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            }
            else if (playertarget == 2)
            {
                turns.player2currenthealth -= 3 * ultamateSlimeAttack;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            }
            else
            {
                turns.player3currenthealth -= 3 * ultamateSlimeAttack;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
        {
            int playertarget = Random.Range(1, 4);

            if (playertarget == 1)
            {

                turns.player1currenthealth -= 4 * ultamateSlimeAttack;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            }
            else if (playertarget == 2)
            {
                turns.player2currenthealth -= 4 * ultamateSlimeAttack;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            }
            else
            {
                turns.player3currenthealth -= 4 * ultamateSlimeAttack;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            }
            turns.switchPlayer();
        }
        if (rollEnemynumber == 20)
        {
            int playertarget = Random.Range(1, 4);

            if (playertarget == 1)
            {

                turns.player1currenthealth -= 5 * ultamateSlimeAttack;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

                turns.player2currenthealth -= 5 * ultamateSlimeAttack;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            }
            else if (playertarget == 2)
            {
                turns.player2currenthealth -= 5 * ultamateSlimeAttack;
                turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

                turns.player3currenthealth -= 15 * ultamateSlimeAttack;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
            }
            else
            {
                turns.player3currenthealth -= 15 * ultamateSlimeAttack;
                turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;

                turns.player1currenthealth -= 5 * ultamateSlimeAttack;
                turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            }
            turns.switchPlayer();
        }
        yield return new WaitForSeconds(.5F);
        enenyusedmoveholder.SetActive(false);

    }

    IEnumerator Slimejab()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Slime used Slime jab";

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        if(hasslimegonecrazy == true)
        {
            if (rollEnemynumber >= 1 && rollEnemynumber <= 5)
            {
                int playertarget = Random.Range(1, 4);

                if (playertarget == 1)
                {

                    turns.player1currenthealth -= 0;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                }
                else if (playertarget == 2)
                {
                    turns.player2currenthealth -= 0;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                }
                else
                {
                    turns.player3currenthealth -= 0;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
            {
                int playertarget = Random.Range(1, 4);

                if (playertarget == 1)
                {

                    turns.player1currenthealth -= 1 * ultamateSlimeAttack;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                }
                else if (playertarget == 2)
                {
                    turns.player2currenthealth -= 1 * ultamateSlimeAttack;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                }
                else
                {
                    turns.player3currenthealth -= 1 * ultamateSlimeAttack;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
            {
                int playertarget = Random.Range(1, 4);

                if (playertarget == 1)
                {

                    turns.player1currenthealth -= 2 * ultamateSlimeAttack;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                }
                else if (playertarget == 2)
                {
                    turns.player2currenthealth -= 2 * ultamateSlimeAttack;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                }
                else
                {
                    turns.player3currenthealth -= 2 * ultamateSlimeAttack;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
            {
                int playertarget = Random.Range(1, 4);

                if (playertarget == 1)
                {

                    turns.player1currenthealth -= 3 * ultamateSlimeAttack;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                }
                else if (playertarget == 2)
                {
                    turns.player2currenthealth -= 3 * ultamateSlimeAttack;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                }
                else
                {
                    turns.player3currenthealth -= 3 * ultamateSlimeAttack;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber == 20)
            {
                int playertarget = Random.Range(1, 4);

                if (playertarget == 1)
                {

                    turns.player1currenthealth -= 4 * ultamateSlimeAttack;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

                    turns.player2currenthealth -= 20 * ultamateSlimeAttack;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                }
                else if (playertarget == 2)
                {
                    turns.player2currenthealth -= 20 * ultamateSlimeAttack;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

                    turns.player3currenthealth -= 4 * ultamateSlimeAttack;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                }
                else
                {
                    turns.player3currenthealth -= 5 * ultamateSlimeAttack;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;

                    turns.player1currenthealth -= 5 * ultamateSlimeAttack;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                }
                turns.switchPlayer();
            }
        }
        else
        {
            if (rollEnemynumber >= 1 && rollEnemynumber <= 5)
            {
                int playertarget = Random.Range(1, 4);

                if (playertarget == 1)
                {

                    turns.player1currenthealth -= 0;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                }
                else if (playertarget == 2)
                {
                    turns.player2currenthealth -= 0;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                }
                else
                {
                    turns.player3currenthealth -= 0;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 6 && rollEnemynumber <= 10)
            {
                int playertarget = Random.Range(1, 4);

                if (playertarget == 1)
                {

                    turns.player1currenthealth -= 1;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                }
                else if (playertarget == 2)
                {
                    turns.player2currenthealth -= 1;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                }
                else
                {
                    turns.player3currenthealth -= 1;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 11 && rollEnemynumber <= 15)
            {
                int playertarget = Random.Range(1, 4);

                if (playertarget == 1)
                {

                    turns.player1currenthealth -= 2;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                }
                else if (playertarget == 2)
                {
                    turns.player2currenthealth -= 2;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                }
                else
                {
                    turns.player3currenthealth -= 2;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber >= 16 && rollEnemynumber <= 19)
            {
                int playertarget = Random.Range(1, 4);

                if (playertarget == 1)
                {

                    turns.player1currenthealth -= 3;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                }
                else if (playertarget == 2)
                {
                    turns.player2currenthealth -= 3;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                }
                else
                {
                    turns.player3currenthealth -= 3;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                }
                turns.switchPlayer();
            }
            if (rollEnemynumber == 20)
            {
                int playertarget = Random.Range(1, 4);

                if (playertarget == 1)
                {

                    turns.player1currenthealth -= 4;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;

                    turns.player2currenthealth -= 20;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
                }
                else if (playertarget == 2)
                {
                    turns.player2currenthealth -= 20;
                    turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

                    turns.player3currenthealth -= 4;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;
                }
                else
                {
                    turns.player3currenthealth -= 5;
                    turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;

                    turns.player1currenthealth -= 5;
                    turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
                }
                turns.switchPlayer();
            }
        }

            yield return new WaitForSeconds(.5F);
        enenyusedmoveholder.SetActive(false);

    }

    IEnumerator Slimeexplosion()
    {
        enenyusedmoveholder.SetActive(true);
        enemymoveused.text = "The Slime exploded";

        SpriteRenderer slimebeforeexplosion = slimeafterexplosion;

        int rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);
        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);

        rollEnemynumber = turns.enemyroll();
        yield return new WaitForSeconds(.2F);


        
        if (rollEnemynumber >= 1 && rollEnemynumber <= 19)
        {              

            turns.player1currenthealth -= 14;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;
            
            
            turns.player2currenthealth -= 29;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;
            
            turns.player3currenthealth -= 19;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;

            turns.enemycurrenthealth = 0;

            turns.switchPlayer();
        }
        if (rollEnemynumber == 20)
        {

            turns.player1currenthealth -= 2147483647;
            turns.Player1health.text = turns.player1currenthealth.ToString() + "/" + turns.player1maxhealth;


            turns.player2currenthealth -= 20;
            turns.Player2health.text = turns.player2currenthealth.ToString() + "/" + turns.player2maxthealth;

            turns.player3currenthealth -= 10;
            turns.Player3health.text = turns.player3currenthealth.ToString() + "/" + turns.player3maxhealth;


            turns.enemycurrenthealth = 1;


            yield return new WaitForSeconds(.5F);
            enemymoveused.text = ".";

            yield return new WaitForSeconds(.5F);
            enemymoveused.text = "..";

            yield return new WaitForSeconds(.5F);
            enemymoveused.text = "...";

            yield return new WaitForSeconds(.5F);
            enemymoveused.text = "....";

            yield return new WaitForSeconds(.5F);
            enemymoveused.text = ".....";

            yield return new WaitForSeconds(.5F);
            enemymoveused.text = "BUT IT REFUSED!!!";


            SpriteRenderer slimeafterexplosion = slimebeforeexplosion;

            turns.enemymaxhealth = 100;

            turns.enemycurrenthealth = turns.enemymaxhealth;

            rollEnemynumber = turns.enemyroll();

            if(rollEnemynumber == 1)
            {
                yield return new WaitForSeconds(.5F);
                enemymoveused.text = "but not for long";

                

                turns.enemymaxhealth = 1;
                turns.enemycurrenthealth = 0;
            }
            else
            {
                hasslimegonecrazy = true;
            }

                turns.switchPlayer();
        }
        yield return new WaitForSeconds(.5F);
        enenyusedmoveholder.SetActive(false);

    }
}
