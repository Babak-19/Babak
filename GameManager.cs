using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool xRayPowerUp;
    GameObject centerEye;
    ReplacementShaderEffect xRay;
    public static SmallPlayerController smallPlayer;
    HackPoints hackPoints;
    public static GameObject VictorySmallPlayerUI;
    GameObject DeathSmallPlayerUI;
    public bool smallPlayerIsDead;
    //public bool p1GameIsPaused;
    //public bool p2GameIsPaused;
    public static bool gameIsPaused;
    public Image pauseText;
    public Image pauseVRText;
    public float timeLeft;
    public Text timerText;
    public Text numberOfLives;
    
    public GameObject Portal;
    // Use this for initialization
    void Start ()
    {
        smallPlayer = FindObjectOfType<SmallPlayerController>();
        xRayPowerUp = false;
        centerEye = GameObject.Find("CenterEyeAnchor");
        xRay = centerEye.GetComponent<ReplacementShaderEffect>();
        hackPoints = FindObjectOfType<HackPoints>();
        VictorySmallPlayer(false); //turning off the victory sign (and possibly sounds and other stuff)
        DeathSmallPlayer(false);
        gameIsPaused = false;
        pauseText.gameObject.SetActive(false);
        pauseVRText.gameObject.SetActive(false);
        Portal.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {
        numberOfLives.text = "Lives: " + SmallPlayerController.Lives;
        timeLeft -= Time.deltaTime;
        timerText.text = "Time Left: " + timeLeft.ToString("0");
        VRControllsAndInputs();
        if (hackPoints.hackedPercentage == 100)
        {
            Portal.SetActive(true);
            //VictorySmallPlayer(true);
        }
        if(smallPlayerIsDead)
        {
            DeathSmallPlayer(smallPlayerIsDead);
        }

        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Menu");
            Time.timeScale = 1;

        }

        Pausing();

        OVRInput.Update();
        if(timeLeft<=0)
        {
            smallPlayer.enabled = false;
        }
        else
        {
            smallPlayer.enabled = true;
        }

        
    }
    
    public void Pausing()
    {
        if (OVRInput.Get(OVRInput.Button.Start) || Input.GetKeyUp(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {

                gameIsPaused = true;
                Time.timeScale = 0;
                pauseText.gameObject.SetActive(true);
                pauseVRText.gameObject.SetActive(true);

                print("game is PAUSED");
            }
            else
            {
                gameIsPaused = false;
                Time.timeScale = 1;
                pauseText.gameObject.SetActive(false);
                pauseVRText.gameObject.SetActive(false);
                print("game is UNPAUSED");
            }            
        }
    }
   
    void X_Ray(bool active)
    {
        xRay.enabled = active;
    }

    void VRControllsAndInputs()
    {
        OVRInput.Update();

        if (OVRInput.Get(OVRInput.Button.One))
        {
            X_Ray(true);
        }
        else
        {
            X_Ray(false);
        }
        //X_Ray(xRayPowerUp);	
    }

   public static void VictorySmallPlayer(bool victory)
    {
        //just setting things up
        if (victory == false)
        {
            VictorySmallPlayerUI = GameObject.Find("SmallPlayerCanvas/VictorySign");
        }

        //Small player has won
        VictorySmallPlayerUI.SetActive(victory);
        if (victory == true)
        {
            smallPlayer.enabled = false;
        }        
    }

    void DeathSmallPlayer(bool death)
    {
        
        //just setting things up
        if (death == false)
        {
            DeathSmallPlayerUI = GameObject.Find("SmallPlayerCanvas/DeathSign");
        }

        //Small player has died


        DeathSmallPlayerUI.SetActive(death);
        if (death == true)
        {
            
            smallPlayer.enabled = false;
        }
    }
    
}

        