using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Berkay
{ 
    public class InputCanvas : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick joystick;

        public float HorizontalInp => joystick.Horizontal;
        public float VerticalInp => joystick.Vertical;

        public static InputCanvas Instance;

        private void OnEnable()
        {
            Instance = this;
        }
    }
}