using UnityEngine;
using System.Collections;

public class Tests : MonoBehaviour {

	GameObject[] objs = new GameObject[5];
	GameObject ground;
	GameObject r_cube;
	GameObject r_sphere;
	GameObject r_capsule;
	GameObject distance_cube;
	GameObject cam;
	float fps;
	Light dlight;
	string log;
	
	void Awake()
	{
		Application.targetFrameRate = 60;
	}
	
	void Start ()
	{
		log = "Loading Stuff";
		
		fps = 0.0f;
		
		for(int i=0;i<5;i++)
		{
			objs[i] = GameObject.Find("obj"+(i+1).ToString());
		}
		
		ground = GameObject.Find("ground");
		r_cube = GameObject.Find("r_cube");
		r_sphere = GameObject.Find("r_sphere");
		r_capsule = GameObject.Find("r_capsule");
		distance_cube = GameObject.Find("newground/distancecube");
		cam = GameObject.Find("cam");
		
		dlight = ((GameObject) GameObject.Find("dlight")).GetComponent<Light>();
		
		log = "Starting Tests"; Debug.Log (log);
		
		StartCoroutine(MoveObjs());
	}
	
	void Update()
	{
		fps = 1/Time.deltaTime;
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(10,10,300,30),log);
		GUI.Label(new Rect(10,35,200,30),fps.ToString());
		
		if(GUI.Button(new Rect(10,Screen.height-40,80,30),"Restart"))
		{
			Application.LoadLevel("scene");
		}
	}
	
	IEnumerator MoveObjs()
	{
		log = "Test 1: Axis and distance test"; Debug.Log (log);
		int counter = 0;
		
		while(counter++!=250)
		{
			objs[0].transform.position -= new Vector3(0.1f,0.0f,0.0f);
			objs[1].transform.position -= new Vector3(0.1f,-0.1f,0.0f);
			objs[2].transform.position -= new Vector3(0.1f,-0.05f,0.05f);
			
			yield return null;
		}
		
		counter = 0;
		
		log = "Test 2: Transform/Rotation test"; Debug.Log (log);
		
		while(counter++!=250)
		{
			ground.transform.Rotate(0.0f,0.5f,0.0f);
			objs[3].transform.position -= new Vector3(0.1f,0.0f,0.0f);
			objs[3].transform.Rotate(0.9f,0.0f,0.0f);
			objs[3].transform.localScale -= new Vector3(0.01f,0.01f,0.01f);
			
			yield return null;
		}
		
		counter = 0;
		
		log = "Test 3: Round obj test"; Debug.Log (log);
		
		while(counter++!=30)
		{
			objs[4].transform.position -= new Vector3(0.5f,0.0f,0.0f);
			
			yield return null;
		}
		
		counter = 0;
		
		while(counter++!=25)
		{
			objs[4].transform.position -= new Vector3(0.0f,0.1f,0.0f);
			
			yield return null;
		}
		
		counter = 0;
		
		while(counter++!=25)
		{
			objs[4].transform.position += new Vector3(0.0f,0.1f,0.0f);
			
			yield return null;
		}
		
		yield return null;
		yield return null;
		yield return null;
		
		log = "Test 4: ShadowStrength test"; Debug.Log (log);
		
		for(int i=0;i<2;i++)
		{	
			dlight.shadowStrength = 0.0f;
			
			counter = 0;
			
			if(i==1)
				log = "Test 5: ShadowStrenght and Move"; Debug.Log (log);
			
			while(counter++!=100)
			{
				if(i==1)
				{
					objs[4].transform.position += new Vector3(Random.Range(-0.1f,0.2f),Random.Range(-0.1f,0.2f),Random.Range(-0.1f,0.2f));
				}
				
				dlight.shadowStrength += 0.01f;
				
				yield return null;
			}
			
			counter = 0;
			
			while(counter++!=100)
			{
				if(i==1)
				{
					objs[4].transform.position += new Vector3(Random.Range(-0.1f,0.2f),Random.Range(-0.1f,0.2f),Random.Range(-0.1f,0.2f));
				}
				
				dlight.shadowStrength -= 0.01f;
				
				yield return null;
			}
		}
		
		dlight.shadowStrength = 0.5f;
		
		log = "Test 6: Physics and shadows"; Debug.Log (log);
		
		r_cube.AddComponent<Rigidbody>();
		r_sphere.AddComponent<Rigidbody>();
		r_capsule.AddComponent<Rigidbody>();
		
		for(int i=0;i<20;i++) yield return null;
		
		counter = 0;
		
		while(counter++!=120)
		{
			distance_cube.transform.localScale += new Vector3(0.0f,1.0f,0.0f);
			yield return null;
		}
		
		log = "Test 7: ShadowDistance test"; Debug.Log (log);
		
		QualitySettings.shadowDistance = 0;
		ground.transform.localScale += new Vector3(20.0f,0.0f,20.0f);
		
		counter = 0;
		
		while(counter++!=60)
		{
			QualitySettings.shadowDistance += 1;
			
			for(int i=0;i<4;i++) yield return null;
		}
		
		counter = 0;
		
		while(counter++!=100)
		{
			QualitySettings.shadowDistance -= 1;
			
			for(int i=0;i<4;i++) yield return null;
		}
		
		yield return null;
		
		QualitySettings.shadowDistance = 40;
		
		log = "Test 8: ShadowCascades test"; Debug.Log (log);
		
		for(int i=0;i<50;i++) yield return null;
		
		QualitySettings.shadowCascades = 0;
		
		for(int i=0;i<50;i++) yield return null;
		
		QualitySettings.shadowCascades = 2;
		
		for(int i=0;i<50;i++) yield return null;
		
		QualitySettings.shadowCascades = 4;
		
		for(int i=0;i<50;i++) yield return null;
		
		QualitySettings.shadowCascades = 2;
		
		log = "Test 9: ShadowProjection Test"; Debug.Log (log);
		
		QualitySettings.shadowProjection = ShadowProjection.StableFit;
		
		for(int i=0;i<50;i++) yield return null;
		
		QualitySettings.shadowProjection = ShadowProjection.CloseFit;
		
		counter = 0;
		
		log = "Test 10: Directional Light Move test";
		
		while(counter++!=360)
		{
			dlight.transform.Rotate(1.0f,0.0f,0.0f);
			
			yield return null;
		}
		
		log = "Test 11: Camera Move test";
		
		counter = 0;
		
		while(counter++!=360)
		{
			cam.transform.Rotate(0.0f,1.0f,0.0f);
			
			yield return null;
		}
		
		log = "All 11 tests are DONE!";
	}
}
