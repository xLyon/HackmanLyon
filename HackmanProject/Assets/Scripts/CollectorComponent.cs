using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorComponent : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CollectableComponent>() != null)
        {
            Evently.instance.Publish(new CollectionEvent(other.GetComponent<CollectableComponent>()));
        }
    }
}
