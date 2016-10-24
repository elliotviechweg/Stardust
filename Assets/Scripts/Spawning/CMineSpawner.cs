using System.Collections.Generic;
using UnityEngine;

public class CMineSpawner : MonoBehaviour
{
	// Variables set in editor
	[SerializeField]
	private List<Vector3> m_vSpawnPositions;

	// Components assigned in editor
	[SerializeField]
	private CMineFactory m_tMineFactory;
	[SerializeField]
	private Transform m_tPlanet;
		
	public void SpawnMines()
	{
		foreach (Vector3 vSpawnPosition in m_vSpawnPositions)
		{
			m_tMineFactory.SpawnMine(GenerateSpawnPosition(vSpawnPosition));
		}			
	}

	private Vector3 GenerateSpawnPosition(Vector3 i_vSpawnPosition)
	{
		return m_tPlanet.position + i_vSpawnPosition;
	}
}