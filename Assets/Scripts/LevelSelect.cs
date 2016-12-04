using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {
    public PlatformPath upPath;
    public PlatformPath rightPath;
    public PlatformPath downPath;
    public PlatformPath leftPath;

    void Start()
    {
        if (upPath != null && !upPath.gameObject.activeInHierarchy)
        {
            upPath = null;
        }
        if (rightPath != null && !rightPath.gameObject.activeInHierarchy)
        {
            rightPath = null;
        }
        if (downPath != null && !downPath.gameObject.activeInHierarchy)
        {
            downPath = null;
        }
        if (leftPath != null && !leftPath.gameObject.activeInHierarchy)
        {
            leftPath = null;
        }
    }
}
