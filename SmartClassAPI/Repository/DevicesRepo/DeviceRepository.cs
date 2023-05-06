using SmartClassAPI.Data;
using SmartClassAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace SmartClassAPI.Repository.DevicesRepo
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly MyDbContext _context;

        public DeviceRepository(MyDbContext context)
        {
            _context = context;
        }

        public DevicesVM Add(DevicesModel devices)
        {

            var _devices = new DevicesData
            {
                //IdDevice = devices.IdDevice,
                DeviceName = devices.DeviceName,
                DeviceTpye = devices.DeviceTpye,
                MieuTaCongDung = devices.MieuTaCongDung,
                IdPhongHoc = devices.IdPhongHoc,
                IdUser = devices.IdUser,
            };
            _context.Add(_devices);
            _context.SaveChanges();
            var de = _context.Entry(_devices);
            de.Reference(de => de.PhongHocData).Load();
            de.Reference(de => de.User).Load();
            if (_devices.IdPhongHoc == null)
            {
                return new DevicesVM
                {
                    //IdDevice = _devices.IdDevice,
                    DeviceName = _devices.DeviceName,
                    DeviceTpye = _devices.DeviceTpye,
                    MieuTaCongDung = _devices.MieuTaCongDung,
                    IdPhongHoc = _devices.IdPhongHoc,
                    IdUser = _devices.IdUser,
                    HoTen = _devices.User.HoTen,
                    //LoaiUser = _devices.User.LoaiUser,
                };
            }
            else if(_devices.IdUser == null)
            {
                return new DevicesVM
                {
                    //IdDevice = _devices.IdDevice,
                    DeviceName = _devices.DeviceName,
                    DeviceTpye = _devices.DeviceTpye,
                    MieuTaCongDung = _devices.MieuTaCongDung,
                    IdPhongHoc = _devices.IdPhongHoc,
                    TenPhongHoc = _devices.PhongHocData.TenPhongHoc,
                    IdUser = _devices.IdUser,
                    //HoTen = _devices.User.HoTen,
                    //LoaiUser = _devices.User.LoaiUser,
                };
            }
            else
            {
                return new DevicesVM
                {
                    //IdDevice = _devices.IdDevice,
                    DeviceName = _devices.DeviceName,
                    DeviceTpye = _devices.DeviceTpye,
                    MieuTaCongDung = _devices.MieuTaCongDung,
                    IdPhongHoc = _devices.IdPhongHoc,
                    TenPhongHoc = _devices.PhongHocData.TenPhongHoc,
                    IdUser = _devices.IdUser,
                    HoTen = _devices.User.HoTen,
                    //LoaiUser = _devices.User.LoaiUser,
                };
            }
                      
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<DevicesVM> GetAll()
        {
            var devices = _context.DevicesDatas.Select(de => new DevicesVM
            {
                IdDevice = de.IdDevice,
                DeviceName = de.DeviceName,
                DeviceTpye = de.DeviceTpye,
                MieuTaCongDung = de.MieuTaCongDung,
                IdPhongHoc = de.IdPhongHoc,
                TenPhongHoc = de.PhongHocData.TenPhongHoc,
                IdUser = de.IdUser,
                HoTen = de.User.HoTen,
                //LoaiUser = de.User.LoaiUser,
            });
            return devices.ToList();
        }

        public DevicesVM GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateById(int id, DevicesVM devicesVM)
        {
            throw new System.NotImplementedException();
        }
    }
}
