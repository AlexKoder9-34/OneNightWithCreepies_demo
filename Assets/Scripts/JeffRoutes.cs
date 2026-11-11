using System;
using UnityEngine;
using System.Collections.Generic;

public class JeffRoutes : MonoBehaviour
{
    [SerializeField] private List<Transform> jeffWay1;
    [SerializeField] private List<Transform> jeffWay2;
    
    public List<Transform> Way1() => jeffWay1;
    public List<Transform> Way2() => jeffWay2;
    
    
}
