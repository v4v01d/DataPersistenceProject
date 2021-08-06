using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string Username;
    public int LastBestScore;
    public string LastBestScoreUser;

    public void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    public void UpdateScore(int score)
    {
        if (LastBestScore > score) return;

        LastBestScore = score;
        LastBestScoreUser = Username;

        SaveData data = new SaveData();
        data.Score = score;
        data.Username = Username;

        string json = JsonUtility.ToJson(data);

        string path = Application.persistentDataPath + "/best_score.json";

        File.WriteAllText(path, json);
    }

    private void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/best_score.json";
        if (!File.Exists(path)) return;

        string json_string = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json_string);

        LastBestScoreUser = data.Username;
        LastBestScore = data.Score;
    }

    public void SetUsername(string username)
    {
        Username = username;
    }
    [System.Serializable]
    private class SaveData
    {
        public string Username;
        public int Score;
    }


}
