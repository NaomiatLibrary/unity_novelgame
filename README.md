# 注意
このプロジェクトはまだ作り途中です
# 参考
https://naomi-notebook.hatenablog.com/entry/2020/09/26/191613
https://kanchi0914.hatenablog.com/entry/2019/07/23/070005

# ビルドした後の変更点
index.js
```
<div id="unity-container" class="unity-desktop" style="text-align: center;">
```
```
    if (/iPhone|iPad|iPod|Android/i.test(navigator.userAgent)) {
        //container.className = "unity-mobile";
        config.devicePixelRatio = window.devicePixelRatio;
        container.style.overflow = 'hidden';
        container.style.width = window.innerWidth + 'px';
        container.style.height = window.innerHeight + 'px';
        canvas.style.width  =Math.min(window.innerHeight*960/600,window.innerWidth)+"px";
        canvas.style.height =Math.min(window.innerWidth*600/960,window.innerHeight)+"px";
    } else {
```