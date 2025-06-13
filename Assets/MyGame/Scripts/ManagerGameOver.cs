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
        SceneManager.LoadScene("2DTonesTutorial");
    }

    public void ClearHighscore()
    {
        PlayerPrefs.SetInt("score", 0);
        highscore.text = "0";
    }
    
}
