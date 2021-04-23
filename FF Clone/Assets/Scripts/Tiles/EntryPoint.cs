using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour
{
    public int sceneIndex;
    public float spawnX, spawnY;

    private GameObject player;

    public Vector3 StartNextScene()
    {
        SceneManager.LoadScene(sceneIndex);
        player = GameObject.Find("Player");
        return player.transform.position = new Vector3(spawnX, spawnY, 0f);
    }
}
