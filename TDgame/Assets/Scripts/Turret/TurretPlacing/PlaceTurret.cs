using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;

public class PlaceTurret : MonoBehaviour
{
    public GameObject PlaceIndicator;
    public GameObject Turret;
    public MetalHandler metal;
    private bool dragging = false;
    private Vector3 mousePosition;
    private GameObject placedIndicator;
    public Tilemap gridTilemap;
    public Vector3 gridCellSize = new Vector3(1f, 1f, 0f);
    public float tweenDuration = 0.5f;

    public void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;

        if (dragging && placedIndicator != null)
        {
            Vector3Int cellPosition = gridTilemap.WorldToCell(mousePosition);
            Vector3 snappedPosition = gridTilemap.GetCellCenterWorld(cellPosition);

            placedIndicator.transform.DOMove(snappedPosition, tweenDuration);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (placedIndicator != null)
            {
                Instantiate(Turret, placedIndicator.transform.position, Quaternion.identity);
                Destroy(placedIndicator);
            }
        }
    }

    public void TurretToMouse()
    {
        metal.metal -= 400;
        if (placedIndicator == null)
        {
            dragging = true;
            Vector3Int cellPosition = gridTilemap.WorldToCell(mousePosition);
            Vector3 snappedPosition = gridTilemap.GetCellCenterWorld(cellPosition);
            placedIndicator = Instantiate(PlaceIndicator, snappedPosition, Quaternion.identity);
        }
        else
        {
            dragging = false;
        }
    }
}
