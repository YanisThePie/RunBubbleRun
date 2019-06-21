using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSurface : MonoBehaviour
{
    public bool IsOnPlateform;

    private void OnTriggerStay(Collider other)
    {
        if (other.name != "Blackhole")
        {
            IsOnPlateform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name != "Blackhole")
        {
            IsOnPlateform = false;
        }
    }
}
