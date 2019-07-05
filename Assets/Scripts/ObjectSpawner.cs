using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    // ref for the GameObject (pre-made) that gives rise to the 5 barrels (clones) we create
    public GameObject spawnPrefab;
    public float SpawnArea = 10;

    private static int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn all the things
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (count <= 0)
        {
            //Re spawn all the things
            Spawn();
            //StartCoroutine(RespawnTimeOut());
        }
    }

    private void Spawn()
    {
        // Creating the 5 barrels and drawing a random position in x
        for (int i = 0; i < 5; i++)
        {
            float posX = Random.Range(-SpawnArea, SpawnArea);
            GameObject oilDrum = Instantiate(spawnPrefab);
            oilDrum.transform.position = new Vector3(posX, transform.position.y, 0f);
            count++;
        }

    }

    IEnumerator RespawnTimeOut()
    {
        int timeToRespawn = Random.Range(1, 10);
        yield return new WaitForSeconds(timeToRespawn);

    }

    public static void DestroyItem(GameObject go)
    {
        count--;
        Destroy(go);

    }
}
