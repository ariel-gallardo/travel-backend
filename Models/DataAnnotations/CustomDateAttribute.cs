namespace Services.Helpers
{
    using System;
    using System.ComponentModel.DataAnnotations;

    namespace Models.DataAnnotations
    {
        public class CustomDateAttribute : ValidationAttribute
        {
            public CustomDateAttribute()
            {
            }

            public override bool IsValid(object value)
            {
                var dt = (DateTime)value;
                var dtMax = DateTime.Now.AddDays(10);

                if (dt >= DateTime.Now && dt <= dtMax)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
