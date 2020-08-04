using System.Collections;
using UnityEngine;

[RequireComponent (typeof (BeatDetection))]
public class BeatDetectionSceneController : Controller {
  #region Properties
  #region Attributes
  BeatDetection beatDetection;
  public GameObject [] objects;
  public Material [] materials;

  public BeatDetection BeatDetection { get => beatDetection; set => beatDetection = value; }
  #endregion
  #region Getters & Setters

  #endregion
  #endregion
  #region Behaviours
  #region Life Cycle Hooks
  private void Awake() {
    BeatDetection = GetComponent<BeatDetection>();
    if(BeatDetection == null) Application.Unload();
  }
  private void Start () {
    this.BeatDetection.CallBackFunction = MyCallbackEventHandler;
    objects = new GameObject [4];
    materials = new Material [5];
  }
  #endregion
  #region Procedures
  public void MyCallbackEventHandler (EventInformation _info) {
    switch (_info.messageInfo) {
    case EventType.ENERGY:
      StartCoroutine(Enable (objects [0]));
      break;
    case EventType.HITHAT:
      StartCoroutine (Enable (objects [1]));
      break;
    case EventType.KICK:
      StartCoroutine (Enable (objects [2]));
      break;
    case EventType.SNARE:
      StartCoroutine (Enable (objects [3]));
      break;
    }
  }
  private IEnumerator Enable (GameObject _object) {
    Material mat = _object.GetComponent<Renderer> ().material;
    mat = materials [Random.Range(1,4)];
    yield return new WaitForSeconds (0.05f * 3);
    mat = materials [0];
    yield break;
  }
  #endregion
  #region Functions

  #endregion
  #endregion 
}
