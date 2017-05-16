using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomly : MonoBehaviour {
    public float timer;
    public int newtarget;
    public float speed;
    public UnityEngine.AI.NavMeshAgent nav;
    public Vector3 Target;

	// Use this for initialization
	void Start () {
        nav = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        nav.speed = speed;
        if (timer >= newtarget)
        {
            newTarget();
            timer = 0;
        }
	}
    void newTarget()
    {
        float myX = gameObject.transform.position.x;
        float myZ = gameObject.transform.position.z;

        float xPos = myX + Random.Range(myX - 10, myX + 10);
        float zPos = myZ + Random.Range(myZ - 10, myZ + 10);

        Target = new Vector3(xPos, gameObject.transform.position.y, zPos);
    }
}
