using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCountManager : MonoBehaviour
{
    [SerializeField] private SceneManagement sceneManager;
    [SerializeField] private int enemyLayer;

    Health[] enemies;
    int[] health;
    bool enemyAlive;

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
        if (!enemyAlive) sceneManager.LoadNextScene();
    }

    private Health[] FindGameObjectsWithLayer() {
        Health[] enemiesHealth = FindObjectsOfType<Health>();
        Health[] enemies = null;
        int count = 0;
        foreach (Health character in enemiesHealth)
        {
            if (character.gameObject.layer == enemyLayer) enemies[count++] = character;
        }
        Debug.Log("This level has " + enemies.Length + " enemies in it");
        return enemies;
    }
}
