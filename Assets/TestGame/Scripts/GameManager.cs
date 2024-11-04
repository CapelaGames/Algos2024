using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _cube;
        
        public GameObject SpawnCube()
        {
            return SpawnCube(_cube);
        }

        public GameObject SpawnCube(GameObject cube)
        {
            GameObject spawnedCube = Instantiate(cube, transform.position, transform.rotation);

            return spawnedCube;
        }

        private void LogError(string error)
        {
            Debug.LogError("GAME ERROR: " + error);
        }
    }
}