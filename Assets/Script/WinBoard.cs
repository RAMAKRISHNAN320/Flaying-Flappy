using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinBoard : MonoBehaviour
{
    [SerializeField] Image Welcome_Text;

   public void Welcome()
    {
        Welcome_Text.gameObject.SetActive(true);
    }
}
