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
        // �]�m Gizmos �C��
        Gizmos.color = Color.yellow;

        // ø�s���ʽd�򪺽u��
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnDrawGizmosSelected()
    {
        // �]�m Gizmos �C��]����Q�襤�ɡ^
        Gizmos.color = new Color(1, 0.92f, 0.016f, 0.3f); // �b�z��������

        // ø�s���ʽd�򪺹�߲y��
        Gizmos.DrawSphere(transform.position, range);
    }
}
