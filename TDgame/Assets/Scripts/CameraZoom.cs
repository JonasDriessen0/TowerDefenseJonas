using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float ZoomChange;
    public float SmoothChange;
    public float MinSize, MaxSize;
    public float MinBorderX, MaxBorderX;
    public float MinBorderY, MaxBorderY;

    private Camera cam;
    public CameraMove camMove;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            cam.orthographicSize -= ZoomChange * Time.deltaTime * SmoothChange;
            camMove.XcamBorderLeft += 0.6f;
            camMove.XcamBorderRight += 0.6f;
            camMove.YcamBorderLeft += 0.6f;
            camMove.YcamBorderRight += 0.6f;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            cam.orthographicSize += ZoomChange * Time.deltaTime * SmoothChange;
            camMove.XcamBorderLeft -= 0.5f;
            camMove.XcamBorderRight -= 0.5f;
            camMove.YcamBorderLeft -= 0.5f;
            camMove.YcamBorderRight -= 0.5f;
        }
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, MinSize, MaxSize);
        camMove.XcamBorderLeft = Mathf.Clamp(camMove.XcamBorderLeft, 23.1f, 29.6f);
        camMove.XcamBorderRight = Mathf.Clamp(camMove.XcamBorderRight, 2.900001f, 9.400001f);
        camMove.YcamBorderLeft = Mathf.Clamp(camMove.YcamBorderLeft, 0.09999943f, 6.599999f);
        camMove.YcamBorderRight = Mathf.Clamp(camMove.YcamBorderRight, 0.09999943f, 6.599999f);
    }
}
