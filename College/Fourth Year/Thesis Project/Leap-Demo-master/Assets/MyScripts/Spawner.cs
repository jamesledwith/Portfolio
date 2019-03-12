using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
    public GameObject CubesPrefab;
    public GameObject CubesPrefabSecond;
    public bool spawned;
    //public GameObject Position;
    //public Quaternion min;
    //public Quaternion max;

    

    public Vector3 center;
    public void SpawnObjects() 
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Player");
        //foreach (GameObject cube in cubes){ Destroy(cube);}
        
        int num = Random.Range(0,2);
        if (num == 1)
            Instantiate(CubesPrefab, this.transform.position, transform.rotation * Quaternion.Euler(90, 0, 0));
        else
            Instantiate(CubesPrefabSecond, this.transform.position, transform.rotation * Quaternion.Euler(90, 0, 0));
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
