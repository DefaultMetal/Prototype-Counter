using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Fruit Catch
    public List<GameObject> fruits;
    
    private float spawnRate = 1.0f;
    public bool isGameActive;
    private bool paused;
    
    public GameObject titleScreen;
    public Text gaOvText;
    private SaveManager saveManager;

    public Button restartButton;
    public Button button;
    public Button pauseBut;
    public Button playBut;
    public Button exitButton;

    void Start()
    {
        button = GameObject.Find("StartButton").GetComponent<Button>();
        button.onClick.AddListener(StartGame);

        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        exitButton.onClick.AddListener(saveManager.Exit);
    }

    void Update()
    {
        
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gaOvText.gameObject.SetActive(true);
        pauseBut.gameObject.SetActive(false);
        isGameActive = false;

        restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
        restartButton.onClick.AddListener(RestartGame);
        
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;

        Time.timeScale = 1;
        
        titleScreen.gameObject.SetActive(false);
        pauseBut.gameObject.SetActive(true);
        
        pauseBut = GameObject.Find("PauseButton").GetComponent<Button>();
        pauseBut.onClick.AddListener(PauseGame);

        StartCoroutine(SpawnFruit());
    }

    public void PauseGame()
    {
        
        pauseBut.gameObject.SetActive(false);
        playBut.gameObject.SetActive(true);
       
        playBut = GameObject.Find("PlayButton").GetComponent<Button>();
        playBut.onClick.AddListener(UnpauseGame);
       
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        
        pauseBut.gameObject.SetActive(true);
        playBut.gameObject.SetActive(false);
       
        pauseBut = GameObject.Find("PauseButton").GetComponent<Button>();
        pauseBut.onClick.AddListener(PauseGame);
        
        Time.timeScale = 1;
    }

    IEnumerator SpawnFruit()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, fruits.Count);
            Instantiate(fruits[index]);
        }
    }
}
