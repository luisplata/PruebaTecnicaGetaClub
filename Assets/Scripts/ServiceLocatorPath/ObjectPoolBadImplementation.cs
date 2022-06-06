using UnityEngine;

public class ObjectPoolBadImplementation : IObjectPool
{
    public void RecycleObject(GameObject gameObjectRecycler)
    {
        Object.Destroy(gameObjectRecycler);
    }

    public Map CreateMap(Map map)
    {
        return Object.Instantiate(map);
    }
}