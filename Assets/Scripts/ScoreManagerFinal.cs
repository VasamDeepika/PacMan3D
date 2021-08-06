using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ScoreManagerFinal : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = ScoreManager.instance.highscore.ToString();
        scoreText.text = ScoreManager.instance.score.ToString();
    }
}