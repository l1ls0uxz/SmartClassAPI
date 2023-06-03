using SmartClassAPI.Model;
using System.Collections.Generic;

namespace SmartClassAPI.Repository.DevicesRepo
{
    public interface IDeviceRepository
    {
        List<DevicesVM> GetAll();
        DevicesVM GetById(int id);

        DevicesVM Add(DevicesModel devices);

        void DeleteById(int id);
        void UpdateById(int id, DevicesVM devicesVM);
    }
}
