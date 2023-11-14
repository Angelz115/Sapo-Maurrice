using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner Variables")] 
    public GameObject entity;
    public GameObject manager;
    public List<Transform> targets = new List<Transform>();
    public List<Transform> positions = new List<Transform>();
    public List<Color> colorTarget = new List<Color>();
    public float timeToSpawn;
    public float timer;
    public float force = 20;
    [Space]
    [Space]

    [Header ("Spawner Lists")]
    [Space]
    [Header("Current List")]
    
    public int cuantity;
    public int travList;
    public List<int> positionList = new List<int>();
    public List<Vector3> alterPos = new List<Vector3>();
    public List<int> targetList = new List<int>();
    public List<Color> colorList = new List<Color>();

    [Space]
    [Space]

    [Header("Total List")]
    public List<int> allPositionList = new List<int>();
    public List<Vector3> allAlterPos = new List<Vector3>();
    public List<int> allTargetList = new List<int>();
    public List<Color> allColorList = new List<Color>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer >= timeToSpawn)
        {
            createObj(travList);
            timer = 0;
        }
        
    }
    public void createObj(int currentObj) 
    {
        if (travList >= cuantity)
            return;
        
        float x = positions[positionList[currentObj]].transform.position.x + allAlterPos[currentObj].x;
        float y = positions[positionList[currentObj]].transform.position.y + allAlterPos[currentObj].y;
        Vector3 pos = new Vector3(x, y, 0);
        GameObject tap = Instantiate(entity, pos, Quaternion.identity);
        tap.GetComponent<SpriteRenderer>().color = colorList[currentObj];

        tap.GetComponent<Behavior>().target = targets[targetList[currentObj]].position;
        tap.GetComponent<Behavior>().force = force;
        tap.GetComponent<Behavior>().Tar = targetList[currentObj];
        //Debug.Log(x + " , " + y);
        travList++;

    }
    void testTarget() 
    {
        if (cuantity >= 4)
        {
            //Debug.Log("Listo");
            return;
        }
        GameObject obj=  Instantiate(entity,positions[cuantity].position,transform.rotation);
        obj.GetComponent<Behavior>().target = targets[cuantity].position;
        obj.GetComponent<Behavior>().force = force;
        cuantity++;
    }
}
