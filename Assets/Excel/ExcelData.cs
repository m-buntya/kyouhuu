using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class ExcelData : ScriptableObject
{
	public List<CharacterMasterDataEntity> CharacterMaster; 
	public List<ObstacleMasterDataEntity> ObstacleMaster; 
}
