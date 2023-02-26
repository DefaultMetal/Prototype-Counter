using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    public TMP_InputField inputField;

    public int Count = 0;
    public string username;

    private SaveManager saveManager;

    

    private void Start()
    {
        Count = 0;
        inputField = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        CounterText.text = "High Score: " + saveManager.bigname + ", " + saveManager.highscore;

    }

    public void InputName()
    {
        username = inputField.text;
        Debug.Log(username);
        CounterText.text = "High Score: " + saveManager.bigname + ", " + saveManager.highscore + "\n" + username + "'s Score : " + Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            Count += 1;
            CounterText.text = "High Score: " + saveManager.bigname + ", " + saveManager.highscore + "\n" + username + "'s Score : " + Count;
        }
        
    }

    
}
