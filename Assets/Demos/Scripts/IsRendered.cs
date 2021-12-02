using UnityEngine;
using System.Collections;

public class IsRendered : MonoBehaviour {

  //メインカメラに付いているタグ名
  private const string CHARA_CAMERA_TAG_NAME = "MainCamera";

  //カメラに表示されているか
  private bool _isRendered = false;
  private bool _isChangeShade = false;

  private void Update () {

    if(_isRendered && _isChangeShade){
      gameObject.GetComponent<Renderer>().material.shader = Shader.Find("SemiTransparent");
      _isChangeShade = false;
    } else if(!_isRendered && !_isChangeShade) {
      gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
      _isChangeShade = true;
    }

    _isRendered = false;
  }

  //カメラに映ってる間に呼ばれる
  private void OnWillRenderObject(){
    //メインカメラに映った時だけ_isRenderedを有効に
    if(Camera.current.tag == CHARA_CAMERA_TAG_NAME){
      _isRendered = true;
    }
  }

}