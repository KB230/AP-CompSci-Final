using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public bool win = false;
    public bool loss = false;
    public Health playerHP;
    public Barrier[] barriers;
    public Spawner spawner;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    //public Animator transition;
    //public float transitionTime; 

    private void Update()
    {
        LoadUI(); 

        if(SceneManager.GetActiveScene().name != "Launch Screen")
        {
            loosing(); ;
        }else if (SceneManager.GetActiveScene().name == "Launch Screen")
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                LaunchGame(); 
            }
        }
    }
    public void LaunchGame()
    {
        //StartCoroutine(SceneTransition());
        SceneManager.LoadScene(1);
    }
    public void ReturnToMenu()
    {
        //StartCoroutine(SceneTransition());
        SceneManager.LoadScene(0); 
    }
    public void HardModeLoad()
    {
        SceneManager.LoadScene(2); 
    }

    void loosing ()
    {
        if (playerHP.health <= 0)
        {
            loss = true;
        }
    }

    /*IEnumerator SceneTransition()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
    }*/

    public void LoadUI()
    {  
        if(win)
        {
            DestroyGameScene(); 
            //Load the Winning UI
            WinScreen.SetActive(true); 
            print("YOU WIN"); 
        }else if (loss)
        {
            //Load loss UI
            DestroyGameScene();  
            LoseScreen.SetActive(true); 
            print("YOU LOSE");
        }
    }

    
    private void DestroyGameScene()
    { 
        foreach (Barrier barrier in barriers)
        {
            barrier.gameObject.SetActive(false);
        }
        spawner.gameObject.SetActive(false);
    }
}
