using System.Collections.ObjectModel;

namespace ReserGO.Utils.DTO.Service
{
    public class ServiceType : EnumBaseType<ServiceType>
    {

        public ServiceType(int key, string value) : base(key, value)
        {
        }

        public static readonly ServiceType Insert = new ServiceType(1, "Insert");
        public static readonly ServiceType Update = new ServiceType(2, "Update");
        public static readonly ServiceType LogicalDelete = new ServiceType(3, "LogicalDelete");
        public static readonly ServiceType FinalDelete = new ServiceType(4, "FinalDelete");
        public static readonly ServiceType SelectById = new ServiceType(5, "SelectById");
        public static readonly ServiceType SelectAll = new ServiceType(6, "SelectAll");
        public static readonly ServiceType SelectAllByUsername = new ServiceType(7, "SelectAllByUsername");
        public static readonly ServiceType SelectByIDList = new ServiceType(8, "SelectByIDList");
        public static readonly ServiceType Base = new ServiceType(9, "Base");


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
