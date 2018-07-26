using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

public static class scrDataManager {
	private static List<string[]> rowData = new List<string[]>();

	public static void saveData(string level, string objName, float foundTime, int clicks) {
		string[] rowDataTemp = new string[4];
		rowDataTemp[0] = level;
		rowDataTemp[1] = objName;
		rowDataTemp[2] = foundTime.ToString();
		rowDataTemp[3] = clicks.ToString();
		rowData.Add(rowDataTemp);
	}

	public static void writeCSV() {
		string filePath = getPath();
		StreamWriter outStream = System.IO.File.CreateText(filePath);

		outStream.WriteLine("{0},{1},{2},{3}", "Level", "Object Name", "Time taken to find", "No. Left Mouse Clicks");
		string[][] output = new string[rowData.Count][];

		for(int i = 0; i < output.Length; i++) {
			output[i] = rowData[i];
		}
		
		string delimiter = ",";
		StringBuilder sb = new StringBuilder();

		for(int index = 0; index < output.GetLength(0); index++) {
			sb.AppendLine(string.Join(delimiter, output[index]));
		}

		outStream.WriteLine(sb);
		outStream.Close();
	}

	private static string getPath() {
		DateTime dt = DateTime.Now;

		string path = Path.Combine(Application.persistentDataPath, "data");
		path = Path.Combine(path, DateTime.Now.ToString("hh:mm:ss")+ ".csv");

		if (!Directory.Exists(Path.GetDirectoryName(path))) {
    		Directory.CreateDirectory(Path.GetDirectoryName(path));
		}

		return path;
	}
}