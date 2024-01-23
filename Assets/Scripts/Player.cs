using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int force = 200;
    public GameObject obstacle;
    public Text scoretext;
    public float speed;

    private Animation thisAnimation;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0,force,0));
        }

        float VerticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(VerticalInput * speed * Time.deltaTime, 0, 0);

        if (transform.position.y >= 4.15f)
        {
            transform.position = new Vector3(3.5f, transform.position.x, transform.position.z);
        }
        if (transform.position.y <= -3.84f)
        {

            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
