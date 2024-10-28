using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildingManager buildingManager;

    public TurretDraft standardTurret;

    private void Start()
    {
        buildingManager = BuildingManager.Instance;
    }

    public void ChooseStandardTurret()
    {
        buildingManager.ChooseTurretToConstruct(standardTurret);
    }

    
}
