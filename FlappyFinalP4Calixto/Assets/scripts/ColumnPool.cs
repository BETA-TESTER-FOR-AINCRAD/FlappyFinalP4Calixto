using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float spawnRate = 4f;
    public float columnMin = -1f;
    public float columnMax = 3.5F;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15, -25f);
    private float timeSincelastSpawend;
    private float spawnXPosition = 10f;
    private int currentcolum = 0;

    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate (columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSincelastSpawend += Time.deltaTime;

        if (GameControl.Instance.GameOver == false && timeSincelastSpawend > spawnRate)
        {
            timeSincelastSpawend = 0f;
            float spawnPosition = Random.Range(columnMin, columnMax);
            columns[currentcolum].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentcolum++;
            if (currentcolum >= columnPoolSize)
            {
                currentcolum = 0;
            }
        }
    }
}
