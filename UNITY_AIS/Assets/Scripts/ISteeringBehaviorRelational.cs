using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISteeringBehaviorRelational<T>
{
    void updateVelocity(ref T ownRB, ref T targetRB);
}
