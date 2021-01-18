using System;
using System.Collections;
using NaughtyAttributes.Editor;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace NaughtyAttributes.Tests
{
    public class VisibilityTest
    {
        [Test]
        public void IsVisibleInPlayer()
        {
            var methodInfo = ((Action) VisibilityClass.HiddenInEditModeFunction).Method;
            Assert.IsTrue(ButtonUtility.IsVisible(null, methodInfo),
                "Method with no PlayMode Visibility Modifier should be visible.");
        }

        [Test]
        public void IsNotVisibleInPlayer()
        {
            var methodInfo = ((Action) VisibilityClass.HiddenInPlayModeFunction).Method;
            var isVisible = ButtonUtility.IsVisible(null, methodInfo);
            Assert.IsFalse(isVisible,
                "Method with [HideInPlayMode] should not be visible in PlayMode.");
        }



        private class VisibilityClass : ScriptableObject
        {
            [HideInEditMode] public string hiddenInEditMode;
            [HideInEditMode] public static void HiddenInEditModeFunction() { }
            [HideInPlayMode] public static void HiddenInPlayModeFunction() { }
            [HideInEditMode, HideInPlayMode] public static void HiddenInEditAndPlayMode() { }
        }
    }
}