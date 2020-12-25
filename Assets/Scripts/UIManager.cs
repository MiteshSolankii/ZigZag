using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject zigzagPanel;
    public GameObject gameoverPanel;
    public GameObject tapText;
    public GameObject gameEnd;
    
    public Text score;
    public Text highScore1;
    public Text highScore2;

    


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
      
    }
    // Start is called before the first frame update
    void Start()
    {
        highScore1.text = "High Score:" + PlayerPrefs.GetInt("highScore").ToString();

        AudioManager.instance.PlaySound("BGM");
    }

    public void GameStart()
    {
        tapText.GetComponent<Animator>().SetTrigger("Tapanim");
        tapText.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("PanelUp");
    }
    public void GameOver()
    {
       
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameoverPanel.SetActive(true);
        
    }

    public void Gamewin()
    {
        gameEnd.SetActive(true);
        AudioManager.instance.PlaySound("Win");
    }

    public void Reset()
    {
        AudioManager.instance.PlaySound("Button");
        Invoke("ResetScene", 0.35f);
    }
    void ResetScene()
    {
        SceneManager.LoadScene(0);
        
    }

    public void QuitGame()
    {
        AudioManager.instance.PlaySound("Button");
        Invoke("QuitScene", 0.35f);
    }
    void QuitScene()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
