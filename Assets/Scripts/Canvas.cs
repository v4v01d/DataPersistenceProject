using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour
{
    public TMP_InputField Username;
    public TextMeshProUGUI BestScore;

    public void Start()
    {
        BestScore.text = "Best Score: " + MenuManager.Instance.LastBestScoreUser + ": " + MenuManager.Instance.LastBestScore;
    }

    public void StartClicked()
    {
        MenuManager.Instance.SetUsername(Username.text);
        SceneManager.LoadScene(1);
    }
}
