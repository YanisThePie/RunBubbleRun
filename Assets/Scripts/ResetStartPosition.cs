using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStartPosition : MonoBehaviour
{
    MainManager manager;

    private void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<MainManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            manager.ResetPlayerPos(other);
        }
    }


}
