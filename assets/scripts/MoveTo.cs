using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour {

  public Transform goal;
  private NavMeshAgent agent;

  void Start () {
    this.agent = GetComponent<NavMeshAgent>();
  }

  void Update () {
    if (this.goal) {
      this.agent.destination = goal.position;
    }
  }
}
