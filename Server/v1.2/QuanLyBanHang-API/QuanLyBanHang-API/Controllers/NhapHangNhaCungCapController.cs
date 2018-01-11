using EntityModel.DataModel;
using QuanLyBanHang_API;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Server.Controllers
{
    public class NhapHangNhaCungCapController : BaseController<eNhapHangNhaCungCap>
    {
        public NhapHangNhaCungCapController(IRepositoryCollection Collection) : base(Collection)
        {
        }

        public async override Task<IHttpActionResult> GetAll()
        {
            Instance.Context = new aModel();
            try
            {
                List<eNhapHangNhaCungCapChiTiet> lstDetail = await Instance.Context.eNhapHangNhaCungCapChiTiet.ToListAsync();
                var qDT =
                    from a in lstDetail
                    group a by a.IDNhapHangNhaCungCap into b
                    select new { IDNhapHangNhaCungCap = b.Key, NhapHangNhaCungCapChiTiets = b.ToList() };

                List<eNhapHangNhaCungCap> lstMaster = await Instance.Context.eNhapHangNhaCungCap.ToListAsync();
                lstMaster.ForEach(a =>
                {
                    var b = qDT.FirstOrDefault(c => c.IDNhapHangNhaCungCap == a.KeyID);
                    if (b != null)
                    {
                        b.NhapHangNhaCungCapChiTiets.ForEach(c =>
                        {
                            a.eNhapHangNhaCungCapChiTiet.Add(c);
                        });
                    }
                });

                List<eNhapHangNhaCungCap> lstResult = new List<eNhapHangNhaCungCap>(lstMaster);
                return Ok(lstResult);
            }
            catch { return BadRequest(); }
        }

        public async override Task<IHttpActionResult> GetByID(Int32? KeyID)
        {
            Instance.Context = new aModel();
            try
            {
                eNhapHangNhaCungCap Item = await Instance.Context.eNhapHangNhaCungCap.FindAsync(KeyID.HasValue ? KeyID.Value : 0);
                IEnumerable<eNhapHangNhaCungCapChiTiet> lstItemDetail = await Instance.Context.eNhapHangNhaCungCapChiTiet.Where(x => x.IDNhapHangNhaCungCap == Item.KeyID).ToListAsync();
                lstItemDetail.ToList().ForEach(x => Item.eNhapHangNhaCungCapChiTiet.Add(x));
                return Ok(Item);
            }
            catch { return BadRequest(); }
        }

        public async override Task<IHttpActionResult> AddEntries(eNhapHangNhaCungCap[] Items)
        {
            Instance.Context = new aModel();
            try
            {
                Instance.BeginTransaction();

                Items = Items ?? new eNhapHangNhaCungCap[] { };

                Instance.Context.eNhapHangNhaCungCap.AddOrUpdate(Items);
                await Instance.Context.SaveChangesAsync();

                Items.ToList().ForEach(x =>
                {
                    x.eNhapHangNhaCungCapChiTiet.ToList().ForEach(y =>
                    {
                        y.IDNhapHangNhaCungCap = x.KeyID;
                    });
                    Instance.Context.eNhapHangNhaCungCapChiTiet.AddOrUpdate(x.eNhapHangNhaCungCapChiTiet.ToArray());
                });

                await CapNhatCongNo(Items);
                await CapNhatTonKho( Items);

                await Instance.Context.SaveChangesAsync();
                Instance.CommitTransaction();

                return Ok(Items);
            }
            catch (Exception ex)
            {
                Instance.RollbackTransaction();
                return BadRequest();
            }
        }

        public async override Task<IHttpActionResult> UpdateEntries(eNhapHangNhaCungCap[] Items)
        {
            Instance.Context = new aModel();
            try
            {
                Instance.BeginTransaction();

                Instance.Context.eNhapHangNhaCungCap.AddOrUpdate(Items);

                Items.ToList().ForEach(async x =>
                {
                    IEnumerable<eNhapHangNhaCungCapChiTiet> lstDetail = await Instance.Context.eNhapHangNhaCungCapChiTiet.Where(y => y.IDNhapHangNhaCungCap == x.KeyID).ToListAsync();
                    lstDetail.ToList().ForEach(y =>
                    {
                        eNhapHangNhaCungCapChiTiet obj = x.eNhapHangNhaCungCapChiTiet.FirstOrDefault(z => z.KeyID == y.KeyID);
                        if (obj == null)
                            Instance.Context.eNhapHangNhaCungCapChiTiet.Remove(y);
                        else
                            Instance.Context.Entry(y).CurrentValues.SetValues(obj);

                    });
                    x.eNhapHangNhaCungCapChiTiet.ToList().ForEach(y =>
                    {
                        if (y.KeyID <= 0)
                        {
                            y.IDNhapHangNhaCungCap = x.KeyID;
                            Instance.Context.eNhapHangNhaCungCapChiTiet.Add(y);
                        }
                    });
                });

                await CapNhatCongNo( Items);
                await CapNhatTonKho(Items);

                await Instance.Context.SaveChangesAsync();
                Instance.CommitTransaction();

                return Ok(Items);
            }
            catch (Exception ex)
            {
                Instance.RollbackTransaction();
                return BadRequest();
            }
        }

        async Task CapNhatCongNo(eNhapHangNhaCungCap[] Items)
        {
            foreach (eNhapHangNhaCungCap item in Items)
            {
                eCongNoNhaCungCap congNo = await Instance.Context.eCongNoNhaCungCap.FirstOrDefaultAsync(x => x.IsNhapHang && x.IDMaster == item.KeyID);
                if (congNo == null)
                {
                    congNo = new eCongNoNhaCungCap();
                    congNo.IDNhaCungCap = item.IDNhaCungCap;
                    congNo.IDMaster = item.KeyID;
                    congNo.NguoiTao = item.NguoiTao;
                    congNo.MaNguoiTao = item.MaNguoiTao;
                    congNo.TenNguoiTao = item.TenNguoiTao;
                    congNo.NgayTao = item.NgayTao;
                    congNo.IsNhapHang = true;
                    Instance.Context.eCongNoNhaCungCap.AddOrUpdate(congNo);
                }
                else
                {
                    congNo.NguoiCapNhat = item.NguoiCapNhat;
                    congNo.MaNguoiCapNhat = item.MaNguoiCapNhat;
                    congNo.TenNguoiCapNhat = item.TenNguoiCapNhat;
                    congNo.NgayCapNhat = item.NgayCapNhat;
                }
                congNo.MaNhaCungCap = item.MaNhaCungCap;
                congNo.TenNhaCungCap = item.TenNhaCungCap;
                congNo.TrangThai = item.TrangThai;
                congNo.Ngay = item.NgayNhap;
                congNo.ThanhTien = item.ThanhTien;
                congNo.VAT = item.VAT;
                congNo.TienVAT = item.TienVAT;
                congNo.CK = item.ChietKhau;
                congNo.TienCK = item.TienChietKhau;
                congNo.TongTien = item.TongTien;
                congNo.NoCu = item.NoCu;
                congNo.ThanhToan = item.ThanhToan;
                congNo.ConLai = item.ConLai;
                congNo.GhiChu = item.GhiChu;
            }
        }
        async Task CapNhatTonKho( eNhapHangNhaCungCap[] Items)
        {
            foreach (eNhapHangNhaCungCap item in Items)
            {
                foreach (eNhapHangNhaCungCapChiTiet itemDT in item.eNhapHangNhaCungCapChiTiet)
                {
                    eTonKho tonKho = await Instance.Context.eTonKho.FirstOrDefaultAsync(x => x.IsNhapHang && x.IDMaster == item.KeyID && x.IDDetail == itemDT.KeyID);

                    if (tonKho == null)
                    {
                        tonKho = new eTonKho();
                        tonKho.IDSanPham = itemDT.IDSanPham;
                        tonKho.IDNhomSanPham = itemDT.IDNhomSanPham;
                        tonKho.IDDonViTinh = itemDT.IDDonViTinh;
                        tonKho.IDMaster = item.KeyID;
                        tonKho.IDDetail = itemDT.KeyID;
                        tonKho.NguoiTao = item.NguoiTao;
                        tonKho.MaNguoiTao = item.MaNguoiTao;
                        tonKho.TenNguoiTao = item.TenNguoiTao;
                        tonKho.NgayTao = item.NgayTao;
                        tonKho.IsNhapHang = true;
                        Instance.Context.eTonKho.AddOrUpdate(tonKho);
                    }
                    else
                    {
                        tonKho.NguoiCapNhat = item.NguoiCapNhat;
                        tonKho.MaNguoiCapNhat = item.MaNguoiCapNhat;
                        tonKho.TenNguoiCapNhat = item.TenNguoiCapNhat;
                        tonKho.NgayCapNhat = item.NgayCapNhat;
                    }
                    tonKho.Ngay = item.NgayNhap;
                    tonKho.MaSanPham = itemDT.MaSanPham;
                    tonKho.TenSanPham = itemDT.TenSanPham;
                    tonKho.MaNhomSanPham = itemDT.MaNhomSanPham;
                    tonKho.TenNhomSanPham = itemDT.TenNhomSanPham;
                    tonKho.MaDonViTinh = itemDT.MaDonViTinh;
                    tonKho.TenDonViTinh = itemDT.TenDonViTinh;
                    tonKho.HanSuDung = itemDT.HanSuDung;
                    tonKho.SoLuongSi = itemDT.SoLuongSi;
                    tonKho.SoLuongLe = itemDT.SoLuongLe;
                    tonKho.SoLuong = itemDT.SoLuong;
                }
            }
        }
    }
}
