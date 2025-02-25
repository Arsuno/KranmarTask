using UnityEngine;
using UnityEngine.InputSystem;

[ExecuteInEditMode]
public class Zoom : MonoBehaviour
{
    Camera camera;
    public float defaultFOV = 60;
    public float maxZoomFOV = 15;
    [Range(0, 1)]
    public float currentZoom;
    public float sensitivity = 1;

    public bool _zoomed = false;
    
    void Awake()
    {
        // Get the camera on this gameObject and the defaultZoom.
        camera = GetComponent<Camera>();
        if (camera)
        {
            defaultFOV = camera.fieldOfView;
        }
    }

    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            if (!_zoomed)
            {
                camera.fieldOfView = maxZoomFOV;
                _zoomed = true;
            }
            else
            {
                camera.fieldOfView = defaultFOV;
                _zoomed = false;
            }
        }
    }
}
