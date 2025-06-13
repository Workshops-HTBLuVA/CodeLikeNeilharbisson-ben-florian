using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerIntro : MonoBehaviour
{
    public void LoadTutorialScene()
    {
        SceneManager.LoadScene("2DTonesTutorial");
    }
}
