using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RoleShowButton : MonoBehaviour
{
    [SerializeField] private ShipRoleData shipRoleData;
    [SerializeField] private Canvas _root;
    [SerializeField] private DataPage dataPagePrefab;
    [SerializeField, HideInInspector] private Button _buttonComponent;

    private void OnValidate()
    {
        _buttonComponent ??= GetComponent<Button>();
    }

    private void Start()
    {
        _buttonComponent.onClick.AddListener(ShowData);
    }

    public void ShowData()
    {
        DataPage.staticRoleData = shipRoleData;
        SceneManager.LoadScene("PageScene");
    }
}
