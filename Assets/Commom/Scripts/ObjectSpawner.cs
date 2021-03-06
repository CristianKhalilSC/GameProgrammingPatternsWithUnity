﻿using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject objectToSpawn;
    [SerializeField]
    private float timeToSpawn = 2f;
    [SerializeField]
    private Vector3 minPos;
    [SerializeField]
    private Vector3 maxPos;
    [SerializeField]
    private Vector3 rotation;

    private List<GameObject> _objects;
    private float _timer;

    void Awake()
    {
        _objects = new List<GameObject>();
        _timer = 0;
        SpawnObject();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= timeToSpawn)
        {
            SpawnObject();
            _timer = 0;
        }
    }

    private void SpawnObject()
    {
        Vector3 rndPos = new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), Random.Range(minPos.z, maxPos.z));
        GameObject obj = (GameObject)Instantiate(objectToSpawn, rndPos, Quaternion.Euler(rotation));

        _objects.Add(obj);
    }
}
