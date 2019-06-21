using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
namespace Tests
{
    #region Module
    public class TestSuite
    {
        private Player player;
        private GameManager gameManager;

        [SetUp]
        public void Setup()
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Game");
            GameObject clone = Object.Instantiate(prefab);
            player = Object.FindObjectOfType<Player>();
            gameManager = clone.GetComponent<GameManager>();
        }
        #region Unit test
        [UnityTest]
        public IEnumerator GameManagerWasLoaded()
        {

            yield return new WaitForEndOfFrame();
            // Check if it exists after frame
            Assert.IsTrue(gameManager != null);
        }

        [UnityTest]
        public IEnumerator PlayerExists()
        {

            yield return new WaitForEndOfFrame();

            Player player = gameManager.GetComponentInChildren<Player>();
            Assert.IsTrue(player != null);

        }
        [UnityTest]
        public IEnumerator ItemColidesWithPlayer()
        {
            // Get the player
            
            // Get an item
            Item item = Object.FindObjectOfType<Item>();



            player.transform.position = new Vector3(0, 2, 0);
            item.transform.position = new Vector3(0, 2, 0);





            // Position both in the same location
            yield return new WaitForSeconds(0.1f);


            Assert.IsTrue(item == null);
        }
        [UnityTest]
        public IEnumerator ScoreColection()
        {                       
            // Get an item
            Item item = Object.FindObjectOfType<Item>();

            int oldScore = gameManager.score;

            player.transform.position = new Vector3(0, 4, 0);
            item.transform.position = new Vector3(0, 4, 0);
                                 
            yield return new WaitForSeconds(0.1f);

            Assert.IsTrue(gameManager.score == oldScore + 1);
        }
        [UnityTest]
        public IEnumerator PlayerShootsItem()
        {
            Item item = Object.FindObjectOfType<Item>();

            player.transform.position = new Vector3(0, 2, -2);
            item.transform.position = new Vector3(0, 2, 0);

            yield return null;

            Assert.IsTrue(player.Shoot());
           
        }


        #endregion
        [TearDown]
        public void Teardown()
        {
            Object.Destroy(gameManager.gameObject);
        }



    }
    #endregion
}