using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;

    public int score = 0;
    public int highscore1 = 0;

    public static ScoreManager instance;

    int levelScore = 3;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        GetData();
        //highscore = PlayerPrefs.GetInt("highscore");
    }
    public void IncrementScore()
    {
        score++;
        ScoreText.text = score.ToString();
        if (score > highscore1)
        {
            highscore1 = score;
            SaveData();
        }
        if (score >= levelScore)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void SaveData()
    {
        //PlayerPrefs.SetInt("highscore",score);
        string filePath = UnityEngine.Application.persistentDataPath + "/PlayerScore.file";
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Write(highscore1); // Saving Highscore
        fs.Close();
        bw.Close();
    }
    public void GetData()
    {
        string filePath = Application.persistentDataPath + "/PlayerScore.file";
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryReader br = new BinaryReader(fs);

        highscore1 = (br.ReadInt32());
        fs.Close();
        br.Close();
    }
}
