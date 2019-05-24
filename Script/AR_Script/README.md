# Script Description

<br>

* [**Scene_Manager**](https://github.com/jaydenjian/An-AR-Game-System-for-elderly/blob/master/Script/AR_Script/Scene_Manager.cs) : 放在SceneManager物件裡，管理每個場景切換。<br>

* [**OutlineEffect**](https://github.com/jaydenjian/An-AR-Game-System-for-elderly/blob/master/Script/AR_Script/OutlineEffect.cs) : 放在ARCamera物件裡，用於物件選取效果。當物件被 **指到** 或 **選取** 時，會出現一圈橘色外框。 <br>
[【The script was import from here】](https://assetstore.unity.com/packages/vfx/shaders/fullscreen-camera-effects/outline-effect-78608)

* [**DetectTrigger**](https://github.com/jaydenjian/An-AR-Game-System-for-elderly/blob/master/Script/AR_Script/DetectTrigger.cs) : 放在ARCamera物件裡，偵測抓取物件，當欲抓取物件出現在範圍內，便可做抓取動作。<br>

* [**ObjController**](https://github.com/jaydenjian/An-AR-Game-System-for-elderly/blob/master/Script/AR_Script/ObjController.cs) : 放在欲拼湊建築物物件裡，當使用者點擊放置位置，便將建築物放置在點擊處上方，使建築物有墜落出現效果。<br>

* [**ControlAllChild**](https://github.com/jaydenjian/An-AR-Game-System-for-elderly/blob/master/Script/AR_Script/ControlAllChild.cs) : 放在欲拼湊建築物物件裡，因物件由許多零碎物件所組成，如果要有outline效果，必須讓所有零碎物件皆有[Outline]、[OutlineControl]兩個腳本，故使用此腳本，當生成時，便將所有零碎物件新增此兩個腳本，並使其有Outline的效果。<br>

* [**Outline**](https://github.com/jaydenjian/An-AR-Game-System-for-elderly/blob/master/Script/AR_Script/Outline.cs) : 用於使物件被Select時，有Outline的效果。<br>

* [**OutlineControl**](https://github.com/jaydenjian/An-AR-Game-System-for-elderly/blob/master/Script/AR_Script/OutlineControl.cs) : 用於測試Outline效果。<br>

* [**Transparent**](https://github.com/jaydenjian/An-AR-Game-System-for-elderly/blob/master/Script/AR_Script/Transparent.cs) : 放在主建築物的**欲拼湊區塊**物件裡。在還未拼湊時，該區塊透明化處理，讓使用者知道散落的建築物應該拼在此處。<br>

* [**PutTogether**](https://github.com/jaydenjian/An-AR-Game-System-for-elderly/blob/master/Script/AR_Script/PutTogether.cs) : 放在主建築物的**欲拼湊區塊**物件裡。當拼湊區塊，進入此範圍內，將被直接吸附並對齊物件。<br>

* [**MemoryButton**](https://github.com/jaydenjian/An-AR-Game-System-for-elderly/blob/master/Script/AR_Script/MemoryButton.cs) : 用於生成 **[回憶相簿]** 按鈕，以及生成其UI介面，當物件拼湊完成，便會跳出完成畫面。<br>

* [**Hand_AnimControl**](https://github.com/jaydenjian/An-AR-Game-System-for-elderly/blob/master/Script/AR_Script/Hand_AnimControl.cs) : 用於手部抓取動畫bool參數設定。<br>

* [**UseSceneManager**](https://github.com/jaydenjian/An-AR-Game-System-for-elderly/blob/master/Script/AR_Script/UseSceneManager.cs) : 切換場景時，連接[Scene_Manager]用。<br>

* [**UnderMenuControl**](https://github.com/jaydenjian/An-AR-Game-System-for-elderly/blob/master/Script/AR_Script/UnderMenuControl.cs) : 用於下方選單動畫bool參數設定。<br>

* [**IndicateUse**](https://github.com/jaydenjian/An-AR-Game-System-for-elderly/blob/master/Script/AR_Script/IndicateUse.cs) : 用於遊戲前的[操作提示視窗]的動畫設定。
