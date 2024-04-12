using System.Xml.Serialization;
using UnityEngine;

public class PliteManager : MonoBehaviour
{
    public GameObject Replacement_Tower;

    private void Start()
    {
        Collider2D _Collider = gameObject.AddComponent<BoxCollider2D>();
        _Collider.isTrigger = true;
    }
    private void OnMouseDown()
    {
        Replace_Plite_With_Tower();
        Debug.Log("1");
    }

    private void Replace_Plite_With_Tower()
    {
        if (Replacement_Tower != null)
        {
            Debug.Log("2");
            Vector3 Posision = transform.position;
            Quaternion Rotation = transform.rotation;

            Destroy(gameObject);

            GameObject New_Object = Instantiate(Replacement_Tower, Posision, Rotation);
        }
    }
}
