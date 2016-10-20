using System.Collections.Generic;
using UnityEngine;

public class CMineSpawner : MonoBehaviour
{
	public List<Vector3> m_vSpawnPositions;

	public CMineFactory m_tMineFactory;
	public Transform m_tPlanet;
		
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