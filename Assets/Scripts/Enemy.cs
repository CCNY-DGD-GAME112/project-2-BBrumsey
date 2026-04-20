using JetBrains.Annotations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*
    Enemy:
    Base script for enemies.
    Stores shared values like speed and vision range.
    Other enemy scripts can build off this.
    */

    public float speed = 5;
    public float visionRange = 5;
    public virtual void DetectPlayer()
    {

    }
    
}
