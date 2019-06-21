using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyedVariables : MonoBehaviour
{

    public int sceneIndex;
    public int collectedMoney;
    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(this.transform.gameObject);
        sceneIndex = 0;
        collectedMoney = 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
