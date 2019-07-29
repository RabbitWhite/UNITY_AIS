using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISteeringBehaviorIndividual<T>
{
    void updateVelocity(ref T ownRB);
}
