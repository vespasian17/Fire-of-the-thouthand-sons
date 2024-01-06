using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private float zoomSpeed = 1f; 
    [SerializeField] private float ballPhaseZoom = 8f; 
    [SerializeField] private float idlePhaseZoom = 5f; 
    
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    public void CameraZoomOut()
    {
        StopAllCoroutines();
        
        StartCoroutine(nameof(CameraZoom), ballPhaseZoom);
    }
    
    public void CameraZoomIn()
    {
        StopAllCoroutines();
        
        StartCoroutine(nameof(CameraZoom), idlePhaseZoom);
    }
 
    private IEnumerator CameraZoom(float targetZoom)
    {
        var from = _camera.orthographicSize;
        float time = 0;
 
        while (time < 1f)
        {
            time += zoomSpeed * Time.deltaTime;
            _camera.orthographicSize = Mathf.Lerp(from, targetZoom, time);
 
            yield return null;
        }
 
        _camera.orthographicSize = targetZoom;
    }
}

