using UnityEngine;
using System.Collections;

using System.Text;
using System.IO;

public class MapMngr : MonoBehaviour {

	public StreamReader m_xReader;
	
	public string m_xLine;
	
	public string[] m_xEntries;
	
	public Map[] m_xaMaps;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private bool Load(string p_xFname){
		m_xReader = new StreamReader("Untitled2" + ".txt", Encoding.Default);
		
		using (m_xReader){
			m_xaMaps[m_xaMaps.Length] = new Map();
			
			do {
				m_xLine = m_xReader.ReadLine();
				
				if (m_xLine == "[header]"){
					HeaderLoad();
				}
				
				if (m_xLine != null){
					string[] entries = m_xLine.Split(',');
					if (entries.Length > 0){
						//DoStuff(entries);
					}
				}
			} while (m_xLine != null);
			
			m_xReader.Close();
			
			return true;
		}
	}
	
	private void HeaderLoad(){
		//bool _b = false;
		
		m_xLine = m_xReader.ReadLine();
		m_xEntries = m_xLine.Split('=');
		m_xaMaps[m_xaMaps.Length - 1].m_xSize.x = int.Parse(m_xEntries[1]);
		
		m_xLine = m_xReader.ReadLine();
		m_xEntries = m_xLine.Split('=');
		m_xaMaps[m_xaMaps.Length - 1].m_xSize.y = int.Parse(m_xEntries[1]);
		
		m_xLine = m_xReader.ReadLine();
		m_xEntries = m_xLine.Split('=');
		m_xaMaps[m_xaMaps.Length - 1].m_xTileSize.x = int.Parse(m_xEntries[1]);
		
		m_xLine = m_xReader.ReadLine();
		m_xEntries = m_xLine.Split('=');
		m_xaMaps[m_xaMaps.Length - 1].m_xTileSize.y = int.Parse(m_xEntries[1]);
	}
}