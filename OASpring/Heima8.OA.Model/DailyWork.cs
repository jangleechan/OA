//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Heima8.OA.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DailyWork
    {
        public int Id { get; set; }
        public string WorkName { get; set; }
        public string WorkContent { get; set; }
        public string WorkDept { get; set; }
        public string SqlLog { get; set; }
        public string LogFile { get; set; }
        public string Remark { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public System.DateTime SubTime { get; set; }
        public short DelFlag { get; set; }
        public int UserInfoId { get; set; }
        public int SysDeptId { get; set; }
    
        public virtual UserInfo UserInfo { get; set; }
        public virtual SysDept SysDept { get; set; }
    }
}
