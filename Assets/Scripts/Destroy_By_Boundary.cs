using UnityEngine;
using System.Collections;

public class Destroy_By_Boundary : MonoBehaviour 
{
	void OnTriggerExit2D(Collider2D other)
	{ Destroy(other.gameObject); }
}
