using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWin : MonoBehaviour
{
    MainManager manager;

    private void Start()
    {
       manager = GameObject.Find("Manager").GetComponent<MainManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        manager.DisplayNextLvlScreen();
        StartCoroutine(manager.SwitchLevel());
    }
}