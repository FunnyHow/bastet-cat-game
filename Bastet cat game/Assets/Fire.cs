using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fire : MonoBehaviour
{
    HashSet<Collider2D> intersectingObjects = new HashSet<Collider2D>();
    HashSet<Health> affectedObjects = new HashSet<Health>();

    void Awake() {
        StartCoroutine("DamageOthers");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        intersectingObjects.Add(other);UpdateDamageables();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        intersectingObjects.Remove(other);UpdateDamageables();
    }

    void UpdateDamageables() {
        affectedObjects = new HashSet<Health>((from x in intersectingObjects
            select FindDamageable(x.gameObject)).Where(it => it != null));

    }

    Health FindDamageable(GameObject obj) {
        Health selfHealth = obj.gameObject.GetComponentInParent<Health>();
        if(selfHealth != null) return selfHealth;
        Health parentHealth = obj.gameObject.GetComponentInParent<Health>();
        if(parentHealth != null) return parentHealth;
        return null;
    }

    IEnumerator DamageOthers()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            foreach (Health damageable in affectedObjects) {
                damageable.health--;
            }
        }
    }
}
