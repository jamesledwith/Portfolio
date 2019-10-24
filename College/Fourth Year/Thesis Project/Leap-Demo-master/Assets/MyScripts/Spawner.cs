using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
    
    public GameObject[] ObjectsForSpawn;
    public Vector3 spawnValues;
    public Vector3 spawnPosition;
    public int minRange = 0;
    public int maxRange = 1;
    //public GameObject Position;
    //public Quaternion min;
    //public Quaternion max;
    //public GameObject CubesPrefab;
    //public GameObject CubesPrefabSecond;
    //public GameObject SpheresPrefab;
    //public bool spawned;
    

    public Vector3 center;
    public void SpawnObjects() 
    {

        int randObj = Random.Range(minRange, maxRange);
       
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));
        Instantiate(ObjectsForSpawn[randObj], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
        //OLD
    }
    
    
    // Use this for initialization
    void Start()
    {
        SpawnObjects();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}



//OLD
//GameObject[] interactObjs = GameObject.FindGameObjectsWithTag("Player");
//foreach (GameObject interactObj in interactObjs){ Destroy(interactObj);}

//int num = Random.Range(0,2);
//int num = 3;
// if (num == 1)
//Instantiate(CubesPrefab, this.transform.position, transform.rotation * Quaternion.Euler(90, 0, 0));
//else //if (num == 2)
//Instantiate(CubesPrefabSecond, this.transform.position, transform.rotation * Quaternion.Euler(90, 0, 0));
// else 
//if (num == 3)
//Instantiate(SpheresPrefab, this.transform.position, transform.rotation * Quaternion.Euler(90, 0, 0));
