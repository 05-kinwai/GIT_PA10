using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    int score;
    public Text ScoreText;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            score++;
            ScoreText.text = " Score : " + score;
            Destroy(collision.gameObject);
        }
    }
}
