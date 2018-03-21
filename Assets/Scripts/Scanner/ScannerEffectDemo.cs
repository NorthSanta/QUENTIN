using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScannerEffectDemo : MonoBehaviour
{
	public GameObject ScannerOrigin;
    private Vector3 _ScannerOrigin;
	public Material EffectMaterial;
	public float ScanDistance;
    public float ScanDetection = 5.0f;
    public float MaxScanDistance = 10.0f;

	private Camera _camera;
    private Animator anim;

	// Demo Code
	bool _scanning;
	Scannable[] _scannables;

	void Start() {
        _scannables = FindObjectsOfType<Scannable>();
        anim = ScannerOrigin.GetComponent<Animator>();
    }

	void Update() {
		if (_scanning) {
			ScanDistance += Time.deltaTime * 5; //Velocitat del Scanner
            if (ScanDistance >= MaxScanDistance) {
                _scanning = false;
                ScanDistance = 0;
            }
            foreach (Scannable s in _scannables) {
                if (Vector3.Distance(_ScannerOrigin, s.transform.position) <= ScanDetection) { //Aqui es pot definir a quina distancia maxima es detecten pistes
                    s.Ping();
                }
			}
		}
        print(PlayerPrefs.GetString("SelectedCase"));

        if (Input.GetKeyUp(KeyCode.C) && PlayerPrefs.GetString("SelectedCase") != "Studio") {
            if (!_scanning) {
                _scanning = true;
                ScanDistance = 0;
                _ScannerOrigin = ScannerOrigin.transform.position;
                anim.Play("Scanner");
            }
		}

        /* FOR MOUSE INTERACTION
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit)) {
				_scanning = true;
				ScanDistance = 0;
				ScannerOrigin.position = hit.point;
			}
		}*/
	}
	// End Demo Code

	void OnEnable() {
		_camera = GetComponent<Camera>();
		_camera.depthTextureMode = DepthTextureMode.Depth;
	}

	[ImageEffectOpaque]
	void OnRenderImage(RenderTexture src, RenderTexture dst) {
		EffectMaterial.SetVector("_WorldSpaceScannerPos", _ScannerOrigin);
		EffectMaterial.SetFloat("_ScanDistance", ScanDistance);
		RaycastCornerBlit(src, dst, EffectMaterial);
	}

	void RaycastCornerBlit(RenderTexture source, RenderTexture dest, Material mat) {
		// Compute Frustum Corners
		float camFar = _camera.farClipPlane;
		float camFov = _camera.fieldOfView;
		float camAspect = _camera.aspect;

		float fovWHalf = camFov * 0.5f;

		Vector3 toRight = _camera.transform.right * Mathf.Tan(fovWHalf * Mathf.Deg2Rad) * camAspect;
		Vector3 toTop = _camera.transform.up * Mathf.Tan(fovWHalf * Mathf.Deg2Rad);

		Vector3 topLeft = (_camera.transform.forward - toRight + toTop);
		float camScale = topLeft.magnitude * camFar;

		topLeft.Normalize();
		topLeft *= camScale;

		Vector3 topRight = (_camera.transform.forward + toRight + toTop);
		topRight.Normalize();
		topRight *= camScale;

		Vector3 bottomRight = (_camera.transform.forward + toRight - toTop);
		bottomRight.Normalize();
		bottomRight *= camScale;

		Vector3 bottomLeft = (_camera.transform.forward - toRight - toTop);
		bottomLeft.Normalize();
		bottomLeft *= camScale;

		// Custom Blit, encoding Frustum Corners as additional Texture Coordinates
		RenderTexture.active = dest;

		mat.SetTexture("_MainTex", source);

		GL.PushMatrix();
		GL.LoadOrtho();

		mat.SetPass(0);

		GL.Begin(GL.QUADS);

		GL.MultiTexCoord2(0, 0.0f, 0.0f);
		GL.MultiTexCoord(1, bottomLeft);
		GL.Vertex3(0.0f, 0.0f, 0.0f);

		GL.MultiTexCoord2(0, 1.0f, 0.0f);
		GL.MultiTexCoord(1, bottomRight);
		GL.Vertex3(1.0f, 0.0f, 0.0f);

		GL.MultiTexCoord2(0, 1.0f, 1.0f);
		GL.MultiTexCoord(1, topRight);
		GL.Vertex3(1.0f, 1.0f, 0.0f);

		GL.MultiTexCoord2(0, 0.0f, 1.0f);
		GL.MultiTexCoord(1, topLeft);
		GL.Vertex3(0.0f, 1.0f, 0.0f);

		GL.End();
		GL.PopMatrix();
	}
}
