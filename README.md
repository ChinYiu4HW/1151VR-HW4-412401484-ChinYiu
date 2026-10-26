# 1151VR-HW4-412401484-ChinYiu



Youtube 連結︰
https://www.youtube.com/watch?v=fcosfHOViKI




說明製作流程和相關操作 ︰
增加player group 存放2個model + camera 
寫script 建立 camera switcher 用來切換鏡頭視角 
- 平常第一人稱時只顯示駕駛倉
- 切換至第三人稱時隱藏駕駛倉 + 顯示飛機外殼 
物理移動 +搖桿控制利用 Unity 的 Rigidbody與搖桿GUI，控制飛船的前後推進與 3D 空間移動
飛機加入 Rigidbody 關閉重力+freeze旋轉，讓飛船能夠在空中平穩飛行
畫面加上 TextMeshPro 提示文字，顯示目前的視角狀態 (第一人稱 or 第三人稱)
TextMeshPro 顯示距離終點有多遠
機尾加入火炎VFX
設定Front與Back的button event，讓玩家透過 UI 來控制前後(只有前進時會播放引擎音效)
引擎音效->透過判斷油門狀態throttleInput < 0, 自動控制噴射引擎音效的播放與停止
增加碰撞到石頭時音效 + 石頭上collider 
增加到達終點時播放音效+ TextMeshPro 顯示GOAL~
增加切換畫面的button (E)
將飛行專案打包輸出安裝到手機中運行<br>


(我找不到免費好看的太空船3D 模組只能用飛機了哈哈哈)<br><br>

所使用到的素材︰<br>
火炎VFX:https://assetstore.unity.com/packages/vfx/particles/fire-explosions/<br>
撞到石頭音效: https://pixabay.com/sound-effects/film-special<br>
BGM:https://pixabay.com/zh/music/main-title-secrets-of-the-jedi-inspired-by-star-wars-331637/ <br>
噴射器飛行時音效:https://sonilo.com/royalty-free-sound-effects/aircraft/<br>
手機搖桿GUI https://assetstore.unity.com/packages/tools/gui/pinepie-joystick-325958 <br>
機倉內 3D model : https://sketchfab.com/3d-models/a-sci-fi-cockpit-concept<br>
飛機模組: https://booth.pm/zh-tw/items/7846313<br>
到達終點音效:https://pixabay.com/sound-effects/search/game/?pagi=2<br>
Joystick :https://assetstore.unity.com/packages/tools/gui/pinepie-joystick-325958<br>
隕石3D model: https://assetstore.unity.com/packages/3d/environments/sci-fi/3d-asteroid-pack-263841<br>
星空SKY BOX: https://assetstore.unity.com/packages/3d/environments/sci-fi/real-stars-skybox-lite-116333<br>
地球3D model: https://assetstore.unity.com/packages/3d/environments/sci-fi/planet-earth-free-23399<br>

