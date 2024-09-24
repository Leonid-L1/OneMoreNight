using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSpellStatsView : MonoBehaviour
{
    private static int MaxShowedSpellStats = 12;

    [SerializeField] private Image _prefab;

    private List<Image> _pool = new List<Image>(MaxShowedSpellStats);    //  переделать : включать и выключать

    private void Start()
    {
        for (int i = 0; i < MaxShowedSpellStats; i++)
        {
            GameObject spawned = Instantiate(_prefab.gameObject, transform);
            _pool.Add(spawned.GetComponent<Image>());
            spawned.SetActive(false);
        }  
    }

    public void Show(SpellStat stat)
    {
        Image inactiveStat = _pool.First(image => image.gameObject.activeSelf == false);
        inactiveStat.sprite = stat.RuneImage;
        inactiveStat.gameObject.SetActive(true);
    }

    public void Clear()
    {
        foreach (var item in _pool)
            item.gameObject.SetActive(false);
    }
}
