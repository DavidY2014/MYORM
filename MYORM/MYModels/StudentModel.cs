using System;
using MYORM.Framwork.Mapping;

namespace MYModels
{
    [MYTable("Student")]
    public class StudentModel: BaseModel
    {
        public string Name { get; set; }

        [MYColumn("CreateId")]
        public int CreatorId { get; set; }
        public Nullable<int> LastModifierId { get; set; }
        
        public DateTime? LastModifyTime { get; set; }
    }
}
