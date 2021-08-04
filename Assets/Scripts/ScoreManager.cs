using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;

    public int score = 0;
    public int highscore = 0;

    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        string filePath = Application.persistentDataPath + "/PlayerScore.file";
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryReader br = new BinaryReader(fs);

        highscore = (br.ReadInt32());
        fs.Close();
        br.Close();
       // highScoreText.text = highscore.ToString();
        //highscore = PlayerPrefs.GetInt("highscore");
    }
    public void IncrementScore()
    {
        score++;
        ScoreText.text = score.ToString();
        if (score > highscore)
        {
            highscore = score;
            //PlayerPrefs.SetInt("highscore",score);
            string filePath = UnityEngine.Application.persistentDataPath + "/PlayerScore.file";
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(highscore); // Saving Highscore
            fs.Close();
            bw.Close();
        }
    }
}
