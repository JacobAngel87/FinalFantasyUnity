using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OptionController : MonoBehaviour, IPointerDownHandler
{
   public void OnPointerDown(PointerEventData eventData)
    {
        string option = gameObject.name;
        switch (option)
        {
            case "Fight":
                Fight();
                break;
            case "Item":
                Item();
                break;
            case "Magic":
                Magic();
                break;
            case "Flee":
                Flee();
                break;
        }
    }

    public void Fight()
    {
        // For the purposes of this projcet I do not want to mess with player and enemy stats due to the time constraints
        // I just want to sample what an encounter would look like
        FindObjectOfType<AudioManager>().Play("hit");
        GameObject enemy = GameObject.Find("CurrentMonster");
        enemy.transform.localScale = new Vector3(0f, 0f, 0f);
        StartCoroutine(EndEncounter());
    }
    private void Item()
    {
        print("Item Clicked");
    }
    private void Magic()
    {
        print("Magic Clicked");
    }
    private void Flee()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator EndEncounter()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}