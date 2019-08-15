using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnAfterDelay : MonoBehaviour, IObjectPoolNotifier {
  public void OnCreateOrDequeueFromPool(bool created) {
    Debug.Log("Dequeued from object pool");
    StartCoroutine(DoReturnAfterDelay());
  }
  public void OnEnqueuedToPool() {
    Debug.Log("Enqueued to object pool");
  }
  public IEnumerator DoReturnAfterDelay() {
    yield return new WaitForSeconds(1.0f);
    gameObject.ReturnToPool();
  }
}
