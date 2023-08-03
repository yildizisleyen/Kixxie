using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    public static Spawn Instance { get; private set; }
    [SerializeField]
    private GameObject _foodPrefab;
    [SerializeField]
    private GameObject _fishPrefab;
    

    private bool _stopSpawning = false;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine(foodSpawning());
        
    }
    IEnumerator foodSpawning()
    {
        yield return new WaitForSeconds(2f);
        while (_stopSpawning == false)
        {
            Vector3 spawnPos1 = new Vector3(Random.Range(3.42f, 4.19f), Random.Range(0.5f, 4.4f), 0);
            Vector3 spawnPos2 = new Vector3(Random.Range(-4.1f, -3.37f), Random.Range(0.5f, 4.4f), 0);
            GameObject Food = Instantiate(_foodPrefab, spawnPos1, Quaternion.identity);
            GameObject Food1 = Instantiate(_fishPrefab, spawnPos2, Quaternion.identity);
            yield return new WaitForSeconds(3f);
            Destroy(Food, 0.2f);
            Destroy(Food1, 0.8f);
        }
    }

    public void endOfGame()
    {
        _stopSpawning = true;
    }

}
