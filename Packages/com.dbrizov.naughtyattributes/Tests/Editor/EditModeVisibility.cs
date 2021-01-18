using System;
using NaughtyAttributes.Editor;
using NUnit.Framework;
using UnityEngine;

namespace NaughtyAttributes.Tests
{
    public class EditModeVisibility
    {
        [Test]
        public void IsVisibleInEditMode()
        {
            var methodInfo = ((Action) VisibilityClass.HiddenInPlayModeFunction).Method;
            Assert.IsTrue(ButtonUtility.IsVisible(null, methodInfo),
                "Method with no EditMode Visibility Modifier should be visible.");
        }

        [Test]
        public void IsNotVisibleInEditMode()
        {
            var methodInfo = ((Action) VisibilityClass.HiddenInEditModeFunction).Method;
            var isVisible = ButtonUtility.IsVisible(null, methodInfo);
            Assert.IsFalse(isVisible,
                "Method with [HideInEditMode] should not be visible in EditMode");
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