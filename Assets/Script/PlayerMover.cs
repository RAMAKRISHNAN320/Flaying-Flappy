using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMover : WinBoard
{

    [SerializeField] float speedx = 1f;
    [SerializeField] float speedz = 1f;
    [SerializeField] Text ScoreBoard;
    [SerializeField] float Seconds = 2f;
    int Score;
    [SerializeField] AudioClip pointsound;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float Valuex = Input.GetAxis("Horizontal");
        float Valuez = Input.GetAxis("Vertical");
        transform.Translate(Valuex * Time.deltaTime * speedx, 0, Valuez * Time.deltaTime * speedz);
        sec();
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
                GetComponent<PlayerMover>().enabled = true;
                break;
            case "Obstacle":
                GetComponent<PlayerMover>().enabled = false;
                Invoke("agains", Seconds);
                break;
        }
    }
    void agains()
    {
        SceneManager.LoadScene(0);
    }
    void NextReload()
    {
      SceneManager.LoadScene(1);
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
    
}