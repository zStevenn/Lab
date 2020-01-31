using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Variabelen
    public List<GameObject> foods;
    public GameObject titleScreen;
    private int score;
    public bool isGameActive;
    public Button restartButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    public TextMeshProUGUI gameoverscoreText;
    private float spawnRate = 1.0f;
    private float SpawnRangeX = 12.0f;
    private float SpawnPosZ = 8.0f;


    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnFoods()
    {
        // Spawns target after a few seconds 
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, foods.Count);
            Vector3 spawnPos = new Vector3(Random.Range(-SpawnRangeX, SpawnRangeX), 0, SpawnPosZ);
            Instantiate(foods[index], spawnPos, foods[index].transform.rotation);
        }
    }

    // functie gemaakt dat word aangeroepen als game word gestart
    public void StartGame(int difficulty)
    {
        // Start game
        score = 0;
        isGameActive = true;
        UpdateScore(0);
        spawnRate /= difficulty;

        StartCoroutine(SpawnFoods());
        titleScreen.gameObject.SetActive(false);
        
    }

    // Functie om score bij te voegen in de tekst
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Functie als speler verloren heeft
    public void GameOver()
    {
        gameoverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        gameoverscoreText.gameObject.SetActive(true);
        gameoverscoreText.text = "Uw eindscore: " + score;
    }
    
    // 
    public void  RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    
}
