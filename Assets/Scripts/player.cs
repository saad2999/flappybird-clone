using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;



public class player : MonoBehaviour
{
    private Rigidbody rb;


    int HealthCount;
    public AudioClip jumpclip;
     public AudioClip scoreAudio;
     public AudioClip Dieclip;
    int heathindex ;
   private AudioSource AS;
    public TextMeshProUGUI scorestext;
    public TextMeshProUGUI highscore;
    public TextMeshProUGUI highscoreMade;
    public bool isgameover=false;
    public Button Restart;
    public TextMeshProUGUI go;
    public bool scoresIncrease=false;
    int HighScore = 0;
    public GameObject[] lifes;
    Vector3 position;
    public int scores=0;



    //public Button Restart;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();

        AS = GetComponent<AudioSource>();
        heathindex = 0;
        HealthCount = 3;
        for (int i = 0; i < HealthCount; i++)
        {
            lifes[i].SetActive(true);

        }
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        scorestext.text = "score:\n " + scores;
        
        if (!File.Exists("HighScore.txt"))
        {
            File.WriteAllText("HighScore.txt",Convert.ToString(HighScore));
        }
        else
        {
           HighScore=Convert.ToInt32 (File.ReadAllText("HighScore.txt"));
            

        }
        highscore.text= "High score: " + HighScore;





    }

    // Update is called once per frame
    void Update()
    {
        // optimize
        if (scoresIncrease)
        {
            AS.PlayOneShot(scoreAudio);
            scorestext.text = "score:\n " + scores;
            scoresIncrease = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            
            scorestext.text = "score:\n " + scores;
            rb.AddForce(Vector3.up * 8, ForceMode.Impulse);
            
           
           
            AS.PlayOneShot(jumpclip);
        }
        // sometimes player fell blow the ground because muliples collions handling the coner case
        if (transform.position.y < -10)
        {
            GameOver();
        }
        
        

        
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.name=="top")
        {
            HealthCount--;
            AS.PlayOneShot(Dieclip);
            if (HealthCount == 0)
            {
                GameOver();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if((collision.gameObject.CompareTag("obsticle")||(collision.gameObject.CompareTag("Ground"))))
        {
            this.transform.position = position;
            lifes[heathindex].SetActive(false);
            heathindex++;
            HealthCount--;
            AS.PlayOneShot(Dieclip);

            if (HealthCount==0)
            {
                GameOver();
            }
            

            
            
        }
        
    }
    public void Restatfun()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void GameOver()
    {
        rb.isKinematic = true;

        AS.PlayOneShot(Dieclip);
        isgameover = true;
        if (scores > HighScore)
        {
            File.WriteAllText("HighScore.txt", Convert.ToString(scores));
            highscoreMade.text = "you made a High Scores: " + scores;
            highscoreMade.gameObject.SetActive(true);
        }
        scores = 0;
        Restart.gameObject.SetActive(true);
        go.gameObject.SetActive(true);
    }
}
