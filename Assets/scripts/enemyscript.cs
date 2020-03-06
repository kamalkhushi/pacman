using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyscript : MonoBehaviour
{
    public Transform[] randompoints;
    public NavMeshAgent agent;
    Vector3 pos;
    public Transform Player;
    bool followPlayer;
    float time = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        followPlayer = false;
         pos = randompoints[Random.Range(0, randompoints.Length)].position;
        agent.SetDestination(pos);
        


    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time<=0)
        {
            followPlayer = true;
        }
        
    }
    private void FixedUpdate()
    {
        if (followPlayer)
        {
            agent.SetDestination(Player.position);
        }
    }
}
