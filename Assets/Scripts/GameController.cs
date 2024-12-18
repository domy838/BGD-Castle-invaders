using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public int numberOfEnemies;
    public string showText = "";

    public GameObject gameOverPanel;
    public TMP_Text declaration;
    public GameObject restartButton;
    public GameObject nextLevelButton;
    public GameObject menuButton;

    public List<GameObject> hearts;

    // Start is called before the first frame update
    void Start()
    {   
        // Set all the menu invisible
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        nextLevelButton.SetActive(false);
        menuButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        // If all enemies are dead, you win
        if(numberOfEnemies <= 0)
        {   
            // Show menu for victory
            showText = "You Win!";
            declaration.text = showText;
            gameOverPanel.SetActive(true);
            nextLevelButton.SetActive(true);
            menuButton.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void GameOver()
    {
        // You lost, so show menu for lost game
        showText = "You Lost!";
        declaration.text = showText;
        gameOverPanel.SetActive(true);
        restartButton.SetActive(true);
        menuButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void EnemyDestroyed()
    {
        // One less enemy on screen
        numberOfEnemies -= 1;
        print(numberOfEnemies);
    }

    public void LooseLife(int lives)
    {
        hearts[lives].SetActive(false);
    }
}
