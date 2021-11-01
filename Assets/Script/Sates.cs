using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sates : MonoBehaviour
{
    [SerializeField] Text levelText1;
    [SerializeField] Text levelAgain;
    [SerializeField] GameObject palyerObject;
    [SerializeField] GameObject roadObject;
    [SerializeField] GameObject PlayButton;



 public void Level_One()
 {
      levelText1.gameObject.SetActive(false);
       palyerObject.SetActive(true);
       roadObject.SetActive(true);
       PlayButton.SetActive(false);
 }
  public  void Level_Two()
  {
        levelText1.gameObject.SetActive(false);
        palyerObject.SetActive(true);
        roadObject.SetActive(true);
        PlayButton.SetActive(false);
    }
  public  void Level_Three()
  {
        levelText1.gameObject.SetActive(false);
        levelAgain.gameObject.SetActive(false);
        palyerObject.SetActive(false);
        roadObject.SetActive(false);
        PlayButton.SetActive(false);
        SceneManager.LoadScene(0);
  }
    public void Secs()
    {
        Invoke(nameof(Level_Three), 3f);
    }
}
