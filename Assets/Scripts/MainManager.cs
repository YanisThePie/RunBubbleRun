using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainManager : MonoBehaviour
{
    public GameObject Video;
    VideoPlayer videoPlayer;
    GameObject dontDestroy;
    Transform start;
    int sceneIndex;


    // Start is called before the first frame update
    void Start()
    {
        dontDestroy = GameObject.Find("DontDestroy");
        start = GameObject.Find("Start").transform;
        Video = GameObject.Find("UI").GetComponentsInChildren<Transform>(true)[1].gameObject;
         if (dontDestroy.GetComponent<DontDestroyedVariables>().sceneIndex == 0)
            DisplayStartScreen();
        //videoPlayer = Video.GetComponentInChildren<VideoPlayer>(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Video.activeInHierarchy)
        {
            if ((int)videoPlayer.frame == (int)videoPlayer.frameCount - 1)
            {
                Video.SetActive(false);
            }
        }
    }

    public IEnumerator SwitchLevel ()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(++dontDestroy.GetComponent<DontDestroyedVariables>().sceneIndex);
    }

    public void ResetPlayerPos(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject Player = Instantiate(Resources.Load("All/Prefabs/Sphere") as GameObject, start.transform.position, Quaternion.identity);
            Player.transform.position = start.position;
            Destroy(other.gameObject);
        }
    }

    public void DisplayWinScreen()
    {
        Video.SetActive(true);
        Video.GetComponent<Canvas>().enabled = false;
        videoPlayer = Video.GetComponentInChildren<VideoPlayer>(true);
        videoPlayer.clip = (UnityEngine.Video.VideoClip)Resources.Load("All/Videos/YouWin");
        Video.GetComponent<Canvas>().enabled = true;
    }
    public void DisplayNextLvlScreen()
    {
        Video.SetActive(true);
        Video.GetComponent<Canvas>().enabled = false;
        videoPlayer = Video.GetComponentInChildren<VideoPlayer>(true);
        videoPlayer.clip = (UnityEngine.Video.VideoClip)Resources.Load("All/Videos/GoToTheNextLevel");
        Video.GetComponent<Canvas>().enabled = true;
    }
    public void DisplayStartScreen()
    {
        Video.SetActive(true);
        Video.GetComponent<Canvas>().enabled = false;
        videoPlayer = Video.GetComponentInChildren<VideoPlayer>(true);
        videoPlayer.clip = (UnityEngine.Video.VideoClip)Resources.Load("All/Videos/Oppening");
        Video.GetComponent<Canvas>().enabled = true;
    }

    public void MoneyDetection (Collider other, GameObject money)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Money collected");
            dontDestroy.GetComponent<DontDestroyedVariables>().collectedMoney++;
            Destroy(money);
        }
    }
}
