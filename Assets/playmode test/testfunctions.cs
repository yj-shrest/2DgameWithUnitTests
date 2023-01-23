using NSubstitute;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
namespace test
{
    public class testfunctions
    {

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator testdead()
        {
            Player.position.y = -3;
            Assert.AreEqual(true,Player.isdead());

            yield return null;
        }
        [UnityTest]
        public IEnumerator jumpTest()
        {
            var player = new GameObject().AddComponent<Player>();
            var playerInput = Substitute.For<IPlayerInput>();
            playerInput.jumpclick().Returns(true);
            playerInput.checkground().Returns (true);
            player.PlayerInput = playerInput;
            float initialheight = player.transform.position.y;

            Debug.Log("inital=");
            Debug.Log(initialheight);
            yield return new WaitForSeconds(0.6f);
            Assert.Greater(player.transform.position.y, initialheight);
        }

        [UnityTest]
        public IEnumerator moveRight()
        {
            var player = new GameObject().AddComponent<Player>();
            //PlayerMovement playermovement = player.AddComponent<PlayerMovement>()
            var playerInput = Substitute.For<IPlayerInput>();
            playerInput.getHorizontal().Returns ( 1 );
            player.PlayerInput = playerInput;

            yield return new WaitForSeconds(1f);
            Assert.IsTrue(player.transform.position.x > 0);
        }
        [UnityTest]
        public IEnumerator moveLeft()
        {
            var player = new GameObject().AddComponent<Player>();
            //PlayerMovement playermovement = player.AddComponent<PlayerMovement>();
           
            var playerInput = Substitute.For<IPlayerInput>();
            playerInput.getHorizontal().Returns(-1);
            player.PlayerInput = playerInput;

            yield return new WaitForSeconds(1f);
            Assert.IsTrue(player.transform.position.x < 0);
        }

    }
}
