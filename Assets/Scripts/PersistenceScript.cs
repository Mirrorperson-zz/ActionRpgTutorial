using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PersistenceScript : MonoBehaviour {

    private static List<string> existingObjects = new List<string>();

    // Use this for initialization
    void Start () {
        bool objectExists = existingObjects.Any(x => x == transform.gameObject.name);

        if (!objectExists)
        {
            objectExists = true;
            existingObjects.Add(transform.gameObject.name);
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
