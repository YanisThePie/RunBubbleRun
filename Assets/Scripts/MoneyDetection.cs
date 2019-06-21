using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDetection : MonoBehaviour
{
    MainManager manager;

    private void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        manager.MoneyDetection(other, this.gameObject);
    }
}
