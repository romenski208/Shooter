using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class State : MonoBehaviour
{
    protected NavMeshAgent Agent;
    protected Player Player;

    public void Init(NavMeshAgent agent, Player player)
    {
        Agent = agent;
        Player = player;
    } 
}