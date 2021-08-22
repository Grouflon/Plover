using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public struct ParallaxObjectEntry
{
    public string name;
    public Transform prefab;
}

public class GameManager : MonoBehaviour
{
    [Header("Gameplay")]
    public List<ParallaxObjectEntry> objectsPrefabs;

    [Header("Internal")]
    public TextAsset inkAsset;
    public ParallaxController parallaxController;

    // Start is called before the first frame update
    void Start()
    {
        m_story = new Story(inkAsset.text);
        m_story.BindExternalFunction("spawnObject", (string _objectType, string _objectName, string _side, int _layer) =>
        {
            
        });  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Story m_story;
}
