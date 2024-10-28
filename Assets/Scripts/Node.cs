using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color startColor;
    public Color hoveringColor;
    public Color warningColor;

    public Vector3 positionOffset;

    public GameObject turret;

    private Renderer render;

    private BuildingManager buildingManager;

    private void Start()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;

        buildingManager = BuildingManager.Instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (!buildingManager.canBuildTurret) return;

        if (turret != null)
        {
            return;
        }

        buildingManager.BuildTurretOn(this);

        
    }

    private void OnMouseEnter()
    {
        if (!buildingManager.canBuildTurret) return;

        if (buildingManager.hasEnoughCurrency)
        {
            render.material.color = hoveringColor;
        }
        else
        {
            render.material.color = warningColor;
        }
    }

    private void OnMouseExit()
    {
        render.material.color = startColor;
    }
}
