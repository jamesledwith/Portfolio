using UnityEngine;
using System.Collections;

public class HoleMeshCode : MonoBehaviour {

	// Use this for initialization
	void Start () {

       
	}
	
	// Update is called once per frame
	void Update () {
        //combineMeshes();
        Vector3 oldPos = transform.position;
        Quaternion oldQuat = transform.rotation;

        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        Mesh m = new Mesh();

        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        for (int i = 0; i < meshFilters.Length; i++)
        {
            if (meshFilters[i].transform == transform)
                continue;
            combine[i].subMeshIndex = 0;
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;

            meshFilters[i].gameObject.SetActive(false);
        }

        GetComponent<MeshFilter>().sharedMesh = m;
        transform.rotation = oldQuat;
        transform.position = oldPos;
	}


    /*public void combineMeshes()
    {
        Vector3 oldPos = transform.position;
        Quaternion oldQuat = transform.rotation;

        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        Mesh m = new Mesh();

        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        for (int i = 0; i < meshFilters.Length; i++)
        {
            if (meshFilters[i].transform == transform)
                continue;
            combine[i].subMeshIndex = 0;
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;

            meshFilters[i].gameObject.SetActive(false);
        }

        GetComponent<MeshFilter>().sharedMesh = m;
        transform.rotation = oldQuat;
        transform.position = oldPos; 
    }*/

}
