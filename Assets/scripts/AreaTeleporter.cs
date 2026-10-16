using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTeleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;

    [SerializeField] RandonEncounters randomenconeter;
    [SerializeField] public string area;


    public Transform GetDestination()
    {
        randomenconeter.currentarea = area;
        return destination;
    }

}
