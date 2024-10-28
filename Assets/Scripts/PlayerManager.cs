using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static int Currency;
    public int startingCurrency = 500;
    public int incomeAmount = 10;

    public static int Lives;
    public int startingLife = 5;

    private void Start()
    {
        Currency = startingCurrency;
        Lives = startingLife;

        StartCoroutine(GenerateIncome());
    }

    private IEnumerator GenerateIncome()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Currency += incomeAmount;
        }
    }
}
