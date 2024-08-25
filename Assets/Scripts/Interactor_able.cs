using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor_able: MonoBehaviour 
{
    public float range = 3f;
    [SerializeField] GameObject detectedObject;

    
    public void Interactor(InputAction.CallbackContext ctx)
    {
        Object.FindAnyObjectByType<Flage>().Touch();
        //int interactableLayer = LayerMask.NameToLayer("I_interactable");
        //int layerMask = 1 << interactableLayer;
        //if (Physics2D.OverlapCircle(transform.position, range, layerMask))
        //{
        //    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range, layerMask);
        //    detectedObject = colliders[0].gameObject;
        //    Debug.Log(colliders.Length);
        //    colliders[0].gameObject.GetComponent<Flage>().Touch();
        //}
    }
    private void OnDrawGizmos()
    {
        // 設置 Gizmos 顏色
        Gizmos.color = Color.yellow;

        // 繪製互動範圍的線框
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnDrawGizmosSelected()
    {
        // 設置 Gizmos 顏色（當物件被選中時）
        Gizmos.color = new Color(1, 0.92f, 0.016f, 0.3f); // 半透明的黃色

        // 繪製互動範圍的實心球體
        Gizmos.DrawSphere(transform.position, range);
    }
}
