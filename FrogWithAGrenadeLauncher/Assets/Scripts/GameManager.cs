using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm = null;

    public static int Score;
    public string ScorePrefix = string.Empty;
    public string HealthPrefix = string.Empty;
    public TMP_Text ScoreText = null;
    public TMP_Text GameOverText = null;
    public TMP_Text HealthText = null;
    public GameObject button;

    private int startScore;

    private float pHP = 0f;

    public static GameObject player;

    private void Awake()
    {
        if(gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
        }
        gm.GameOverText.gameObject.SetActive(false);
        gm.button.gameObject.SetActive(false);
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
        DontDestroyOnLoad(gameObject);
        if (gm.GameOverText != null)
        {
            gm.GameOverText.gameObject.SetActive(false);
        }
        startScore = Score;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject PlayerObj = GameObject.FindGameObjectWithTag("Player");
        if (PlayerObj != null)
        {
            pHP = PlayerObj.GetComponent<Health>().HealthPoints;
        }
        //Debug.Log("PHP " + pHP.ToString());

        if (ScoreText != null)
        {
            ScoreText.text = ScorePrefix + Score.ToString();
        }

        if(HealthText != null)
        {
            HealthText.text = HealthPrefix + pHP.ToString();
        }
        
        if(Time.timeSinceLevelLoad >45f && !SceneManager.GetActiveScene().name.Equals("SampleScene")){
            gm.GameOverText.gameObject.SetActive(false);
            gm.button.gameObject.SetActive(false);
            SceneManager.LoadScene("SampleScene");
            gm.GameOverText.gameObject.SetActive(false);
            gm.button.gameObject.SetActive(false);
        }

    } // end update

    public static void GameOver()
    {
        if(gm.GameOverText != null)
        {
            gm.GameOverText.gameObject.SetActive(true);
        }
        if (gm.button != null)
        {
            gm.button.gameObject.SetActive(true);
        }
    } // end gameOver
    public void OnButtonPress()
    {
        Scene scene = SceneManager.GetActiveScene();
        gm.GameOverText.gameObject.SetActive(false);
        gm.button.gameObject.SetActive(false);
        SceneManager.LoadScene(scene.name);
        Score = startScore-50;
    }
}
