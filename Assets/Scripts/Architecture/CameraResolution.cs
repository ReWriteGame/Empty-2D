using System;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    [SerializeField] private Vector2 screenAspect = new Vector2(16.0f, 9.0f);
    [SerializeField] private Camera camera;
    [SerializeField] private bool useOwnCamera = true;

    private Vector2Int screenSize = Vector2Int.zero;

    private void Start()
    {
        if (useOwnCamera) camera = GetComponent<Camera>();
    }

    private void Update() => RescaleCamera(camera);
    private void OnPreCull() => OnPreCull(camera);

    private void OnPreCull(Camera camera)
    {
      // if (Application.isEditor) return;
      // Rect wp = camera.rect;
      // Rect nr = new Rect(0, 0, 1, 1);

      // camera.rect = nr;
      // GL.Clear(true, true, Color.black);

      // camera.rect = wp;
    }

    private void RescaleCamera(Camera camera)
    {
        if (Screen.width == screenSize.x && Screen.height == screenSize.y) return;

        float targetaspect = screenAspect.x / screenAspect.y;
        float windowaspect = (float)Screen.width / (float)Screen.height;
        float scaleheight = windowaspect / targetaspect;

        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }

        screenSize.x = Screen.width;
        screenSize.y = Screen.height;
    }
}