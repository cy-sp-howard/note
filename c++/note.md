## cmake
打包lib檔時`add_library` 移漏cpp檔案在`static`下不會報錯，可以換成`shared`打包成dll檢查是否遺漏
.h檔案有函式也不需Add
```cmake
ADD_LIBRARY(lib STATIC show.cpp other.cpp) #漏了不會報錯
ADD_LIBRARY(lib SHARED show.cpp other.cpp) #漏了彙報錯
```

## opcode
lea 是取記憶體相加結果，不取相加後地址裡面的值
```
//esp=1900
//esp+0c=190c
lea ecx,[esp+0C]
//ecx=190c
//括號不取190c位址裡面存的值

//此為取該地址的內值
lea rax,[gw2-64.exe+21587898]

ax 同常是回傳
edi arg1
esi arg2
edx arg3
ecx arg4
r8d arg5
r9d arg6
```

## pointer
char str1[20] = "Hello";
printf() 會從 str1 指向的記憶體地址開始，逐一讀取字元，直到遇到 null 字元 ('\0') 為止  
str1本身就是一格pointer  
*str1 會得到"H"，因為第一個記憶體位置存的就是H  


