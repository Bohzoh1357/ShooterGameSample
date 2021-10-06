using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gm = null;

    public static int Score;
    public string ScorePrefix = string.Empty;
    public TMP_Text ScoreText = null;
    public TMP_Text GameOverText = null;

    public static GameObject player;

    private void Awake()
    {
        gm = this;

    }
   // public static GameManager GM { get { return gm; } }

    // need to look more about this cuz apparently it's a singleton?
    void CheckGameManagerIsInScene()
    {
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    } // end GameManagerIsInScene

    private void Start()
    {
        if (gm.GameOverText != null)
        {
            gm.GameOverText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreText != null)
        {
            ScoreText.text = ScorePrefix + Score.ToString();
        }
        
    } // end update

    public static void GameOver()
    {
        if(gm.GameOverText != null)
        {
            gm.GameOverText.gameObject.SetActive(true);
        }
    } // end gameOver

}
