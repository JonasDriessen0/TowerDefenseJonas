using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTurret : MonoBehaviour
{
    public GameObject TurretToPlace;
    private bool dragging = false;
    Vector3 mousePosition;
    public void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        if (dragging)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = mousePosition;
        }
    }

    public void TurretToMouse()
    {
        Instantiate(TurretToPlace);
    }
}
