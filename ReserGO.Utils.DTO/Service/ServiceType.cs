using System.Collections.ObjectModel;

namespace ReserGO.Utils.DTO.Service
{
    public class ServiceType : EnumBaseType<ServiceType>
    {

        public ServiceType(int key, string value) : base(key, value)
        {
        }

        public static readonly ServiceType Base = new ServiceType(0, "Base");

        public static ReadOnlyCollection<ServiceType> GetValues()
        {
            return GetBaseValues();
        }

        public static ServiceType GetByKey(int key)
        {
            return GetBaseByKey(key);
        }

    }
}
