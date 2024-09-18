using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Image ScoreImage;

    public void SetScore(float score)
    {
        ScoreImage.fillAmount = score / 10;
    }
    public void ActiveScore()
    {
        gameObject.SetActive(true);
    } public void DeActiveScore()
    {
        gameObject.SetActive(false);
    }
}
