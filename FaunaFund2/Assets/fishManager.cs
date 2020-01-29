using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class fishManager : MonoBehaviour
{
    [SerializeField] public GameObject fish1Prefab;
    [SerializeField] public GameObject fish2Prefab;
    [SerializeField] public GameObject fish3Prefab;

    public static int tankSize = 10;

    public static int fishCount = 15;

    public static GameObject[] allFish = new GameObject[fishCount];

    public static Vector3 goalPos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> fishPrefabs = new List<GameObject>()
        {
            fish1Prefab,
            fish2Prefab,
            fish3Prefab
        };

        for(int i = 0; i < fishCount; i++)
        {
            Vector3 pos;
            //GameObject currFishPrefab = fishPrefabs[fishrenderer.combined[i].Key - 1]; //setting the current type
            //FOR SEAWEED
            /*if (currFishPrefab == fish3Prefab)
            {*/
              /* pos = new Vector3(fishrenderer.combined[i].Value.Key, //setting the x axis
               fishrenderer.combined[i].Value.Value, //setting the y axis
               Random.Range(-tankSize, tankSize)); //random depth*/

               /*pos = new Vector3(Random.Range(-tankSize, tankSize), //setting the x axis
               Random.Range(-tankSize, tankSize), //setting the y axis
               Random.Range(-tankSize, tankSize)); //random depth*/
            /*}
            else
            {*/
                 pos = new Vector3(Random.Range(-tankSize, tankSize), //setting the x axis
                   5, //setting the y axis
                    Random.Range(-tankSize, tankSize)); //random depth
            // }

            allFish[i] = (GameObject)Instantiate(fish1Prefab, pos, Quaternion.identity); //spqwns it
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 10000) < 50)
        {
            goalPos = new Vector3(Random.Range(-tankSize, tankSize),
                Random.Range(0, tankSize),
                Random.Range(-tankSize, tankSize));
        }
    }
}
