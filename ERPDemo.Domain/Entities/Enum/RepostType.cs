using System.ComponentModel;

namespace ERPDemo.Domain.Entities.Enum
{
    public enum RepostType
    {
        [Description("Repost")]
        Repost = 0,

        [Description("Quoted")]
        Quoted = 1,
    }
}
