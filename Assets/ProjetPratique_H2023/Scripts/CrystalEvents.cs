using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalEvents : MonoBehaviour
{
    [SerializeField] private string m_CrystalTag;
    [SerializeField] private string m_PartsTag;
    [SerializeField] private Vector3 m_InitialPosition;
    private bool m_CanGetDestroyed;

    private CrystalsBehaviour m_CrystalsBehaviour;
    
    void Start()
    {
        m_CrystalsBehaviour = transform.parent.GetComponent<CrystalsBehaviour>();
        m_CanGetDestroyed = Vector3.Distance(transform.position, m_InitialPosition) > 9.0f;

    }

    private void OnEnable()
    {
        m_CanGetDestroyed = Vector3.Distance(transform.position, m_InitialPosition) > 9.0f;
    }

    public void GetMined()
    {
        LevelManager.instance.SpawnObj(m_PartsTag, transform.position, Quaternion.identity);
        LevelManager.instance.ToggleInactive(gameObject);
        LevelManager.instance.UpdateCrystalNums(m_CrystalTag);
    }

    public bool GetCanDestroy()
    {
        return m_CanGetDestroyed;
    }
}
