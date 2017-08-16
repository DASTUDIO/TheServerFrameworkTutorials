using System;

// step 1 使用sf的命名空间
using studio.da.ServerFrameWork;

namespace myRestfulStyleAPI
{                         // 继承 SFModel 接口
    public class MyTable : SFModel
    {

        [IsPrimaryKey(true)]
        public int id;

        [CustomType("varchar(4)")]
        public string Name;

        public string Email;

    }
}
