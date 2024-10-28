using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public Text lifeText;

    private void Update()
    {
        lifeText.text = PlayerManager.Lives.ToString();
    }
}
