using UnityEngine;
using System.Collections;

// Responsible for creating the barrels that fall at the beginning of the game
public class SpawnerController : MonoBehaviour
{
    // ref for the GameObject (pre-made) that gives rise to the 5 barrels (clones) we create
    public GameObject oilDrumPrefab;
    private static int count = 0; 

	// Use this for initialization
	void Start ()
    {
        //Spawn all the things
        Spawn();
	}

    // Update is called once per frame
    void Update()
    {
        // The weapon becomes visible
        //if (Input.GetKeyDown(KeyCode.R))
       // {
            //Re spawn all the things
         //   Spawn();   
       // }


        if (count <= 0)
        {
            //Re spawn all the things
            Spawn();
        }


    }

    private void Spawn()
    {
        // Creating the 5 barrels and drawing a random position in x
        for (int i = 0; i < 5; i++)
        {
            float posX = Random.Range(-10f, 10f);
            GameObject oilDrum = Instantiate(oilDrumPrefab);
            oilDrum.transform.position = new Vector3(posX, transform.position.y, 0f);
            count++;
        }

    }

    public static void DestroyItem(GameObject go)
    {
        count--;
        Destroy(go);

    }


}
