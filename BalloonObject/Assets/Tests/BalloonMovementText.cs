using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BalloonMovementText
    {
        private GameObject balloonObj;

        [SetUp]
        public void Setup()
        {
            balloonObj = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/balloon"));
        }

        // A Test behaves as an ordinary method
        [Test]
        public void BalloonMovementTextSimplePasses()
        {
            // Use the Assert class to test conditions
            float force = 100;
            float mass = 1;
            float getVelocity = BalloonMovement.getVelocity(force, mass);
            float expexted = (force - mass) / mass * Time.deltaTime;

            CollectionBase.Equals(expexted, getVelocity);

        }

        [Test]
        public void BlastForcePasses()
        {
            // Use the Assert class to test conditions
            PopTheBalloon test = new PopTheBalloon();
            Vector2 targetPos = new Vector2(11.25f,6.35f);
            Vector2 balloonPos = new Vector2(10.75f, 5.02f);
            float m_popForce = 10.0f;

            Vector2 blast = test.getForce(targetPos, balloonPos);
            Vector2 answer = m_popForce * (targetPos - balloonPos);

            CollectionBase.Equals(answer, blast);
        }

        [Test]
        public IEnumerator BalloonPopSoundPasses()
        {
            // Use the Assert class to test conditions

            balloonObj.GetComponent<PopTheBalloon>().setExplod(true);
            yield return new WaitForSeconds(1);
            Assert.True(balloonObj.GetComponent<AudioSource>().isPlaying);
        }

        public IEnumerator BalloonPopAnimationPasses()
        {
            // Use the Assert class to test conditions

            balloonObj.GetComponent<PopTheBalloon>().setExplod(true);
            yield return new WaitForSeconds(1);
            Assert.True(balloonObj.gameObject.GetComponent<Animator>().GetBool("Popping"));
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator BalloonMovementTextWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
