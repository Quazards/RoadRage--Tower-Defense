using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public enum SpawnState { spawning, waiting, counting };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Transform spawnPoint;

    [SerializeField] private Text waveCountText;

    public Wave[] waves;
    private int nextWave = 0;

    public float delayBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState spawnState = SpawnState.counting;

    private void Start()
    {
        waveCountdown = delayBetweenWaves;
    }

    private void Update()
    {
        if (spawnState == SpawnState.waiting)
        {
            if (!isEnemyAlive())
            {
                CompleteWave();
                Debug.Log("wave complete");
                
            }
            else return;
        }

        if (waveCountdown <= 0)
        {
            if (spawnState != SpawnState.spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
                waveCountText.text = "Wave Counter: " + nextWave .ToString();
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }

        
    }

    private void CompleteWave()
    {
        spawnState = SpawnState.counting;
        waveCountdown = delayBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("waves complete");
            //game complete 
        }
        else nextWave++;
        
    }

    private bool isEnemyAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        Debug.Log("spawning wave" +  _wave.name);
        spawnState = SpawnState.spawning;

        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        spawnState = SpawnState.waiting;

        yield break;
    }

    private void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
