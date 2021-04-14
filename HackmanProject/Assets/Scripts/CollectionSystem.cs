using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The collection system is our SUBSCRIBER or LISTENER
public class CollectionSystem : MonoBehaviour
{

    private void OnEnable()
    {
        Evently.instance.Subscribe<CollectionEvent>(OnCollectionEvent);;
    }

    private void OnDisable()
    {
        Evently.instance.Unsubscribe<CollectionEvent>(OnCollectionEvent);
    }

    private void OnCollectionEvent(CollectionEvent evt)
    {
        Debug.Log("collect something!");
        Destroy(evt.Collectable.gameObject);
    }
}

public class CollectionEvent
{
    public CollectableComponent Collectable;

    public CollectionEvent(CollectableComponent _collectable)
    {
        Collectable = _collectable;
    }

}
