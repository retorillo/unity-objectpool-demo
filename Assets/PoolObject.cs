using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour {
  public ObjectPool owner;
}

public static class PoolObjectExtensions {
  public static void ReturnToPool(this GameObject o) {
    var po = o.GetComponent<PoolObject>();
    if (po == null) {
      return;
    }
    po.owner.ReturnObject(o);
  } 
}
