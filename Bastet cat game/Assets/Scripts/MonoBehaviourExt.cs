using UnityEngine;

public static class MonoBehaviourExt {
    public static T FindComponentInSelfOrParents<T>(this GameObject self) {
        T selfComponent = self.GetComponentInParent<T>();
        if(selfComponent != null) return selfComponent;
        T parentComponent = self.GetComponentInParent<T>();
        if(parentComponent != null) return parentComponent;
        return default(T);
    }
    
}