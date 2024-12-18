using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string text = "";

    public GameObject shownText;
    public GameObject restartButton;
    public GameObject nextLevelButton;
    public GameObject menuButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOver()
    {
        Time.timeScale = 0;
    }
}
