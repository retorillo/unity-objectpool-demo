using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPoolNotifier {
  void OnEnqueuedToPool();
  void OnCreateOrDequeueFromPool(bool created);
}
public class ObjectPool : MonoBehaviour {

  [SerializeField]
  private GameObject prefab;
  private Queue<GameObject> inactiveObjects = new Queue<GameObject>();
 
  public GameObject GetObject() {
    GameObject o;
    bool created;
    if (inactiveObjects.Count > 0) {
      created = false;
      o = inactiveObjects.Dequeue();
      o.transform.parent = null;
      o.SetActive(true);
    }
    else {
      created = true;
      o = Instantiate(prefab);
      var tag = o.AddComponent<PoolObject>();
      tag.owner = this;
      tag.hideFlags = HideFlags.HideInInspector;
    }
    var N = o.GetComponents<IObjectPoolNotifier>();
    foreach (var n in N)
      n.OnCreateOrDequeueFromPool(created);
    return o;
  } 
  public void ReturnObject(GameObject o) {
    var N = o.GetComponents<IObjectPoolNotifier>();
    foreach (var n in N)
      n.OnEnqueuedToPool();
    o.SetActive(false);
    o.transform.parent = this.transform;
    inactiveObjects.Enqueue(o);
  }
}
