using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class DisplayResolutionManager : Singleton<DisplayResolutionManager>
    {
        private GameObject currentCamera;

        public float pixelsToUnits = 32.0f;
        public float scale = 1.0f;

        public Vector2 nativeResolution = new Vector2(960, 544);//30 by 17 tiles in the view

        private void Awake()
        {
            currentCamera = GameObject.Find("Main Camera");
            Camera camera = currentCamera.GetComponent<Camera>();

            if (camera.orthographic)
            {
                scale = Screen.height / nativeResolution.y;
                pixelsToUnits *= scale;
                camera.orthographicSize = (Screen.height / 2.0f) / pixelsToUnits;
            }
        }
    }
}
