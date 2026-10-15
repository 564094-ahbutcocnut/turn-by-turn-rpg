using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject currentTeleporter;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<AreaTeleporter>().GetDestination().position;
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
