using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnoGenerator : MonoBehaviour
{
    public GameObject[] prefabs;
    float intervalTime;
    public float intervalFrom;
    public float intervalTo;
    public float elapsedTimeMax;
    float elapsedTime = 0;

    public int startTime;
    GameObject instance;

    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        intervalTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPlaying)
        {
            intervalTime += Time.deltaTime;

            elapsedTime += Time.deltaTime;
            float t = elapsedTime / elapsedTimeMax;
            float interval = Mathf.Lerp(intervalFrom, intervalTo, t);

            if (interval < intervalTime)
            {
                intervalTime = 0;
                int prefabID = Random.Range(0, prefabs.Length);
                float posX = Random.Range(minX, maxX);
                float posY = Random.Range(minY, maxY);
                instance = Instantiate(prefabs[prefabID], new Vector2(posX, posY), Quaternion.identity);
                Destroy(instance, 1);
            }
        }
    }
}
