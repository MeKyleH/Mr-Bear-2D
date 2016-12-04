using UnityEngine;
using System.Collections;

public class LogicTrigger : MonoBehaviour {
    private enum TriggerType
    {
        WaterStartTrigger,
        WaterStopTrigger
    }

    [SerializeField]
    private TriggerType triggerType;

    private RisingWaterManager risingWaterManager;

	// Use this for initialization
	void Start () {
        risingWaterManager = GameObject.FindObjectOfType<RisingWaterManager>();
        if(!risingWaterManager)
        {
            Debug.Log(name + " couldn't find risingWaterManager");
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            switch(triggerType)
            {
                case TriggerType.WaterStartTrigger:
                    risingWaterManager.TriggerWaterRising(true);
                    break;
                case TriggerType.WaterStopTrigger:
                    risingWaterManager.TriggerWaterRising(false);
                    break;
            }
        }
    }
}
