using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
   [SerializeField] private Slider slider;
   private Transform target;   // enemigo a seguir
    private Vector3 offset;     // ajuste de posición (encima de la cabeza)

    private Camera cam;


    void Start()
    {
        cam = Camera.main;
        offset = new Vector3(0, 1f, 0); 
          // Busca el slider dentro del propio objeto (o de sus hijos)
        slider = GetComponentInChildren<Slider>();
        if (slider == null)
        {
        Debug.LogError("No se encontró un Slider en los hijos de la HealthBar", this);
         }
        
    }

    public void Setup(Transform targetTransform)
    {
        target = targetTransform;
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }


        // convertir posición del mundo a pantalla
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position + offset);
        transform.position = screenPos;
     
    }

    public void SetHealth(float value)
    {
        slider.value = value;
         Debug.Log($"Slider value set to: {value}");
    }
}
