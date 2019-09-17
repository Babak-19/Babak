using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Kill_Zone : MonoBehaviour {
    GameObject smallPlayer;
    SmallPlayerController smallPlayerController;

    bool playerIsInsideArea;
// script name + name we're going to use for the script
	// Use this for initialization
	void Start () {

        playerIsInsideArea = false;

        smallPlayer = GameObject.Find("SmallPlayer");
        smallPlayerController = FindObjectOfType<SmallPlayerController>();


    }
	
	// Update is called once per frame
	void Update () {
		
        if(playerIsInsideArea == true)
        {
            StartCoroutine(Kill(1f));
        }
	}

    private void OnTriggerEnter(Collider col)
    {
       if (col.gameObject == smallPlayer)
        {
            print("Player has been destroyed");
            playerIsInsideArea = true;
            
        }

      
 }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject == smallPlayer)
        {
            print("Player has been destroyed");
            playerIsInsideArea = false;

        }
    }
   private IEnumerator Kill(float delay)
    {
        yield return new WaitForSeconds(delay);
        print("player was damage from the area");
        //deal damage
        SmallPlayerController.life -= 10;
    }
}