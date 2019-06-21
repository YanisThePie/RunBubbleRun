using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    GameObject dontDestroy;
    GameObject UiMoney;
    GameObject UiTime;
    GameObject UiLevel;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        dontDestroy = GameObject.Find("DontDestroy");
        UiMoney = GameObject.FindWithTag("UiMoney");
        UiTime = GameObject.FindWithTag("UiTime");
        UiLevel = GameObject.Find("Niveau");
        dontDestroy = GameObject.Find("DontDestroy");
    }

    // Update is called once per frame
    void Update()
    {
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");

        UiMoney.gameObject.GetComponent<Text>().text = dontDestroy.GetComponent<DontDestroyedVariables>().collectedMoney.ToString();
        timer += Time.deltaTime;
        UiTime.gameObject.GetComponent<Text>().text = minutes + ":" + seconds;
        UiLevel.gameObject.GetComponent<Text>().text = "Niveau " + (dontDestroy.GetComponent<DontDestroyedVariables>().sceneIndex + 1).ToString();
     }
}
