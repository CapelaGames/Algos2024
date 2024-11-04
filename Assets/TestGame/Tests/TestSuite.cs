using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;
using TestGame;

namespace TestGame.Tests
{
    public class TestSuite
    {
        private GameManager _gameManager;

        [SetUp]
        public void Setup()
        {
            GameObject gameManagerPrefab = Resources.Load<GameObject>("Prefabs/GameManager");
            GameObject gMGO = Object.Instantiate(gameManagerPrefab);
            _gameManager = gMGO.GetComponent<GameManager>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(_gameManager.gameObject);
        }

        [UnityTest]
        public IEnumerator SpawnCube()
        {
            GameObject cube = _gameManager.SpawnCube();
            yield return null;
            UnityEngine.Assertions.Assert.IsNotNull(cube);
            Object.Destroy(cube);
        }

        [UnityTest]
        public IEnumerator CubeMoveDown()
        {
            GameObject cube = _gameManager.SpawnCube();
            float initalYPos = cube.transform.position.y;
            yield return new WaitForSeconds(0.1f);
            Assert.Less(cube.transform.position.y, initalYPos);
            Object.Destroy(cube);
        }
    }
}
