using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCountManager : MonoBehaviour
{
    [SerializeField] private int enemyLayer;
    [SerializeField] private int nextScene;


    private SceneManagement sceneManager;
    Health[] characters;
    Health[] enemies;

    int[] health;
    bool enemyAlive;

    private void Awake()
    {
        sceneManager = FindObjectOfType<SceneManagement>();
        nextScene = sceneManager.GetSceneIndex() + 1;
    }

    private void Start()
    {
        enemies = FindGameObjectsWithLayer();
        health = new int[enemies.Length];
    }

    private void Update()
    {
        enemyAlive = false;
        for (int i = 0; i < enemies.Length; i++)
        {
            health[i] = enemies[i].GetHealth();
            if (health[i] > 0) enemyAlive = true;
        }
        if (!enemyAlive) sceneManager.LoadScene(nextScene);
    }

    private Health[] FindGameObjectsWithLayer() {
        characters = FindObjectsOfType<Health>();
        int count = 0;
        enemies = new Health[characters.Length - 1];
        foreach (Health character in characters)
        {
            if (character.gameObject.tag == "Enemy") 
                enemies[count++] = character;
        }
        return enemies;
    }
}
