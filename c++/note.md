## cmake
打包lib檔時`add_library` 移漏cpp檔案在`static`下不會報錯，可以換成‵shared`打包成dll檢查是否遺漏
```cmake
ADD_LIBRARY(lib STATIC show.cpp other.cpp) #漏了不會報錯
ADD_LIBRARY(lib SHARED show.cpp other.cpp) #漏了彙報錯
```
