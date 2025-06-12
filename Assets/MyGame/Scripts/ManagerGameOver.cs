using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ManagerGameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text highscore;

    private void Start()
    {
        highscore.text = PlayerPrefs.GetInt("score").ToString();
    }


    public void LoadTutorialScene()
    {
        SceneManager.LoadScene("2DTones");
    }
    
}
