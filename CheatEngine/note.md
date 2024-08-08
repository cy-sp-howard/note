### 找pointer
#### 手動找附近地址
2545C0A6B44 找byte[]2545C0A6B?? 得更前面的位置  
偵測誰取值  
得  mov rbx,[rax+rdx*8+08] rax 為000002543F853DD0  
搜尋000002543F853DD0 得 "Gw2-64.exe"+26EFE28  
#### pointer自動找法
指定地址 右鍵 Generate pointermap  
重開遊戲  
指定地址 Pointer scan for this address  
Use saved pointermap
