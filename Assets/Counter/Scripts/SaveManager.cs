using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private Counter counterScript;

    private int Count = 0;

    public string bigname;
    public int highscore;

    public Button exitButton;


    void Start()
    {
        Count = 0;
        counterScript = GameObject.Find("Catcher").GetComponent<Counter>();
        exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        exitButton.onClick.AddListener(Exit);
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighscore();
    }

    private void Update()
    {
        Count = counterScript.Count;
        if (Count >= highscore)
        {
            highscore = Count;
            bigname = counterScript.username;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int saveScore;
        public string saveName;
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.saveScore = highscore;
        data.saveName = bigname;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscore = data.saveScore;
            bigname = data.saveName;
        }
    }

    public void Exit()
    {
        SaveHighscore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }


}
