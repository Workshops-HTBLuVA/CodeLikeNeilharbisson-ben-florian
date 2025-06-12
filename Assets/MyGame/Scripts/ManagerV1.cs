using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerV1 : MonoBehaviour
{
    [SerializeField] Button[] colorButtons;
    [SerializeField] Image[] gameOverImages;
    [SerializeField] ColorSoundTask[] tasks; 
    [SerializeField] TMP_Text developerName;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] AudioSource audioSource;

    private int progress = 0;
    private ColorOption currentCorrectColor;
    private int errorCount = 0;
    private int maxErrors = 3;
    private int score = 0;

    private void Start()
    {
        tasks = Resources.LoadAll<ColorSoundTask>("Aufgaben");
        if (tasks.Length == 0)
        {
            Debug.LogError("Keine Aufgaben im Resources/Aufgaben-Ordner gefunden!");
            return;
        }

        PlayTask(tasks[progress]);
    }
    public void nexttask()
    {
        progress++;
        PlayTask(tasks[progress]);
    }
    public void PlayTask(ColorSoundTask task)
    {
        audioSource.clip = task.targetSound;
        audioSource.Play();
        for (int i = 0; i < colorButtons.Length; i++)
        {
            colorButtons[i].interactable = true;
        }

        for (int i = 0; i < colorButtons.Length; i++) 
        {
            colorButtons[i].GetComponent<ColorButton>().SetButtonColor(task.options[i]);
        }

        currentCorrectColor = task.correctColor;
    }

    public void OnColorButtonPressed(ColorOption selectedColor)
    {
        if (selectedColor == currentCorrectColor)
        {
            Debug.Log("✅ Richtig!");
            score++;
            scoreText.text = score.ToString();

            for (int i = 0; i<colorButtons.Length; i++)
            {
                colorButtons[i].interactable = false;
            }
        }
        else
        {
            gameOverImages[errorCount].color = Color.red;
            errorCount++;

            if (errorCount >= maxErrors)
            {
                Debug.Log("Game Over!");
                //LoadGameOverScene();
            }
            //Debug.Log("❌ Falsch!");
            // Game Over oder Fehleranzeige
        }
    }
}
