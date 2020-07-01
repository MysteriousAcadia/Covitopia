using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class PredictionScript : MonoBehaviour
{
    public GameObject[] sphere;
    private float multiplier = (float)  1/ 1000000;
    public float totalTime;

    public Text dateText;
    public Text caseText;

    [SerializeField] private string selectableTag = "Sphere";
    [SerializeField] private Material highlight;

    [SerializeField] private Material defaultMaterial;

    private Transform _selection;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CallPredictionApi());
    }

    void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if (selection.CompareTag(selectableTag))
                {
                    var selectionComponent = hit.transform.gameObject;
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null)
                    {
                        selectionRenderer.material = highlight;
                        Debug.Log("Hit something");
                        dateText.text = "Date : " + selectionComponent.GetComponent<PredictionDataStorage>().date;
                        caseText.text = "Cases : " + selectionComponent.GetComponent<PredictionDataStorage>().cases;
                    }
                }
                
            }
            
        }
    }
    
    
    IEnumerator CallPredictionApi()
    {
        string URL = "https://covid19-api.org/api/prediction/IN";
        UnityWebRequest request = UnityWebRequest.Get(URL);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError(request.error);
            yield break;
        }
        JSONNode Info = JSONNode.Parse(request.downloadHandler.text);
        Debug.Log(Info.Count);
        for (int i = 0; i < Info.Count; i++)
        {
            float height = System.Int32.Parse(Info[i]["cases"]);
            height *= multiplier;
            sphere[i].GetComponent<PredictionDataStorage>().date = Info[i]["date"];
            sphere[i].GetComponent<PredictionDataStorage>().cases = Info[i]["cases"];
            StartCoroutine(SmoothMove(i,height));
            
        } 
    }

    IEnumerator SmoothMove(int i,float height)
    {
        
        yield return null;
        float elapsedTime = 0;
        while (elapsedTime < totalTime)
        {
            sphere[i].transform.position = new Vector3(sphere[i].transform.position.x,Mathf.Lerp(0, height, (elapsedTime / totalTime)),sphere[i].transform.position.z);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
    }
    
}
