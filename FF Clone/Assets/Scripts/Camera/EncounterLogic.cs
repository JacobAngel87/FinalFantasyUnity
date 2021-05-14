using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine;
using TMPro;

public class EncounterLogic : MonoBehaviour
{
    private GameObject currentMonster;
    private GameObject monsters;
    private Sprite monsterSprite;
    public TextMeshProUGUI monsterName;
    private int area;

    // Start is called before the first frame update
    void Start()
    {
        currentMonster = GameObject.Find("CurrentMonster");
        monsters = GameObject.Find("Monsters");
        area = 0; // Just for testing
        switch(area)
        {
            case 0:
                print("Overworld Encounter");
                int rand = Random.Range(0, monsters.transform.GetChild(0).childCount);
                monsterSprite = monsters.transform.GetChild(0).GetChild(rand).GetComponent<SpriteRenderer>().sprite;
                currentMonster.GetComponent<SpriteRenderer>().sprite = monsterSprite;
                monsterName.text = monsters.transform.GetChild(0).GetChild(rand).name;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void EndEncounter()
    {
        SceneManager.LoadScene(0);
    }
}
