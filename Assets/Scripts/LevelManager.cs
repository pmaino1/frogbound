using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject groundObject;

    [SerializeField]
    private float globalSpeed = 0.005f;

    [SerializeField]
    private List<GameObject> objects = new List<GameObject>();

    private GameObject currHazardSet1;
    private GameObject currHazardSet2;

    private float spawnBoundTop = 16f;
    private float spawnBoundNewSignal = 0f;
    private float spawnBoundBottom = -6f;

    // Start is called before the first frame update
    void Start()
    {
        initHazardSets();
    }

    // Update is called once per frame
    void Update()
    {
        //Initially moves the ground away
        if(groundObject != null)
        {
            groundObject.transform.Translate(Vector3.down * globalSpeed * Time.deltaTime);
            if(groundObject.transform.position.y <= -spawnBoundBottom)
            {
                Destroy(groundObject);
                groundObject = null;
            }
        }

        //Moves the current sets of hazards down
        currHazardSet1.transform.Translate(Vector3.down * globalSpeed * Time.deltaTime);
        if(currHazardSet2 != null) {
            currHazardSet2.transform.Translate(Vector3.down * globalSpeed * Time.deltaTime);
        }

        //if that hazard set has gone too low, spawn a new one
        if(currHazardSet1.transform.position.y <= spawnBoundNewSignal && currHazardSet2 == null)
        {
            newHazardSet();
        }

        if (currHazardSet1.transform.position.y <= spawnBoundBottom)
        {
            Destroy(currHazardSet1);
            currHazardSet1 = currHazardSet2;
            currHazardSet2 = null;
        }
    }

    void newHazardSet() {
        if(currHazardSet2 != null)
        {
            //currHazardSet1 = currHazardSet2;
        }

        currHazardSet2 = (GameObject)Instantiate(objects[Random.Range(0, objects.Count)]);
        currHazardSet2.transform.position = new Vector2(0, spawnBoundTop);
    }

    void initHazardSets()
    {
        currHazardSet1 = Instantiate(objects[Random.Range(0, objects.Count)]);
        currHazardSet1.transform.position = new Vector2(0, spawnBoundTop);
        currHazardSet2 = null;
    }
}
