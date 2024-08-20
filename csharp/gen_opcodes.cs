using System;
using System.Reflection.Emit;

// 創建一個動態方法
DynamicMethod method = new DynamicMethod("AssemblyMethod", null, null);
ILGenerator il = method.GetILGenerator();

// 添加你的組合語言指令
il.Emit(OpCodes.Nop);
// 添加更多指令...

// 獲取生成的字節
byte[] ilBytes = method.GetMethodBody().GetILAsByteArray();
