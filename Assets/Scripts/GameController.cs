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

    public bool isGameOver = false;

    public int lives = 3;

    // Start is called before the first frame update
    void Start()
    {   
        Time.timeScale = 1;
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
            isGameOver = true;
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
        isGameOver = true;
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

    public void LooseLife()
    {   
        // We loose a life
        lives -= 1;
        // If we are out of lives its game over
        if(lives <= 0)
        {
            GameOver();
        }
        // Make teh hearts dissapear
        hearts[lives].SetActive(false);
    }
}
