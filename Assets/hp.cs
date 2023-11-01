using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp : MonoBehaviour
{
    int playerhp;
    [SerializeField] GameObject playerGO;
    Damageable player;
    public Slider bar;
    // Start is called before the first frame update
    void Start()
    {
        bar.maxValue = 3;
        playerhp = playerGO.GetComponent<Damageable>().Health;
        bar.value = playerhp;
    }

    // Update is called once per frame
    void Update()
    {
        bar.value = playerGO.GetComponent<Damageable>().Health;
    }
}
