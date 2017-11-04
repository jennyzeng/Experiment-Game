using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : BaseManager
{
    public BaseCanvas[] preloadCanvasList;
    List<BaseCanvas> canvasList;
    
    public override void Initialize()
    {
        InitCanvasList();
    }
    
    public void InitCanvasList()
    {
        canvasList = new List<BaseCanvas>();
        for (int i= 0; i<preloadCanvasList.Length; i ++)
        {
            canvasList.Add(Instantiate(preloadCanvasList[i], transform));
        }
    }
    
    public T GetCanvas<T>() where T : BaseCanvas
    {
        if (canvasList == null)
        {
            Debug.LogError("canvas have not yet initiated.");
            return null;
        }
        BaseCanvas canvas = canvasList.Find(item => item is T);
        if (canvas == null)
        {
            Debug.LogError("Failed to get " + typeof(T) + " because it is not registered");
            return null;
        }
        return canvas as T;
    }

    
}
