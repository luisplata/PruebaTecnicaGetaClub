using UnityEngine;

internal interface IObjectPool
{
    void RecycleObject(GameObject gameObjectRecycler);
    Map CreateMap(Map map);
}