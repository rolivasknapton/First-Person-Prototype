using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class StartButtonScript : MonoBehaviour, IPointerClickHandler
{
    private GameObject player;
    private GameObject intro;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        intro = GameObject.FindWithTag("IntroMessageBackground");
        
        Time.timeScale = 0f;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        player.GetComponent<FirstPersonController>().enabled = true;
        Debug.Log("Object Clicked!");
        Time.timeScale = 1f;
        Destroy(intro);

    }
}
