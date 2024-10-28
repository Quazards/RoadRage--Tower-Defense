using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;

    private TurretDraft turretToConstruct;

    public bool canBuildTurret { get { return turretToConstruct != null; } }
    public bool hasEnoughCurrency { get { return PlayerManager.Currency >= turretToConstruct.turretCost; } }

    public void ChooseTurretToConstruct(TurretDraft turret)
    {
        turretToConstruct = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerManager.Currency < turretToConstruct.turretCost) return;

        PlayerManager.Currency -= turretToConstruct.turretCost;

        GameObject turret = Instantiate(turretToConstruct.turretPrefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }
}
