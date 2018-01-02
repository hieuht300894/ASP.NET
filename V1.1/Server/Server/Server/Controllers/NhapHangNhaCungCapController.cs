using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    public class NhapHangNhaCungCapController : BaseController<eNhapHangNhaCungCap>
    {
        //public async override Task<IEnumerable<eNhapHangNhaCungCap>> GetAll()
        //{
        //    try
        //    {
        //        return await Task.Factory.StartNew(() =>
        //        {
        //            Instance.Context = new Model.aModel();
        //            IEnumerable<eNhapHangNhaCungCap> lstMaster = Instance.Context.eNhapHangNhaCungCap.ToList();
        //            IEnumerable<eNhapHangNhaCungCapChiTiet> lstDetail = Instance.Context.eNhapHangNhaCungCapChiTiet.ToList();

        //            var q1 =
        //                from a in lstDetail
        //                group a by a.IDNhapHangNhaCungCap into g
        //                select new { Key = g.Key, Value = g.ToList() };
        //            var q2 =
        //                from a in lstMaster
        //                join b in q1
        //                on a.KeyID equals b.Key
        //                select new { Master = a, Detail = b.Value };
        //            q2.ToList().ForEach(x =>
        //            {
        //                x.Detail.ForEach(y =>
        //                {
        //                    x.Master.eNhapHangNhaCungCapChiTiet.Add(y);
        //                });
        //            });
        //            var q3 =
        //                from a in q2
        //                select a.Master;

        //            List<eNhapHangNhaCungCap> lstResult = new List<eNhapHangNhaCungCap>(q3);
        //            return lstResult;
        //        });

        //    }
        //    catch { return new List<eNhapHangNhaCungCap>(); }
        //}

        //public async override Task<eNhapHangNhaCungCap> GetByID(Int32 id)
        //{
        //    try
        //    {
        //        Instance.Context = new Model.aModel();
        //        eNhapHangNhaCungCap item = await Instance.GetByID(id);
        //        IEnumerable<eNhapHangNhaCungCapChiTiet> lstItemDetail = Instance.Context.eNhapHangNhaCungCapChiTiet.Where(x => x.IDNhapHangNhaCungCap == item.KeyID);
        //        lstItemDetail.ToList().ForEach(x => item.eNhapHangNhaCungCapChiTiet.Add(x));
        //        return item;
        //    }
        //    catch { return new eNhapHangNhaCungCap(); }
        //}

        //public async override Task<IActionResult> AddEntries([FromBody] eNhapHangNhaCungCap[] Items)
        //{
        //    try
        //    {
        //        Instance.Context = new Model.aModel();
        //        await Instance.BeginTransaction();

        //        Items = Items ?? new eNhapHangNhaCungCap[] { };
        //        Items.ToList().ForEach(x => x.KeyID = 0);

        //        await Instance.Context.eNhapHangNhaCungCap.AddRangeAsync(Items);
        //        await Instance.SaveChanges();

        //        Items.ToList().ForEach(async (x) =>
        //        {
        //            x.eNhapHangNhaCungCapChiTiet.ToList().ForEach(y =>
        //            {
        //                y.KeyID = 0;
        //                y.IDNhapHangNhaCungCap = x.KeyID;
        //            });
        //            await Instance.Context.eNhapHangNhaCungCapChiTiet.AddRangeAsync(x.eNhapHangNhaCungCapChiTiet.ToArray());
        //        });

        //        CapNhatCongNo(Items);

        //        await Instance.SaveChanges();
        //        Instance.CommitTransaction();

        //        return Ok(Items);
        //    }
        //    catch
        //    {
        //        Instance.RollbackTransaction();
        //        return BadRequest();
        //    }
        //}

        //public async override Task<IActionResult> UpdateEntries([FromBody] eNhapHangNhaCungCap[] Items)
        //{
        //    try
        //    {
        //        Instance.Context = new Model.aModel();
        //        await Instance.BeginTransaction();

        //        Instance.Context.eNhapHangNhaCungCap.UpdateRange(Items);

        //        Items.ToList().ForEach(x =>
        //        {
        //            IEnumerable<eNhapHangNhaCungCapChiTiet> lstDetail = Instance.Context.eNhapHangNhaCungCapChiTiet.Where(y => y.IDNhapHangNhaCungCap == x.KeyID).ToList();
        //            lstDetail.ToList().ForEach(y =>
        //            {
        //                eNhapHangNhaCungCapChiTiet obj = x.eNhapHangNhaCungCapChiTiet.FirstOrDefault(z => z.KeyID == y.KeyID);
        //                if (obj == null)
        //                    Instance.Context.eNhapHangNhaCungCapChiTiet.Remove(y);
        //                else
        //                    Instance.Context.Entry(y).CurrentValues.SetValues(obj);

        //            });
        //            x.eNhapHangNhaCungCapChiTiet.ToList().ForEach(y =>
        //            {
        //                if (y.KeyID <= 0)
        //                {
        //                    y.KeyID = 0;
        //                    y.IDNhapHangNhaCungCap = x.KeyID;
        //                    Instance.Context.eNhapHangNhaCungCapChiTiet.Add(y);
        //                }
        //            });
        //        });

        //        CapNhatCongNo(Items);

        //        await Instance.SaveChanges();
        //        Instance.CommitTransaction();

        //        return Ok(Items);
        //    }
        //    catch
        //    {
        //        Instance.RollbackTransaction();
        //        return BadRequest();
        //    }
        //}

        //async void CapNhatCongNo(eNhapHangNhaCungCap[] Items)
        //{
        //    foreach (eNhapHangNhaCungCap item in Items)
        //    {
        //        eCongNoNhaCungCap congNo = Instance.Context.eCongNoNhaCungCap.FirstOrDefault(x => x.IsNhapHang && x.IDMaster == item.KeyID);
        //        if (congNo == null)
        //        {
        //            congNo = new eCongNoNhaCungCap();
        //            congNo.KeyID = 0;
        //            congNo.IDNhaCungCap = item.IDNhaCungCap;
        //            congNo.MaNhaCungCap = item.MaNhaCungCap;
        //            congNo.TenNhaCungCap = item.TenNhaCungCap;
        //            congNo.IDMaster = item.KeyID;
        //            congNo.NguoiTao = item.NguoiTao;
        //            congNo.MaNguoiTao = item.MaNguoiTao;
        //            congNo.TenNguoiTao = item.TenNguoiTao;
        //            congNo.NgayTao = item.NgayTao;
        //            congNo.IsNhapHang = true;
        //            await Instance.Context.eCongNoNhaCungCap.AddAsync(congNo);
        //        }
        //        else
        //        {
        //            congNo.NguoiCapNhat = item.NguoiCapNhat;
        //            congNo.MaNguoiCapNhat = item.MaNguoiCapNhat;
        //            congNo.TenNguoiCapNhat = item.TenNguoiCapNhat;
        //            congNo.NgayCapNhat = item.NgayCapNhat;
        //        }
        //        congNo.TrangThai = item.TrangThai;
        //        congNo.Ngay = item.NgayNhap;
        //        congNo.ThanhTien = item.ThanhTien;
        //        congNo.VAT = item.VAT;
        //        congNo.TienVAT = item.TienVAT;
        //        congNo.CK = item.ChietKhau;
        //        congNo.TienCK = item.TienChietKhau;
        //        congNo.TongTien = item.TongTien;
        //        congNo.NoCu = item.NoCu;
        //        congNo.ThanhToan = item.ThanhToan;
        //        congNo.ConLai = item.ConLai;
        //        congNo.GhiChu = item.GhiChu;
        //    }
        //}

        //[HttpGet]
        //[Route("CongNoHienTai/{IDMaster}/{IDNhaCungCap}/{NgayHienTai}")]
        //public eCongNoNhaCungCap CongNoHienTai(int IDMaster, int IDNhaCungCap, DateTime NgayHienTai)
        //{
        //    try
        //    {
        //        Instance.Context = new Model.aModel();
        //        IEnumerable<eCongNoNhaCungCap> lstCongNo = Instance.Context.eCongNoNhaCungCap.Where(x => x.IDNhaCungCap == IDNhaCungCap);
        //        lstCongNo = lstCongNo.Where(x => x.Ngay.Date <= NgayHienTai.Date);

        //        eCongNoNhaCungCap congNo = lstCongNo.FirstOrDefault(x => x.IDMaster == IDMaster) ?? new eCongNoNhaCungCap();
        //        congNo.ConLai = lstCongNo.Where(x => x.IDMaster != IDMaster).ToList().Sum(x => x.ConLai);
        //        return congNo;
        //    }
        //    catch { return new eCongNoNhaCungCap(); }
        //}
    }
}
