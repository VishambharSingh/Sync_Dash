using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEvents : MonoBehaviour
{
    public static MyEvents instance;

    public static Action<float> UpdateMainScore;
    public static Action<float> UpdateGhostScore;

    public delegate void DelegateWithNoParameter();
    
    public static DelegateWithNoParameter HitMainOrbs;
    public static DelegateWithNoParameter HitMainObstacle;   
    public static DelegateWithNoParameter HitGhostOrbs;
    public static DelegateWithNoParameter HitGhostObstacle;
    public static DelegateWithNoParameter ResetGame;
}
