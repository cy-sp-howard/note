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
```

