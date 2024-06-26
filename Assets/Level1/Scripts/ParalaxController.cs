using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxController : MonoBehaviour
{
	Transform Cam; // Main Camera
	Vector3 CamStartPos;
	float distance; // destance between camera start pos and its cur pos

	GameObject[] backgrounds;
	Material[] mat;
	float[] backSpeed;

	float farthestBack;

	[Range(0.01f, 0.05f)]
	public float parallaxSpeed;

	void Start()
	{
		Cam = Camera.main.transform;
		CamStartPos = Cam.position;

		int backCount = transform.childCount;

		mat = new Material[backCount];
		backSpeed = new float[backCount];
		backgrounds = new GameObject[backCount];

		for (int i = 0; i < backCount; i++)
		{
			backgrounds[i] = transform.GetChild(i).gameObject;

			mat[i] = backgrounds[i].GetComponent<Renderer>().material;
		}

		BackSpeedCalculate(backCount);
	}

	void BackSpeedCalculate(int backCount)
	{
		for (int i = 0; i < backCount; i++)
		{
			if ((backgrounds[i].transform.position.z - Cam.position.z) > farthestBack)
			{
				farthestBack = backgrounds[i].transform.position.z - Cam.position.z;
			}
		}

		for (int i = 0; i < backCount; i++)
		{
			backSpeed[i] = 1 - (backgrounds[i].transform.position.z - Cam.position.z) / farthestBack;
		}
	}

	private void LateUpdate()
	{
		distance = Cam.position.x - CamStartPos.x;

		transform.position = new Vector3(Cam.position.x, transform.position.y, 0);

		for (int i = 0; i < backgrounds.Length; i++)
		{
			float speed = backSpeed[i] * parallaxSpeed;
			mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
		}
	}
}
