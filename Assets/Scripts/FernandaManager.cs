using System;
using UnityEngine;
public class FernandaManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform[] checkpoints;
    [SerializeField] private GameObject fernanda;

    [Header("Variables")] 
    [SerializeField] private float timer1 = 0.0f;
    [SerializeField] private float timer2 = 0.0f;
    [SerializeField] private float timeToAppear = 5.0f;
    [SerializeField] private float timeInScene = 15.0f;
    public bool _isActive;
    
    void Update()
    {

        if (!_isActive)
        {
            timer1 += Time.deltaTime;
        }
        
        if (timer1 > timeToAppear)
        {
            _isActive = true;
            timer2 += Time.deltaTime;
            if (timer2 > timeInScene)
            {
                timer1 = 0f;
                timer2 = 0f;
                fernanda.SetActive(false);
                _isActive = false;
            }
            else
            {
                if(fernanda.activeSelf)return;
                FerSpawn();
            }
        }
    }

    private void FerSpawn()
    {
        int i = UnityEngine.Random.Range(0, checkpoints.Length);

        Debug.Log(i);
        fernanda.SetActive(true);
        fernanda.transform.position = checkpoints[i].transform.position;
    }
}
