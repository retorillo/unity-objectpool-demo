using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour {

  [SerializeField]
  private ObjectPool pool;

  IEnumerator Start() {
    while (true) {
      var o = pool.GetObject();
      o.transform.position = Random.insideUnitSphere * 4;
      yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
    }
  }
}
