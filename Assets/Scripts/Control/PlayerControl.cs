using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class PlayerControl : MonoBehaviour
{
    public UsableObject equipedObject = null;
    [SerializeField] Prisoner prisoner;
    [SerializeField] PlayableDirector startCutscene;
    [SerializeField] PlayableDirector winCutscene;
    [SerializeField] PlayableDirector loseCutscene;

    private void Start()
    {
        startCutscene.Play();
        prisoner.OnWin += PlayWinCutscene;
        prisoner.OnLose += PlayLoseCutscene;

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckWhatWasHit();
        }
    }

    private void PlayLoseCutscene()
    {
        loseCutscene.GetComponent<CutscenesControl>().winLoseMenu.SetActive(true);
        loseCutscene.Play();
    }

    private void PlayWinCutscene()
    {
        winCutscene.GetComponent<CutscenesControl>().winLoseMenu.SetActive(true);
        winCutscene.Play();
    }

    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    private void CheckWhatWasHit()
    {
        RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
        foreach (RaycastHit hit in hits)
        {
            ICollectable collectable = hit.transform.GetComponent<ICollectable>();
            Prisoner prisoner = hit.transform.GetComponent<Prisoner>();

            if (collectable != null)
            {
                collectable.Collect();
            }

            if (prisoner != null && equipedObject != null)
            {
                equipedObject.UseObject(prisoner);
                GameObject.FindWithTag("Inventory").GetComponent<InventoryUI>().TakeFromInventory(equipedObject.name);
                equipedObject = null;
            }
        }
    }
}
