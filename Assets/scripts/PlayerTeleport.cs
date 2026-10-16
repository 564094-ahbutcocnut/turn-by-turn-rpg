using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject currentTeleporter;

    [SerializeField] AreaTeleporter areateleport;
    [SerializeField] RandonEncounters randomencounter;

    [SerializeField] GameObject FieldToLavaBarrier;
    [SerializeField] GameObject LavaToFieldBarrier;

    bool hasvisitedlava;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<AreaTeleporter>().GetDestination().position;

                if(randomencounter.currentarea == ("Area3"))
                {

                    Debug.Log(areateleport.area);
                    FieldToLavaBarrier.SetActive(false);
                    LavaToFieldBarrier.SetActive(false);
                }
                
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Teleporter"))
        {
            currentTeleporter = null;
        }
    }
}
