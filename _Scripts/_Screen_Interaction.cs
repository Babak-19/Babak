using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class _Screen_Interaction : MonoBehaviour {
    //look at _Center_Top to see how gaze interaction works
    public Image _BackgroundImage;
    public Color _NormalColor;
    public Color _HighlightColor;
    public GameObject Zone1; //for gameobject use SetActive 

    public bool buttonIsPressed;
    public bool isLooking;

    //[Header("Zone")]
    //public Image zoneImage;
    //public  bool zoneIsCharged;
    //private bool zoneIsBeingUsed;
    //public float zoneRechargeWaitTime;
    //public float zonePUDuration;
    //public float zoneChargeAmount;

	// Use this for initialization
	void Start () {
        //    Zone1 = GetComponent<GameObject>(); //for component use enabled
        Zone1.SetActive(false); //zone disabled
        isLooking = false;
    }

    private void Update()
    {
        
       // ZoneAbility();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OVRInput.Update();
        if (OVRInput.Get(OVRInput.Button.Two) && isLooking == true)
        {
            Zone1.SetActive(true); //zone disabled
            Debug.Log("Zone enabled");
        }

    }

    public void OnGazeEnter()
    {
        isLooking = true;
         _BackgroundImage.color = _HighlightColor;
    }
  
    public void OnGazeExit()
    {
        isLooking = false;
        _BackgroundImage.color = _NormalColor;
    }

    public void OnClick()
    {
        //Zone1.SetActive(true); //zone disabled
        //Debug.Log("Zone disabled");
        //Debug.Log("Clicked"); //Put oculus touch button interactions here - this is where we make stuff happen within the game world
        
            Zone1.SetActive(true); //zone disabled
            Debug.Log("Zone enabled");
        
        //else
        //{
        //    Zone1.SetActive(true);
        //    Debug.Log("Zone Enabled");
        //}
    }

    //public void ZoneAbility()
    //{
    //    if (!zoneIsBeingUsed && !zoneIsCharged) //if the power up is not being used, recharge it
    //    {
    //        zoneChargeAmount += 1.0f / zoneRechargeWaitTime * Time.deltaTime; //charging it up. speedRechargeWaitTime is how many seconds it takes
    //        if (zoneChargeAmount >= 1)
    //        {
    //            zoneChargeAmount = 1;
    //            zoneIsCharged = true;
    //        }
    //    }

    //    if (zoneIsCharged) // if the power is charged, let the player press a button and activate it
    //    {
    //        if (OVRInput.Get(OVRInput.Button.Two))
    //        {
    //            zoneIsBeingUsed = true;
    //            Zone1.SetActive(true);
    //               Debug.Log("Zone enabled");
    //        }
    //    }

    //    if (zoneIsBeingUsed)
    //    {
    //   //     speedPUImage.fillAmount -= 1.0f / speedRechargeWaitTime * 3 * Time.deltaTime; //depleeting the icon, at a rate 3 times faster than powering up
    //        if (zoneChargeAmount <= 0) // as soon as it runs out...
    //        {
    //            zoneChargeAmount = 0; //make sure its actually zero
    //            zoneIsCharged = false;
    //            zoneIsBeingUsed = false;
    //        }
    //    }
    //}
}
