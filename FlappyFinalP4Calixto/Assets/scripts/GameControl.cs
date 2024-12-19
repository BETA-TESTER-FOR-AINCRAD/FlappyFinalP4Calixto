using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public GameObject GameOverText;
    public Text scoreText;
    public bool GameOver = false;
    public static GameControl Instance;
    public float scrollspeed = -1.5f;
    private int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
        }
    }
    public void BridScored()
    {
        if (GameOver)
        {
            return;
        }
        score++;
        scoreText.text = "score: " + score.ToString();
    }
    public void BirdDied()
    {
        GameOverText.SetActive(true);
        GameOver = true;
    }
}
