using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
namespace tests
{

public class TestValues
{

        [Test]
        public void TestSpeed()
        {
            Assert.AreEqual(expected: 5, actual: Player.speed);
        }
        [Test]
        public void TestJump()
        {
            Assert.AreEqual(300, Player.jump);
        }
    }
}

