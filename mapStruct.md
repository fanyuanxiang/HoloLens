# MapStruct使用

 DO 是db object 数据库对象 DTO 是db transfer object 传输对象. DO 的属性字段是不会包含对象引用的。person应该是DTO  DTO 数据传输对象  （data transform object）



在一个成熟的工程中，尤其是现在的分布式系统中，应用与应用之间，还有单独的应用细分模块之后，DO 一般不会让外部依赖，这时候需要在提供对外接口的模块里放 DTO 用于对象传输，也即是 DO 对象对内，DTO对象对外，DTO 可以根据业务需要变更，并不需要映射 DO 的全部属性。

这种 对象与对象之间的互相转换，就需要有一个专门用来解决转换问题的工具，毕竟每一个字段都 get/set 会很麻烦。

MapStruct 就是这样的一个属性映射工具，只需要定义一个 Mapper 接口，MapStruct 就会自动实现这个映射接口，避免了复杂繁琐的映射实现。MapStruct官网地址： http://mapstruct.org/







使用参考博客

https://blog.csdn.net/zhige_me/article/details/80699784



