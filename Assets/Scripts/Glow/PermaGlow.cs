using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PermaGlow : MonoBehaviour
{

    public Color GlowColor;
    public float LerpFactor = 10;
    private Transform player;
    private GameObject manager;

    public Renderer[] Renderers
    {
        get;
        private set;
    }

    public Color CurrentColor
    {
        get { return _currentColor; }
    }

    private List<Material> _materials = new List<Material>();
    private Color _currentColor;
    public Color _targetColor;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        manager = GameObject.Find("Manager");

        Renderers = GetComponentsInChildren<Renderer>();

        foreach (var renderer in Renderers)
        {
            _materials.AddRange(renderer.materials);
        }
        _targetColor = Color.black;
    }

    //private void OnMouseEnter() {
    //       if (Vector3.Distance(transform.position, player.position) < 1.5f) {
    //           _targetColor = GlowColor;
    //           enabled = true;
    //       }
    //}

    /// <summary>
    /// Loop over all cached materials and update their color, disable self if we reach our target color.
    /// </summary>
    private void Update()
    {       
        _currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime * LerpFactor);

        for (int i = 0; i < _materials.Count; i++)
        {
            _materials[i].SetColor("_GlowColor", _currentColor);
        }

        if (_currentColor.Equals(_targetColor))
        {
            //enabled = false;
        }
    }
}
