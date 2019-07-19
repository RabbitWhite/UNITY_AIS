using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISteeringBehaviorRelationalToPlayer<T, U>
{
    void updateVelocity(ref T ownRB, ref U targetCC);
}
