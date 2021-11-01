using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RocketMove : WinBoard
{
    //new variablr use to the name declare name intialize variable set set to the assig name the name//
    //rigid the addd force to player move the add force gravity speed//
    Rigidbody Myrigidbody;
    // use to pubblic variiable  to easy to edit and inspector and easy  miind access//
    public float playerSpeedUp = 10;
    //the key name player speed forward and used inspector way//
    public float playerForward = 10;
    //this key used to side speed move and float values add the movements//
    public float playeSide = 10;
    // the text format use to the score mode//
    public Text ScoreBoard;
    // the float valuse to use the pplayer speed the restart the move//
    public float Seconds = 2f;
    //every move the collection the coin and use to the player score mode addd to the new//
    int Score;
    // audioclip use to player collection to the coin and soound play the sound//
    public AudioClip pointsound;
    // audiossource use to drag and drop to the functionallity there all types use easy to access
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Myrigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerUp();
        PlayerSideMove();
        sec();
       
    }

    void PlayerUp()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Myrigidbody.AddForce(Vector3.up * playerSpeedUp * Time.deltaTime);
            Myrigidbody.AddForce(Vector3.forward * playerForward * Time.deltaTime);
        }
        
    }
    void PlayerSideMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Myrigidbody.AddRelativeForce(Vector2.up * playerSpeedUp * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Myrigidbody.AddForce(Vector3.right * playeSide * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Myrigidbody.AddForce(Vector3.right * -playeSide * Time.deltaTime);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Green":
                other.gameObject.SetActive(false);
                Score = Score + 1;
                ScoreBoard.text = "Score:" + Score;
                Debug.Log("Blue Score is work");
                audioSource.PlayOneShot(pointsound);
                break;
            case "Blue":
                other.gameObject.SetActive(false);
                Score = Score + 2;
                ScoreBoard.text = "Score:" + Score;
                Debug.Log("Blue Score is work");
                audioSource.PlayOneShot(pointsound);
                break;
            case "Red":
                other.gameObject.SetActive(false);
                Score = Score + 3;
                ScoreBoard.text = "Score:" + Score;
                Debug.Log("Blue Score is work");
                audioSource.PlayOneShot(pointsound);
                break;
            case "Yellow":
                other.gameObject.SetActive(false);
                Score = Score + 4;
                ScoreBoard.text = "Score:" + Score;
                Debug.Log("Blue Score is work");
                audioSource.PlayOneShot(pointsound);
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Road":
                Debug.Log("Road is work");
                GetComponent<RocketMove>().enabled = true;
                break;
            case "Obstacle":
                GetComponent<RocketMove>().enabled = false;
                Invoke("agains", Seconds);
                break;
        }
    }
    void NextReload()
    {
        SceneManager.LoadScene(2);
    }
    void sec()
    {
        if (Score >= 20)
        {
            Welcome();
            Invoke(nameof(NextReload), 3f);
            GetComponent<PlayerMover>().enabled = false;

        }
    }

        void agains()
    {
        SceneManager.LoadScene(1);
    }

}
