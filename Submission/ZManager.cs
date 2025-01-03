﻿using UnityEngine;
using System.Collections.Generic;
//using System;

public class ZManager : MonoBehaviour
{
    public static ZManager instance; // Singleton for easy access
    public List<GameObject> enemies = new List<GameObject>(); // List to store all enemies
    public List<GameObject> hearts = new List<GameObject>(); // List to store all enemies
    public List<GameObject> zaps = new List<GameObject>(); // List to store all enemies
    public GameObject enemyPrefab; // Reference to the enemy prefab to be spawned
    public Vector3 spawnPosition = new Vector3(0, 10, 0);
    private int x;
    private int y;
    private float timer = 0f; // Timer variable to track time
    public float interval = 20f; // Interval in seconds (30 seconds)
    private static int numZ = 2;
    public GameObject[] points;
    private static int ranNum;
    private static int speedUp = 4;
    private float addSpeed = 0.005f;
    public GameObject heartPrefab;
    public GameObject lightningPrefab;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        SpawnEnemy();
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            x = UnityEngine.Random.Range(-4, 4);
            y = UnityEngine.Random.Range(-4, 4);
            //spawnPosition =new Vector3(x, y, 0);//12/11
            ranNum= UnityEngine.Random.Range(0, 10);
            Vector3 slightMod = new Vector3(x, y, 0);
            spawnPosition = points[ranNum].transform.position+slightMod;//spawn rndomly  at one of the cubes
            // Instantiate the enemy prefab at the spawn position
            GameObject initialEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Register the newly spawned enemy with the ZManager
            RegisterEnemy(initialEnemy);
        }
        else
        {
            Debug.LogError("Enemy prefab is not assigned in ZManager.");
        }
    }

    void spawnHeart() {

        x = UnityEngine.Random.Range(-57, 57);
        y = UnityEngine.Random.Range(-20, 20);
        spawnPosition = new Vector3(x, y, 0);//12/11

        GameObject Heal = Instantiate(heartPrefab, spawnPosition, Quaternion.identity);
        RegisterHeart(Heal);

    }

    void spawnLightning()
    {

        x = UnityEngine.Random.Range(-57, 57);
        y = UnityEngine.Random.Range(-20, 20);
        spawnPosition = new Vector3(x, y, 0);//12/11

        GameObject Shock = Instantiate(lightningPrefab, spawnPosition, Quaternion.identity);
        RegisterLightning(Shock);

    }

    public void deleteHeart(GameObject heart)//maybe a problem
    {
        hearts.Remove(heart);  // Remove from the list
        Destroy(heart);

    }

    public void deleteLightning(GameObject lightning)//maybe a problem
    {
        zaps.Remove(lightning);  // Remove from the list
        Destroy(lightning);

    }

    public void RegisterEnemy(GameObject enemy)
    {
        enemies.Add(enemy); // Add enemy to the list
    }

    public void UnregisterEnemy(GameObject enemy)
    {
        enemies.Remove(enemy); // Remove enemy from the list
    }

    public void RegisterHeart(GameObject heart)
    {
        hearts.Add(heart); // Add enemy to the list
    }

    public void UnregisterHeart(GameObject heart)
    {
        hearts.Remove(heart); // Remove enemy from the list
    }

    public void RegisterLightning(GameObject lightning)
    {
        zaps.Add(lightning); // Add enemy to the list
    }

    public void UnregisterLightning(GameObject lightning)
    {
        zaps.Remove(lightning); // Remove enemy from the list
    }

    private void Update()
    {

        timer += Time.deltaTime;

        // If 30 seconds have passed, execute the method
        if (timer >= interval)
        {
            for (int i = 0;i<numZ;i++ )
            {
                SpawnEnemy();

            }

            int powerUp = UnityEngine.Random.Range(0, 2);
            if (powerUp == 1)
            {
                spawnHeart();
            }
            else { 
                spawnLightning();
            }

            //spawnHeart();
            //SpawnEnemy();
            timer = 0f; // Reset the timer
            numZ++;
            if (numZ >= speedUp)
            {
                Debug.Log("d1 speed: "+Drive1.speed);
                addSpeed = Drive1.speed + 0.015f;
                Debug.Log("newSpeed: " + addSpeed);
                Drive1.speed = addSpeed;  // Set the speed to a new value
                speedUp += 4;
            }
        }

      
    }
}
