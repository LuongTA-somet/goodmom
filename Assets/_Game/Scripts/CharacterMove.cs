using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject goodDress;
    [SerializeField] private GameObject badDress;
    [SerializeField] private GameObject curDress;
    [SerializeField] private GameObject Win;
    [SerializeField] private GameObject Lose;
  

    public CameraFollow CameraFollow;
    public Score score;
    public bool isGood = false;
    public bool isBad = false;
    public bool isImpact = false;
    public int gate = 1;

    private Vector3 startMousePos;
    private Vector3 endMousePos;
    private bool fingerDown = false;
    private bool isWin = false;


    [Range(0, 10)]
    public float finalScore = 5;
 

    void Update()
    {
        if (CameraFollow.demoCamera) return;
        if (isWin) return;
        finalScore = Mathf.Clamp(finalScore, 0, 10);
        score.SetScore(finalScore);
        score.ActiveScore();
       
          gameObject.transform.position += new Vector3(0, 0, 0.1f);
        if (fingerDown == false && Input.GetMouseButtonDown(0))
        {
            startMousePos = Input.mousePosition;
            fingerDown = true;
        }
        if (fingerDown)
        {

            if (Input.mousePosition.x > startMousePos.x)
            {
                transform.position += new Vector3(0.1f, 0, 0);
                if (transform.position.x >= 2.2f)
                {
                    transform.position = new Vector3(2.2f, 0, transform.position.z);
                }
            }
            if (Input.mousePosition.x < startMousePos.x)
            {
                gameObject.transform.position += new Vector3(-0.1f, 0, 0);
                if (transform.position.x <= -1.4f)
                {
                    transform.position = new Vector3(-1.4f, 0, transform.position.z);
                }
            }
        }
        if (fingerDown && Input.GetMouseButtonUp(0))
        {
            fingerDown = false;
        }
        //if(Input.touchCount>0&& Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    startMousePos=Input.GetTouch(0).position;
        //}
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        //{
        //    endMousePos = Input.GetTouch(0).position;
        //    if (startMousePos.x > endMousePos.x)
        //    {

        //        gameObject.transform.position += new Vector3(0.1f, 0, 0);
        //    }
        //    if (startMousePos.x < endMousePos.x)
        //    {

        //        gameObject.transform.position += new Vector3(-0.1f, 0, 0);
        //    }
        //}
    }
    
    private void LoseGame()
    {
      Lose.gameObject.SetActive(true);
    }

    private void WinGame()
    {
        Win.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Evolution"))
        {
            GameManager.instance.soundManager.PlaySoundFX(TypeSound.GoodImpact);
            isGood = true;
           
        }
        if (other.CompareTag("Hurdle"))
        {
            GameManager.instance.soundManager.PlaySoundFX(TypeSound.BadImpact);
            isBad = true;
        }
        if (other.CompareTag("Good"))
        {
            GameManager.instance.soundManager.PlaySoundFX(TypeSound.GoodImpact);
            goodDress.SetActive(true);
            curDress.SetActive(false);
            finalScore += 3;

           other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Bad"))
        {
            GameManager.instance.soundManager.PlaySoundFX(TypeSound.BadImpact);
            badDress.SetActive(true);
            curDress.SetActive(false);
            finalScore -= 4;

           other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Finish"))
        {
            score.DeActiveScore();
            isWin = true;
            GameManager.instance.soundManager.bg.Stop();
            if (finalScore > 7)
            {
                WinGame();

            }
            else
            {
                LoseGame();
            }
        }
    }
  
}
