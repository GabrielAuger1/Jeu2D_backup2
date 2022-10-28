using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OntriggerUtil : MonoBehaviour
{
    public string targetTag = "Player";
    public UnityEvent OntriggerEnterEvent, OnTriggerExitEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            OntriggerEnterEvent?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            OntriggerEnterEvent?.Invoke();
        }
    }
}
