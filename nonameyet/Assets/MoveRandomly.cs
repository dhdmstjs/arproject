using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomly : MonoBehaviour {
    public float timer;
    public int period;
    public float speed;
    UnityEngine.AI.NavMeshAgent agent;
    public Vector3 Target;

	// Use this for initialization
	void Start () {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        agent.speed = speed;
        if (timer >= period)
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
        agent.SetDestination(Target);
    }
}
