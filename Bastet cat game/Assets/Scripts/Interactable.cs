using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour {
    public UnityEvent<CharacterController2D> OnInteract;
    HashSet<Collider2D> intersectingObjects = new HashSet<Collider2D>();
    HashSet<CharacterController2D> intersectedCharacters = new HashSet<CharacterController2D>();

    void Awake()
    {
        AssertHasTrigger();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        intersectingObjects.Add(other);
        UpdateSubscriptions();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        intersectingObjects.Remove(other);
        UpdateSubscriptions();
    }

    void HandleInteraction(CharacterController2D other) {
        OnInteract?.Invoke(other);
    }

    void UpdateSubscriptions() {
        HashSet<CharacterController2D> newIntersectedCharacters =
            new HashSet<CharacterController2D>(intersectingObjects
                .Select(it => it.gameObject.FindComponentInSelfOrParents<CharacterController2D>())
                .Where(it => it != null));
        
        foreach(CharacterController2D removed in intersectedCharacters) {
            removed.OnActionEvent.RemoveListener(HandleInteraction);
        }
        foreach(CharacterController2D added in newIntersectedCharacters) {
            added.OnActionEvent.AddListener(HandleInteraction);
        }
        intersectedCharacters = newIntersectedCharacters;
    }

    private void AssertHasTrigger()
    {
        bool hasTrigger = false;
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D coll in colliders)
        {
            hasTrigger |= coll.isTrigger;
            if(hasTrigger) break;
        }
        if(!hasTrigger) Debug.LogError($"${gameObject.name} has no trigger component (at least one Collider2D with trigger=true is required)");
    }
}