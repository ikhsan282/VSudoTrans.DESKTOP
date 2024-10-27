using System;

namespace Contract.Base
{
    public abstract class BaseDto
    {
        public string Code { get; set; } = String.Empty;
    }

    public abstract class EntityDto : BaseDto
    {
        public string Name { get; set; } = String.Empty;

        public string Note { get; set; }
    }
}
